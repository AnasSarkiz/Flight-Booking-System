
using System;

namespace FlightBookingSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public string SeatClass { get; set; }
        public string DestinationImageUrl { get; set; }
        public string AirlineLogoUrl { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Stops { get; set; }
        public string FormattedDuration => $"{Duration.Hours}h {Duration.Minutes}m";
        public string FormattedPrice => $"${Price:N0}";

    }
   
}