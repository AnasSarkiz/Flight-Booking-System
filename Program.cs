using FlightBooker;
using FlightBookingSystem;
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
            
        }
    }
}
