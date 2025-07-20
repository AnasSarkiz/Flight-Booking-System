using FlightBookingSystem.Helpers;
using FlightBookingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FlightBookingSystem.DAL
{
    public class UserRepository : DbHelper, IUserRepository
    {
        // Authenticate user (existing)
        public User Authenticate(string username, string password)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, PasswordHash, Role, Balance, 
                    FirstName, LastName, DateCreated, LastLogin, IsLocked, 
                    NumberOfBookings, CreatedByAdminId
                    FROM Users 
                    WHERE Username = @Username AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            String storedHash = reader.GetString(2);

                            // Verify the password
                            if (!PasswordHelper.VerifyPassword(password, storedHash))
                            {
                                return null;
                            }

                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                PasswordHash = storedHash,
                                UserRole = (User.Role)reader.GetInt32(3),
                                Balance = reader.GetDecimal(4),
                                FirstName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                LastName = reader.IsDBNull(6) ? null : reader.GetString(6),
                                DateCreated = reader.GetDateTime(7),
                                LastLogin = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                                IsLocked = reader.GetBoolean(9),
                                NumberOfBookings = reader.GetInt32(10),
                                CreatedByAdminId = reader.IsDBNull(11) ? null : (int?)reader.GetInt32(11)
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Authentication failed", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool UpdateBalance(int userId, decimal amount)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                          Balance = Balance + @Amount
                          WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool IncrementBookingCount(int userId)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                          NumberOfBookings = NumberOfBookings + 1
                          WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }
        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, Role, FirstName, LastName, 
                        Balance, DateCreated, LastLogin, IsLocked, NumberOfBookings
                        FROM Users WHERE DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            UserRole = (User.Role)reader.GetInt32(2),
                            FirstName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            LastName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Balance = reader.GetDecimal(5),
                            DateCreated = reader.GetDateTime(6),
                            LastLogin = reader.IsDBNull(7) ? null : reader.GetDateTime(7),
                            IsLocked = reader.GetBoolean(8),
                            NumberOfBookings = reader.GetInt32(9)
                        });
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return users;
        }

        // Get user by ID
        public User GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, Role, Balance, FirstName, LastName, 
                               DateCreated, LastLogin, IsLocked, NumberOfBookings 
                               FROM Users WHERE Id = @Id AND DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                UserRole = (User.Role)reader.GetInt32(2),
                                Balance = reader.GetDecimal(3),
                                FirstName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                LastName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                DateCreated = reader.GetDateTime(6),
                                LastLogin = reader.IsDBNull(7) ? null : reader.GetDateTime(7),
                                IsLocked = reader.GetBoolean(8),
                                NumberOfBookings = reader.GetInt32(9)
                            };
                        }
                    }
                }
                return null;
            }
            finally { CloseConnection(); }
        }

        // Add a new user (for admins)
        public bool Add(User user, int adminId)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Users 
                       (Username, PasswordHash, Role, FirstName, LastName, CreatedByAdminId) 
                       VALUES 
                       (@Username, @PasswordHash, @Role, @FirstName, @LastName, @AdminId)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", PasswordHelper.HashPassword(user.PasswordHash));
                    cmd.Parameters.AddWithValue("@Role", (int)user.UserRole);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AdminId", adminId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                CloseConnection();
            }
        }
        // Update user (e.g., lock/unlock, update balance)
        public bool Update(User user)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                               Username = @Username,
                               FirstName = @FirstName,
                               LastName = @LastName,
                               IsLocked = @IsLocked,
                               Balance = @Balance
                               WHERE Id = @Id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsLocked", user.IsLocked);
                    cmd.Parameters.AddWithValue("@Balance", user.Balance);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        // Soft delete (set DeletedAt timestamp)
        public bool Delete(int userId)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Users SET DeletedAt = GETUTCDATE() WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        // Check if username exists
        public bool UsernameExists(string username)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND DeletedAt IS NULL";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        // Update last login time
        public void UpdateLastLogin(int userId)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Users SET LastLogin = GETUTCDATE() WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { CloseConnection(); }
        }
    }
}