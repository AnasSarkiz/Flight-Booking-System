// FlightRepository.cs
using FlightBookingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FlightBookingSystem.DAL
{
    public class FlightRepository : DbHelper, IFlightRepository
    {
        public bool Add(Flight flight)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Flights 
                               (FlightNumber, Airline, Duration, Price, SeatClass, 
                                DestinationImageUrl, AirlineLogoUrl, Origin, 
                                Destination, DepartureTime, ArrivalTime, Stops)
                               VALUES 
                               (@FlightNumber, @Airline, @Duration, @Price, @SeatClass, 
                                @DestinationImageUrl, @AirlineLogoUrl, @Origin, 
                                @Destination, @DepartureTime, @ArrivalTime, @Stops);
                               SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                    cmd.Parameters.AddWithValue("@Airline", flight.Airline);
                    cmd.Parameters.AddWithValue("@Duration", flight.Duration);
                    cmd.Parameters.AddWithValue("@Price", flight.Price);
                    cmd.Parameters.AddWithValue("@SeatClass", flight.SeatClass);
                    cmd.Parameters.AddWithValue("@DestinationImageUrl", flight.DestinationImageUrl ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AirlineLogoUrl", flight.AirlineLogoUrl ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Origin", flight.Origin);
                    cmd.Parameters.AddWithValue("@Destination", flight.Destination);
                    cmd.Parameters.AddWithValue("@DepartureTime", flight.DepartureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", flight.ArrivalTime);
                    cmd.Parameters.AddWithValue("@Stops", flight.Stops);

                    flight.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    return flight.Id > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public bool Delete(int id)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Flights SET DeletedAt = GETUTCDATE() 
                               WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<Flight> GetAll()
        {
            var flights = new List<Flight>();
            try
            {
                OpenConnection();
                string query = @"SELECT * FROM Flights WHERE DeletedAt IS NULL";
                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        flights.Add(MapFlightFromReader(reader));
                    }
                }
            }
            finally { CloseConnection(); }
            return flights;
        }

        public Flight GetById(int id)
        {
            try
            {
                OpenConnection();
                string query = @"SELECT * FROM Flights 
                               WHERE Id = @Id AND DeletedAt IS NULL";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapFlightFromReader(reader);
                        }
                    }
                }
                return null;
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<Flight> GetFlightsByAirline(string airline)
        {
            var flights = new List<Flight>();
            try
            {
                OpenConnection();
                string query = @"SELECT * FROM Flights 
                               WHERE Airline = @Airline AND DeletedAt IS NULL";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Airline", airline);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            flights.Add(MapFlightFromReader(reader));
                        }
                    }
                }
            }
            finally { CloseConnection(); }
            return flights;
        }

        public IEnumerable<Flight> SearchFlights(string origin, string destination, DateTime departureDate)
        {
            var flights = new List<Flight>();
            try
            {
                OpenConnection();
                string query = @"SELECT * FROM Flights 
                               WHERE Origin LIKE @Origin + '%' 
                               AND Destination LIKE @Destination + '%'
                               AND CONVERT(DATE, DepartureTime) = @DepartureDate
                               AND DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Origin", origin);
                    cmd.Parameters.AddWithValue("@Destination", destination);
                    cmd.Parameters.AddWithValue("@DepartureDate", departureDate.Date);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            flights.Add(MapFlightFromReader(reader));
                        }
                    }
                }
            }
            finally { CloseConnection(); }
            return flights;
        }

        public bool Update(Flight flight)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Flights SET 
                               FlightNumber = @FlightNumber,
                               Airline = @Airline,
                               Duration = @Duration,
                               Price = @Price,
                               SeatClass = @SeatClass,
                               DestinationImageUrl = @DestinationImageUrl,
                               AirlineLogoUrl = @AirlineLogoUrl,
                               Origin = @Origin,
                               Destination = @Destination,
                               DepartureTime = @DepartureTime,
                               ArrivalTime = @ArrivalTime,
                               Stops = @Stops
                               WHERE Id = @Id AND DeletedAt IS NULL";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", flight.Id);
                    cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                    cmd.Parameters.AddWithValue("@Airline", flight.Airline);
                    cmd.Parameters.AddWithValue("@Duration", flight.Duration);
                    cmd.Parameters.AddWithValue("@Price", flight.Price);
                    cmd.Parameters.AddWithValue("@SeatClass", flight.SeatClass);
                    cmd.Parameters.AddWithValue("@DestinationImageUrl", flight.DestinationImageUrl ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AirlineLogoUrl", flight.AirlineLogoUrl ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Origin", flight.Origin);
                    cmd.Parameters.AddWithValue("@Destination", flight.Destination);
                    cmd.Parameters.AddWithValue("@DepartureTime", flight.DepartureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", flight.ArrivalTime);
                    cmd.Parameters.AddWithValue("@Stops", flight.Stops);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally { CloseConnection(); }
        }

        private Flight MapFlightFromReader(SqlDataReader reader)
        {
            return new Flight
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FlightNumber = reader.GetString(reader.GetOrdinal("FlightNumber")),
                Airline = reader.GetString(reader.GetOrdinal("Airline")),
                Duration = (TimeSpan)reader.GetValue(reader.GetOrdinal("Duration")),
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                SeatClass = reader.GetString(reader.GetOrdinal("SeatClass")),
                DestinationImageUrl = reader.IsDBNull(reader.GetOrdinal("DestinationImageUrl")) ? null : reader.GetString(reader.GetOrdinal("DestinationImageUrl")),
                AirlineLogoUrl = reader.IsDBNull(reader.GetOrdinal("AirlineLogoUrl")) ? null : reader.GetString(reader.GetOrdinal("AirlineLogoUrl")),
                Origin = reader.GetString(reader.GetOrdinal("Origin")),
                Destination = reader.GetString(reader.GetOrdinal("Destination")),
                DepartureTime = reader.GetDateTime(reader.GetOrdinal("DepartureTime")),
                ArrivalTime = reader.GetDateTime(reader.GetOrdinal("ArrivalTime")),
                Stops = reader.GetInt32(reader.GetOrdinal("Stops"))
            };
        }
    }
}