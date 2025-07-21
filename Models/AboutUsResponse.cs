namespace FlightBookingSystem.Models
{
    public class AboutUsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public AboutUsData Data { get; set; }
    }

    public class AboutUsData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string System_version { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }
}