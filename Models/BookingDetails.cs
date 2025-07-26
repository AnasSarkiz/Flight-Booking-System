namespace FlightBookingSystem.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal OriginalPrice { get; set; }
        public required Passenger Passenger { get; set; }
        public string SeatClass { get; set; }
        public string SeatNumber { get; set; }
        public string PNR { get; set; }
        public string DestinationImageUrl { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public User BookedBuy { get; set; }
        public string Status { get; set; }
        public bool IsNonStop { get; set; } = true;
        public List<FlightStop> Stops { get; set; } = new List<FlightStop>();

        public int StopCount => IsNonStop ? 0 : Stops.Count;
        public string FormattedTotalPrice => $"${TotalPrice:N0}";

        public string RouteSummary
        {
            get
            {
                if (IsNonStop)
                    return $"{Origin} → {Destination}";

                var stopCodes = Stops.Select(s => s.AirportCode);
                return $"{Origin} → {string.Join(" → ", stopCodes)} → {Destination}";
            }
        }
    }

    public class FlightStop
    {
        public string Airport { get; set; }
        public string AirportCode { get; set; }
        public TimeSpan LayoverDuration { get; set; }
    }
}