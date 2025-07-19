namespace FlightBookingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public enum Role
        {
            Admin = 0,
            User = 1
        }
        public Role UserRole { get; set; }
        public decimal Balance { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int NumberOfBookings { get; set; } = 0;
        public int? CreatedByAdminId { get; set; }
    }
}