using FlightBooker;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
namespace Flight_Booking_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Registration());
            var userRepo = new UserRepository();
            if (!userRepo.UsernameExists("admin"))
            {
                User adminUser = new User
                {
                    Username = "admin",
                    PasswordHash = "12345678", // This will be hashed
                    UserRole = User.Role.Admin,
                    FirstName = "System",
                    LastName = "Admin"
                };

                userRepo.Add(adminUser, 0); // 0 indicates system-created
            }
        }
    }
}
