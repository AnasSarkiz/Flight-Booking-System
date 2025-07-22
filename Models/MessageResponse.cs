using System.Collections.Generic;

namespace FlightBookingSystem.Models
{
    public class MessageResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MessageData Data { get; set; }
    }

    public class MessageData
    {
        public List<ContactMessage> Messages { get; set; }
        public int TotalCount { get; set; }
        public MessageFilters Filters { get; set; }
    }

    public class MessageFilters
    {
        public string SystemId { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId { get; set; }
    }
}
