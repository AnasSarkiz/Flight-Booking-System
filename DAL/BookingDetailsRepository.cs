using FlightBookingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FlightBookingSystem.DAL
{
    public class BookingDetailsRepository : DbHelper, IBookingDetailsRepository
    {
        private readonly IActivityLogRepository _activityLogRepository;

        public BookingDetailsRepository(IActivityLogRepository activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }
        public bool Add(BookingDetails booking, bool logActivity = true)
        {
            try
            {
                OpenConnection();
                string query = @"
            INSERT INTO BookingDetails (
            FlightNumber, Airline, Origin, Destination,
            DestinationImageUrl, DepartureTime, ArrivalTime, 
            OriginalPrice, PassengerId, SeatClass, SeatNumber, 
            PNR, TotalPrice, BookedByUserId, Status, BookingDate, IsNonStop
            ) VALUES (
            @FlightNumber, @Airline, @Origin, @Destination,
            @DestinationImageUrl, @DepartureTime, @ArrivalTime, 
            @OriginalPrice, @PassengerId, @SeatClass, @SeatNumber, 
            @PNR, @TotalPrice, @BookedByUserId, @Status, @BookingDate, @IsNonStop
            );
            SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, connection))
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
                    bool isNonStop = booking.IsNonStop || (booking.Stops == null || !booking.Stops.Any());
                    cmd.Parameters.AddWithValue("@IsNonStop", isNonStop);
                    object result = cmd.ExecuteScalar();
                    booking.Id = Convert.ToInt32(result);

                    if (booking.Stops != null && booking.Stops.Any())
                    {
                        SaveBookingStops(booking.Id, booking.Stops);
                    }
                    if (logActivity && booking.BookedBuy?.Id > 0)
                    {
                        _activityLogRepository.Add(new ActivityLog
                        {
                            UserId = booking.BookedBuy.Id,
                            ActivityType = "Booking",
                            Description = $"Created booking with PNR: {booking.PNR}",
                            Timestamp = DateTime.UtcNow
                        });
                    }
                    return booking.Id > 0;
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Database error while creating booking: {sqlEx.Message}", sqlEx);
            }
            finally { CloseConnection(); }
        }

        public bool CancelBooking(int bookingId)
        {
            try
            {
                OpenConnection();

                BookingDetails booking = null;
                string getQuery = @"SELECT bd.Id, bd.PNR, bd.BookedByUserId, u.Username, 
                          p.Id AS PassengerId, p.FirstName, p.LastName
                          FROM BookingDetails bd
                          JOIN Users u ON bd.BookedByUserId = u.Id
                          JOIN Passengers p ON bd.PassengerId = p.Id
                          WHERE bd.Id = @Id AND bd.DeletedAt IS NULL";

                using (SqlCommand getCmd = new SqlCommand(getQuery, connection))
                {
                    getCmd.Parameters.AddWithValue("@Id", bookingId);
                    using (SqlDataReader reader = getCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new BookingDetails
                            {
                                Id = reader.GetInt32(0),
                                PNR = reader.GetString(1),
                                BookedBuy = new User
                                {
                                    Id = reader.GetInt32(2),
                                    Username = reader.GetString(3)
                                },
                                Passenger = new Passenger  // Initialize the required Passenger property
                                {
                                    Id = reader.GetInt32(4),
                                    FirstName = reader.GetString(5),
                                    LastName = reader.GetString(6)
                                }
                            };
                        }
                    }
                }

                if (booking != null)
                {
                    string updateQuery = @"UPDATE BookingDetails 
                               SET Status = 'Cancelled', DeletedAt = GETUTCDATE()
                               WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", bookingId);
                        var result = cmd.ExecuteNonQuery() > 0;

                        if (result)
                        {
                            _activityLogRepository.Add(new ActivityLog
                            {
                                UserId = booking.BookedBuy.Id,
                                ActivityType = "BookingCancellation",
                                Description = $"Cancelled booking with PNR: {booking.PNR}",
                                Timestamp = DateTime.UtcNow
                            });
                        }
                        return result;
                    }
                }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool Delete(int id)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE BookingDetails SET DeletedAt = GETUTCDATE() 
                               WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<BookingDetails> GetAll()
        {
            List<BookingDetails> bookings = new List<BookingDetails>();
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
                bd.IsNonStop,
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
            JOIN Users u ON bd.BookedByUserId = u.Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var booking = MapBookingFromReader(reader, includeStops: false);
                        bookings.Add(booking);
                    }
                }

                foreach (var booking in bookings)
                {
                    if (!booking.IsNonStop)
                    {
                        booking.Stops = GetBookingStops(booking.Id);
                    }
                    else
                    {
                        booking.Stops = new List<FlightStop>();
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
                    bd.IsNonStop,
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

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
                    bd.IsNonStop,
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

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PNR", pnr);
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
            List<BookingDetails> bookings = new List<BookingDetails>();
            SqlConnection conn = null;
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(connection.ConnectionString);
                conn.Open();

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
            bd.IsNonStop,
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
       WHERE bd.BookedByUserId = @UserId 
                AND (bd.DeletedAt IS NULL OR bd.Status = 'Cancelled')
                ORDER BY bd.BookingDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        var booking = MapBookingFromReader(reader);

                        if (!booking.IsNonStop)
                        {
                            booking.Stops = GetBookingStops(booking.Id);
                        }
                        else
                        {
                            booking.Stops = new List<FlightStop>();
                        }

                        bookings.Add(booking);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                reader?.Close();
                reader?.Dispose();
                conn?.Dispose();
            }

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
                DestinationImageUrl = @DestinationImageUrl,
                SeatClass = @SeatClass,
                SeatNumber = @SeatNumber,
                PNR = @PNR,
                TotalPrice = @TotalPrice,
                Status = @Status,
                IsNonStop = @IsNonStop
                WHERE Id = @Id AND DeletedAt IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FlightNumber", booking.FlightNumber);
                    cmd.Parameters.AddWithValue("@Airline", booking.Airline);
                    cmd.Parameters.AddWithValue("@Origin", booking.Origin);
                    cmd.Parameters.AddWithValue("@Destination", booking.Destination);
                    cmd.Parameters.AddWithValue("@DepartureTime", booking.DepartureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", booking.ArrivalTime);
                    cmd.Parameters.AddWithValue("@OriginalPrice", booking.OriginalPrice);
                    cmd.Parameters.AddWithValue("@PassengerId", booking.Passenger.Id);
                    cmd.Parameters.AddWithValue("@SeatClass", booking.SeatClass);
                    cmd.Parameters.AddWithValue("@SeatNumber", booking.SeatNumber);
                    cmd.Parameters.AddWithValue("@PNR", booking.PNR);
                    cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
                    cmd.Parameters.AddWithValue("@Status", booking.Status ?? "Confirmed");
                    cmd.Parameters.AddWithValue("@Id", booking.Id);
                    cmd.Parameters.AddWithValue("@DestinationImageUrl", (object)booking.DestinationImageUrl ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsNonStop", booking.IsNonStop);


                    if (!booking.IsNonStop && booking.Stops.Any())
                    {
                        SaveBookingStops(booking.Id, booking.Stops);
                    }
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            finally { CloseConnection(); }
        }

        private BookingDetails MapBookingFromReader(SqlDataReader reader, bool includeStops = true)
        {
            BookingDetails booking = new BookingDetails
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
                IsNonStop = reader.GetBoolean(reader.GetOrdinal("IsNonStop")),
                Stops = new List<FlightStop>(),
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
            if (includeStops && !booking.IsNonStop)
            {
                try
                {
                    booking.Stops = GetBookingStops(booking.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading stops: {ex.Message}");
                    booking.Stops = new List<FlightStop>();
                }
            }

            return booking;
        }
        private List<FlightStop> GetBookingStops(int bookingId)
        {
            var stops = new List<FlightStop>();
            try
            {
                OpenConnection();
                string query = @"SELECT Airport, AirportCode, LayoverDuration 
                FROM BookingStops WHERE BookingId = @BookingId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                stops.Add(new FlightStop
                                {
                                    Airport = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                                    AirportCode = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    LayoverDuration = reader.IsDBNull(2) ? TimeSpan.Zero : TimeSpan.FromTicks(reader.GetInt64(2))
                                });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error parsing stop: {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting stops: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return stops;
        }
        private void SaveBookingStops(int bookingId, List<FlightStop> stops)
        {
            try
            {
                OpenConnection();

                string deleteQuery = "DELETE FROM BookingStops WHERE BookingId = @BookingId";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);
                    cmd.ExecuteNonQuery();
                }

                if (stops.Any())
                {
                    string insertQuery = @"INSERT INTO BookingStops 
                                 (BookingId, Airport, AirportCode, LayoverDuration)
                                 VALUES (@BookingId, @Airport, @AirportCode, @LayoverDuration)";

                    foreach (var stop in stops)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@BookingId", bookingId);
                            cmd.Parameters.AddWithValue("@Airport", stop.Airport);
                            cmd.Parameters.AddWithValue("@AirportCode", stop.AirportCode);
                            cmd.Parameters.AddWithValue("@LayoverDuration", stop.LayoverDuration.Ticks);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
        }
    }
    }