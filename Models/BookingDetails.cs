using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingSystem.Models
{
    public class BookingDetails
    {
        public Flight Flight { get; set; }
        public required Passenger Passenger { get; set; }
        public required PaymentInfo Payment { get; set; }
        public string SeatClass { get; set; }
        public string SeatNumber { get; set; }
        public string PNR { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
