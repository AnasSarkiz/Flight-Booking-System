using System.Windows.Forms;
using FlightBookingSystem.Controls;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using Microsoft.Data.SqlClient;

namespace FlightBookingSystem
{
    public partial class MainForm : Form
    {
        private UserControl currentView;
        private readonly UnsplashService _unsplashService;
        private readonly User _currentUser;
        private readonly IUserRepository _userRepo;
        public MainForm(User user, IUserRepository userRepo) : this()
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (userRepo == null) throw new ArgumentNullException(nameof(userRepo));
            {
                InitializeComponent();
                _currentUser = user;
                _userRepo = userRepo;
                _unsplashService = new UnsplashService();
                navbarControl.HomeClicked += (s, e) => ShowHomeView();
                navbarControl.SearchFlightsClicked += (s, e) => ShowSearchFlightsView();
                navbarControl.BookingsClicked += (s, e) => ShowBookingsView();
                navbarControl.ContactUsClicked += (s, e) => ShowContactUs();
                navbarControl.AboutUsClicked += (s, e) => ShowAboutUs();
                navbarControl.LogoutClicked += (s, e) => Logout();
                navbarControl.UserManagementClicked += (s, e) => ShowUserManagement();
                navbarControl.UserProfileClicked += (s, e) => ShowUserProfile();
                navbarControl.ActivityLogClicked += (s, e) => ShowActivityLog();

                ShowHomeView();
            }
        }

        private void ShowUserProfile()
        {
            var userProfileControl = new UserProfileControl();
            SwitchView(userProfileControl);
        }
        private void ShowUserManagement()
        {
            if (_currentUser.UserRole == User.Role.Admin)
            {
                var userManagement = new UserManagementControl(_currentUser, _userRepo);
                SwitchView(userManagement);
            }
            else
            {
                MessageBox.Show("Admin access required.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ShowActivityLog()
        {
            var activityLogControl = new ActivityLogControl();
            SwitchView(activityLogControl);
        }

        private void ShowHomeView()
        {
            var homeControl = new HomeControl(_unsplashService);
            homeControl.ExploreFlightsClicked += (s, e) => ShowSearchFlightsView();
            homeControl.PromotionClicked += (s, city) =>
            {
                var searchControl = new SearchFlightsControl();
                searchControl.SetSearchDestination(city);
                ShowSearchFlightsView(searchControl);
            };
            SwitchView(homeControl);
        }

        private void ShowSearchFlightsView(SearchFlightsControl existingControl = null)
        {
            var searchControl = existingControl ?? new SearchFlightsControl();
            searchControl.BackToHomeClicked += (s, e) => ShowHomeView();
            searchControl.FlightSelected += (s, flight) => ShowBookingView(flight);
            SwitchView(searchControl);
        }

        private void ShowBookingView(Flight flight)
        {
            var bookingControl = new BookingControl(flight, _currentUser);
            bookingControl.BackRequested += (s, e) => ShowSearchFlightsView();
            bookingControl.BookingConfirmed += (s, booking) =>
            {
                MessageBox.Show($"Booking confirmed! Your PNR is: {booking.PNR}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowBookingsView();
            };
            SwitchView(bookingControl);
        }

        private void ShowBookingsView()
        {
            var bookingsControl = new ManageBooking();
            SwitchView(bookingsControl);
        }

        private void ShowContactUs()
        {
            var contactUsControl = new ContactUsControl();
            SwitchView(contactUsControl);
        }

        private void ShowAboutUs()
        {
            var aboutUsControl = new AboutUsControl();
            SwitchView(aboutUsControl);
        }

        private void Logout()
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SwitchView(UserControl newView)
        {
            if (currentView != null)
            {
                mainContentPanel.Controls.Remove(currentView);
                currentView.Dispose();
            }

            currentView = newView;
            currentView.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(currentView);
            currentView.BringToFront();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unsplashService?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}