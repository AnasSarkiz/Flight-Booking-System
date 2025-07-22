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
        public string FormattedTotalPrice => $"${TotalPrice:N0}";
    }
}