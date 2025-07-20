using FlightBookingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FlightBookingSystem.DAL
{
    public class BookingDetailsRepository : DbHelper, IBookingDetailsRepository
    {
        public bool Add(BookingDetails booking)
        {
            try
            {
                OpenConnection();
                string query = @"
                INSERT INTO BookingDetails (
                 FlightNumber, Airline, Origin, Destination,
                 DestinationImageUrl, DepartureTime, ArrivalTime, 
                  OriginalPrice, PassengerId, SeatClass, SeatNumber, 
                  PNR, TotalPrice, BookedByUserId, Status, BookingDate
                    ) VALUES (
                   @FlightNumber, @Airline, @Origin, @Destination,
                      @DestinationImageUrl, @DepartureTime, @ArrivalTime, 
                      @OriginalPrice, @PassengerId, @SeatClass, @SeatNumber, 
                       @PNR, @TotalPrice, @BookedByUserId, @Status, @BookingDate
                    );
                    SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FlightNumber", booking.FlightNumber);
                    cmd.Parameters.AddWithValue("@Airline", booking.Airline);
                    cmd.Parameters.AddWithValue("@Origin", booking.Origin);
                    cmd.Parameters.AddWithValue("@Destination", booking.Destination);
                    cmd.Parameters.AddWithValue("@DepartureTime", booking.DepartureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", booking.ArrivalTime);
                    cmd.Parameters.AddWithValue("@OriginalPrice", booking.OriginalPrice);
                    cmd.Parameters.AddWithValue("@DestinationImageUrl", (object)booking.DestinationImageUrl ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PassengerId", booking.Passenger.Id);
                    cmd.Parameters.AddWithValue("@SeatClass", booking.SeatClass);
                    cmd.Parameters.AddWithValue("@SeatNumber", booking.SeatNumber);
                    cmd.Parameters.AddWithValue("@PNR", booking.PNR);
                    cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
                    cmd.Parameters.AddWithValue("@BookedByUserId", booking.BookedBuy.Id);
                    cmd.Parameters.AddWithValue("@Status", booking.Status ?? "Confirmed");
                    cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    try
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            booking.Id = Convert.ToInt32(result);
                            return booking.Id > 0;
                        }
                        return false;
                    }
                    catch (SqlException sqlEx)
                    {
                        // Log detailed SQL error
                        Console.WriteLine($"SQL Error: {sqlEx.Message}");
                        Console.WriteLine($"Procedure: {sqlEx.Procedure}");
                        Console.WriteLine($"Line Number: {sqlEx.LineNumber}");
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log general error
                Console.WriteLine($"Error in Add booking: {ex.Message}");
                throw;
            }
            finally { CloseConnection(); }
        }
        public bool CancelBooking(int bookingId)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE BookingDetails 
                               SET Status = 'Cancelled', DeletedAt = GETUTCDATE()
                               WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", bookingId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public bool Delete(int id)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE BookingDetails SET DeletedAt = GETUTCDATE() 
                               WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<BookingDetails> GetAll()
        {
            var bookings = new List<BookingDetails>();
            try
            {
                OpenConnection();
                string query = @"
                SELECT 
                    bd.Id, 
                    bd.FlightNumber AS BookingFlightNumber, 
                    bd.Airline AS BookingAirline, 
                    bd.Origin AS BookingOrigin, 
                    bd.Destination AS BookingDestination,
                    bd.DepartureTime AS BookingDepartureTime, 
                    bd.ArrivalTime AS BookingArrivalTime, 
                    bd.OriginalPrice AS BookingOriginalPrice,
                    bd.SeatClass AS BookingSeatClass, 
                    bd.SeatNumber, 
                    bd.PNR, 
                    bd.TotalPrice,
                    bd.DestinationImageUrl,
                    bd.BookingDate, 
                    bd.Status,
                    p.Id AS PassengerId, 
                    p.FirstName, 
                    p.LastName, 
                    p.PassportNumber, 
                    p.Nationality,
                    p.Email, 
                    p.Phone, 
                    p.DateOfBirth,
                    u.Id AS UserId, 
                    u.Username, 
                    u.FirstName AS UserFirstName, 
                    u.LastName AS UserLastName
                FROM BookingDetails bd
                JOIN Passengers p ON bd.PassengerId = p.Id
                JOIN Users u ON bd.BookedByUserId = u.Id
                WHERE bd.DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(MapBookingFromReader(reader));
                    }
                }
            }
            finally { CloseConnection(); }
            return bookings;
        }

        public BookingDetails GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"
                SELECT 
                    bd.Id, 
                    bd.FlightNumber AS BookingFlightNumber, 
                    bd.Airline AS BookingAirline, 
                    bd.Origin AS BookingOrigin, 
                    bd.Destination AS BookingDestination,
                    bd.DepartureTime AS BookingDepartureTime, 
                    bd.ArrivalTime AS BookingArrivalTime, 
                    bd.OriginalPrice AS BookingOriginalPrice,
                    bd.SeatClass AS BookingSeatClass, 
                    bd.SeatNumber, 
                    bd.DestinationImageUrl,
                    bd.PNR, 
                    bd.TotalPrice,
                    bd.BookingDate, 
                    bd.Status,
                    p.Id AS PassengerId, 
                    p.FirstName, 
                    p.LastName, 
                    p.PassportNumber, 
                    p.Nationality,
                    p.Email, 
                    p.Phone, 
                    p.DateOfBirth,
                    u.Id AS UserId, 
                    u.Username, 
                    u.FirstName AS UserFirstName, 
                    u.LastName AS UserLastName
                FROM BookingDetails bd
                JOIN Passengers p ON bd.PassengerId = p.Id
                JOIN Users u ON bd.BookedByUserId = u.Id
                WHERE bd.Id = @Id AND bd.DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapBookingFromReader(reader);
                        }
                    }
                }
                return null;
            }
            finally { CloseConnection(); }
        }

        public BookingDetails GetByPNR(string pnr)
        {
            try
            {
                OpenConnection();
                string query = @"
                SELECT 
                    bd.Id, 
                    bd.FlightNumber AS BookingFlightNumber, 
                    bd.Airline AS BookingAirline, 
                    bd.Origin AS BookingOrigin, 
                    bd.Destination AS BookingDestination,
                    bd.DepartureTime AS BookingDepartureTime, 
                    bd.ArrivalTime AS BookingArrivalTime, 
                    bd.OriginalPrice AS BookingOriginalPrice,
                    bd.DestinationImageUrl,
                    bd.SeatClass AS BookingSeatClass, 
                    bd.SeatNumber, 
                    bd.PNR, 
                    bd.TotalPrice,
                    bd.BookingDate, 
                    bd.Status,
                    p.Id AS PassengerId, 
                    p.FirstName, 
                    p.LastName, 
                    p.PassportNumber, 
                    p.Nationality,
                    p.Email, 
                    p.Phone, 
                    p.DateOfBirth,
                    u.Id AS UserId, 
                    u.Username, 
                    u.FirstName AS UserFirstName, 
                    u.LastName AS UserLastName
                FROM BookingDetails bd
                JOIN Passengers p ON bd.PassengerId = p.Id
                JOIN Users u ON bd.BookedByUserId = u.Id
                WHERE bd.PNR = @PNR AND bd.DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PNR", pnr);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapBookingFromReader(reader);
                        }
                    }
                }
                return null;
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<BookingDetails> GetByUserId(int userId)
        {
            var bookings = new List<BookingDetails>();
            try
            {
                OpenConnection();
                string query = @"
                SELECT 
                    bd.Id, 
                    bd.FlightNumber AS BookingFlightNumber, 
                    bd.Airline AS BookingAirline, 
                    bd.Origin AS BookingOrigin, 
                    bd.Destination AS BookingDestination,
                    bd.DepartureTime AS BookingDepartureTime, 
                    bd.ArrivalTime AS BookingArrivalTime, 
                    bd.OriginalPrice AS BookingOriginalPrice,
                    bd.SeatClass AS BookingSeatClass, 
                    bd.DestinationImageUrl,
                    bd.SeatNumber, 
                    bd.PNR, 
                    bd.TotalPrice,
                    bd.BookingDate, 
                    bd.Status,
                    p.Id AS PassengerId, 
                    p.FirstName, 
                    p.LastName, 
                    p.PassportNumber, 
                    p.Nationality,
                    p.Email, 
                    p.Phone, 
                    p.DateOfBirth,
                    u.Id AS UserId, 
                    u.Username, 
                    u.FirstName AS UserFirstName, 
                    u.LastName AS UserLastName
                FROM BookingDetails bd
                JOIN Passengers p ON bd.PassengerId = p.Id
                JOIN Users u ON bd.BookedByUserId = u.Id
                WHERE bd.BookedByUserId = @UserId AND bd.DeletedAt IS NULL
                ORDER BY bd.BookingDate DESC";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(MapBookingFromReader(reader));
                        }
                    }
                }
            }
            finally { CloseConnection(); }
            return bookings;
        }

        public bool Update(BookingDetails booking)
        {
            try
            {
                OpenConnection();
                string query = @"
                UPDATE BookingDetails SET 
                    FlightNumber = @FlightNumber,
                    Airline = @Airline,
                    Origin = @Origin,
                    Destination = @Destination,
                    DepartureTime = @DepartureTime,
                    ArrivalTime = @ArrivalTime,
                    OriginalPrice = @OriginalPrice,
                    PassengerId = @PassengerId,
                    DestinationImageUrl = @DestinationImageUrl
                    SeatClass = @SeatClass,
                    SeatNumber = @SeatNumber,
                    PNR = @PNR,
                    TotalPrice = @TotalPrice,
                    Status = @Status
                WHERE Id = @Id AND DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    // Flight data
                    cmd.Parameters.AddWithValue("@FlightNumber", booking.FlightNumber);
                    cmd.Parameters.AddWithValue("@Airline", booking.Airline);
                    cmd.Parameters.AddWithValue("@Origin", booking.Origin);
                    cmd.Parameters.AddWithValue("@Destination", booking.Destination);
                    cmd.Parameters.AddWithValue("@DepartureTime", booking.DepartureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", booking.ArrivalTime);
                    cmd.Parameters.AddWithValue("@OriginalPrice", booking.OriginalPrice);

                    // Passenger and user
                    cmd.Parameters.AddWithValue("@PassengerId", booking.Passenger.Id);

                    // Booking details
                    cmd.Parameters.AddWithValue("@SeatClass", booking.SeatClass);
                    cmd.Parameters.AddWithValue("@SeatNumber", booking.SeatNumber);
                    cmd.Parameters.AddWithValue("@PNR", booking.PNR);
                    cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
                    cmd.Parameters.AddWithValue("@Status", booking.Status ?? "Confirmed");
                    cmd.Parameters.AddWithValue("@Id", booking.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        private BookingDetails MapBookingFromReader(SqlDataReader reader)
        {
            return new BookingDetails
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FlightNumber = reader.GetString(reader.GetOrdinal("BookingFlightNumber")),
                Airline = reader.GetString(reader.GetOrdinal("BookingAirline")),
                Origin = reader.GetString(reader.GetOrdinal("BookingOrigin")),
                Destination = reader.GetString(reader.GetOrdinal("BookingDestination")),
                DepartureTime = reader.GetDateTime(reader.GetOrdinal("BookingDepartureTime")),
                ArrivalTime = reader.GetDateTime(reader.GetOrdinal("BookingArrivalTime")),
                OriginalPrice = reader.GetDecimal(reader.GetOrdinal("BookingOriginalPrice")),
                DestinationImageUrl = reader.IsDBNull(reader.GetOrdinal("DestinationImageUrl")) ? null : reader.GetString(reader.GetOrdinal("DestinationImageUrl")),
                SeatClass = reader.GetString(reader.GetOrdinal("BookingSeatClass")),
                SeatNumber = reader.GetString(reader.GetOrdinal("SeatNumber")),
                PNR = reader.GetString(reader.GetOrdinal("PNR")),
                TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? "Confirmed" : reader.GetString(reader.GetOrdinal("Status")),
                Passenger = new Passenger
                {
                    Id = reader.GetInt32(reader.GetOrdinal("PassengerId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    PassportNumber = reader.GetString(reader.GetOrdinal("PassportNumber")),
                    Nationality = reader.GetString(reader.GetOrdinal("Nationality")),
                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"))
                },
                BookedBuy = new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    FirstName = reader.IsDBNull(reader.GetOrdinal("UserFirstName")) ? null : reader.GetString(reader.GetOrdinal("UserFirstName")),
                    LastName = reader.IsDBNull(reader.GetOrdinal("UserLastName")) ? null : reader.GetString(reader.GetOrdinal("UserLastName"))
                }
            };
        }
    }
}