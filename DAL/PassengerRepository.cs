using FlightBookingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FlightBookingSystem.DAL
{
    public class PassengerRepository : DbHelper, IPassengerRepository
    {
        public bool Add(Passenger passenger)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Passengers 
                                (FirstName, LastName, PassportNumber, Nationality, Email, Phone, DateOfBirth)
                                VALUES 
                                (@FirstName, @LastName, @PassportNumber, @Nationality, @Email, @Phone, @DateOfBirth);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                    cmd.Parameters.AddWithValue("@PassportNumber", passenger.PassportNumber);
                    cmd.Parameters.AddWithValue("@Nationality", passenger.Nationality);
                    cmd.Parameters.AddWithValue("@Email", passenger.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", passenger.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", passenger.DateOfBirth);

                    passenger.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    return passenger.Id > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public bool Delete(int id)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Passengers SET DeletedAt = GETUTCDATE() 
                               WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<Passenger> GetAll()
        {
            List<Passenger> passengers = new List<Passenger>();
            try
            {
                OpenConnection();
                string query = @"SELECT * FROM Passengers WHERE DeletedAt IS NULL";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passengers.Add(MapPassengerFromReader(reader));
                    }
                }
            }
            finally { CloseConnection(); }
            return passengers;
        }

        public Passenger GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT * FROM Passengers 
                               WHERE Id = @Id AND DeletedAt IS NULL";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapPassengerFromReader(reader);
                        }
                    }
                }
                return null;
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<Passenger> GetPassengersByBooking(int bookingId)
        {
            List<Passenger> passengers = new List<Passenger>();
            try
            {
                OpenConnection();
                string query = @"SELECT p.* FROM Passengers p
                               JOIN BookingDetails bd ON p.Id = bd.PassengerId
                               WHERE bd.Id = @BookingId AND p.DeletedAt IS NULL";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            passengers.Add(MapPassengerFromReader(reader));
                        }
                    }
                }
            }
            finally { CloseConnection(); }
            return passengers;
        }

        public bool Update(Passenger passenger)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Passengers SET 
                               FirstName = @FirstName,
                               LastName = @LastName,
                               PassportNumber = @PassportNumber,
                               Nationality = @Nationality,
                               Email = @Email,
                               Phone = @Phone,
                               DateOfBirth = @DateOfBirth
                               WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", passenger.Id);
                    cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                    cmd.Parameters.AddWithValue("@PassportNumber", passenger.PassportNumber);
                    cmd.Parameters.AddWithValue("@Nationality", passenger.Nationality);
                    cmd.Parameters.AddWithValue("@Email", passenger.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", passenger.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", passenger.DateOfBirth);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        private Passenger MapPassengerFromReader(SqlDataReader reader)
        {
            return new Passenger
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                PassportNumber = reader.GetString(reader.GetOrdinal("PassportNumber")),
                Nationality = reader.GetString(reader.GetOrdinal("Nationality")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"))
            };
        }
    }
}