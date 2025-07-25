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
        private readonly IActivityLogRepository _activityLogRepository;

        public UserRepository(IActivityLogRepository activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }
        public User Authenticate(string username, string password)
        {
            try
            {
                OpenConnection();

                string query = @"SELECT Id, Username, PasswordHash, Role, Balance, 
                       FirstName, LastName, DateCreated, LastLogin, IsLocked, 
                       NumberOfBookings, CreatedByAdminId, FailedLoginAttempts, LockoutEnd
                       FROM Users 
                       WHERE Username = @Username AND DeletedAt IS NULL";

                User user = null;
                int currentAttempts = 0;

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                PasswordHash = reader.GetString(2),
                                UserRole = (User.Role)reader.GetInt32(3),
                                Balance = reader.GetDecimal(4),
                                FirstName = reader.IsDBNull(5) ? null : reader.GetString(5),
                                LastName = reader.IsDBNull(6) ? null : reader.GetString(6),
                                DateCreated = reader.GetDateTime(7),
                                LastLogin = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                                IsLocked = reader.GetBoolean(9),
                                NumberOfBookings = reader.GetInt32(10),
                                CreatedByAdminId = reader.IsDBNull(11) ? null : (int?)reader.GetInt32(11),
                                FailedLoginAttempts = reader.GetInt32(12),
                                LockoutEnd = reader.IsDBNull(13) ? null : (DateTime?)reader.GetDateTime(13)
                            };
                            currentAttempts = reader.GetInt32(12);
                        }
                    } 
                }

                if (user == null)
                {
                    throw new Exception("Username not found.");
                }

                if (user.IsLocked && user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow)
                {
                    throw new Exception($"Account is temporarily locked. Please try again after {user.LockoutEnd.Value.Subtract(DateTime.UtcNow):mm\\:ss} minutes.");
                }

                if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
                {
                    currentAttempts++;
                    UpdateFailedAttempts(user.Id, currentAttempts);

                    int attemptsLeft = 4 - currentAttempts;
                    if (attemptsLeft <= 0)
                    {
                        LockAccount(user.Id);
                        throw new Exception("Too many failed attempts. Account locked for 1 minute.");
                    }
                    throw new Exception($"Invalid password. {attemptsLeft} attempts remaining.");
                }

                ResetFailedAttempts(user.Id);
                _activityLogRepository.Add(new ActivityLog
                {
                    UserId = user.Id,
                    ActivityType = "Login",
                    Description = "Successful login",
                    Timestamp = DateTime.UtcNow
                });
                return user;
            }
            finally
            {
                CloseConnection();
            }
        }

        private void UpdateFailedAttempts(int userId, int attempts)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                      FailedLoginAttempts = @Attempts
                      WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Attempts", attempts);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        private void LockAccount(int userId)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                      IsLocked = 1,
                      LockoutEnd = DATEADD(minute, 1, GETUTCDATE())
                      WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }
     

        private void ResetFailedAttempts(int userId)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Users SET 
                      FailedLoginAttempts = 0,
                      IsLocked = 0,
                      LockoutEnd = NULL
                      WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
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

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
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

        public User GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT Id, Username, Role, Balance, FirstName, LastName, 
                               DateCreated, LastLogin, IsLocked, NumberOfBookings 
                               FROM Users WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
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

        public bool Add(User user, int adminId)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Users 
                       (Username, PasswordHash, Role, FirstName, LastName, CreatedByAdminId) 
                       VALUES 
                       (@Username, @PasswordHash, @Role, @FirstName, @LastName, @AdminId)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", PasswordHelper.HashPassword(user.PasswordHash));
                    cmd.Parameters.AddWithValue("@Role", (int)user.UserRole);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AdminId", adminId);

                    var result= cmd.ExecuteNonQuery() > 0;
                    if (result)
                    {
                       
                        _activityLogRepository.Add(new ActivityLog
                        {
                            UserId = adminId, 
                            ActivityType = "UserManagement",
                            Description = $"Created new user: {user.Username}",
                            Timestamp = DateTime.UtcNow
                        });
                    }
                    return result;
                
            }
            }
            finally
            {
                CloseConnection();
            }
        }

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

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsLocked", user.IsLocked);
                    cmd.Parameters.AddWithValue("@Balance", user.Balance);

                    var result = cmd.ExecuteNonQuery() > 0;
                    if (result)
                    {
                        _activityLogRepository.Add(new ActivityLog
                        {
                            UserId = user.Id,
                            ActivityType = "ProfileUpdate",
                            Description = "Updated profile information",
                            Timestamp = DateTime.UtcNow
                        });
                    }
                    return result;
                }

            }
            finally { CloseConnection(); }
        }

        public bool Delete(int userId)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Users SET DeletedAt = GETUTCDATE() WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public bool UsernameExists(string username)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND DeletedAt IS NULL";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public void UpdateLastLogin(int userId)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Users SET LastLogin = GETUTCDATE() WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            finally { CloseConnection(); }
        }
    }
}