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
        private readonly UserService _userService;
        private readonly IBookingDetailsRepository _bookingRepo;
        private readonly IFlightRepository _flightRepo;
        private readonly IPassengerRepository _passengerRepo;
        private readonly BookingService _bookingService;

        public MainForm(User user, IUserRepository userRepo, IBookingDetailsRepository bookingRepo,
            IFlightRepository flightRepo, IPassengerRepository passengerRepo) : this()
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (userRepo == null) throw new ArgumentNullException(nameof(userRepo));
            if (bookingRepo == null) throw new ArgumentNullException(nameof(bookingRepo));
            if (flightRepo == null) throw new ArgumentNullException(nameof(flightRepo));
            if (passengerRepo == null) throw new ArgumentNullException(nameof(passengerRepo));

            {
                navbarControl = new Controls.NavbarControl(user.UserRole);
                InitializeComponent();
                _currentUser = user;
                _userRepo = userRepo;
                _bookingRepo = bookingRepo;
                _flightRepo = flightRepo;
                _passengerRepo = passengerRepo;
                _unsplashService = new UnsplashService();
                _userService = new UserService(_userRepo);
                _bookingService = new BookingService(_bookingRepo, _flightRepo, _passengerRepo);

                // Wire up navbar events
                navbarControl.HomeClicked += (s, e) => ShowHomeView();
                navbarControl.SearchFlightsClicked += (s, e) => ShowSearchFlightsView();
                navbarControl.BookingsClicked += (s, e) => ShowMyTripsView();
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
            UserProfileControl userProfileControl = new UserProfileControl(_userService, _currentUser);
            userProfileControl.BackRequested += (s, e) => ShowHomeView();
            SwitchView(userProfileControl);
        }

        private void ShowUserManagement()
        {
            if (_currentUser.UserRole == User.Role.Admin)
            {
                UserManagementControl userManagement = new UserManagementControl(_currentUser, _userRepo);
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
            var activityLogControl = new ActivityLogControl(_userRepo);
            SwitchView(activityLogControl);
        }

        private void ShowHomeView()
        {
            HomeControl homeControl = new HomeControl(_unsplashService);
            homeControl.ExploreFlightsClicked += (s, e) => ShowSearchFlightsView();
            homeControl.PromotionClicked += (s, city) =>
            {
                SearchFlightsControl searchControl = new SearchFlightsControl();
                searchControl.SetSearchDestination(city);
                ShowSearchFlightsView(searchControl);
            };
            SwitchView(homeControl);
        }

        private void ShowSearchFlightsView(SearchFlightsControl existingControl = null)
        {
            SearchFlightsControl searchControl = existingControl ?? new SearchFlightsControl();
            searchControl.BackToHomeClicked += (s, e) => ShowHomeView();
            searchControl.FlightSelected += (s, flight) => ShowBookingView(flight);
            SwitchView(searchControl);
        }

        private void ShowBookingView(Flight flight)
        {
            BookingControl bookingControl = new BookingControl(flight, _currentUser, _passengerRepo, _bookingRepo, _flightRepo);
            bookingControl.BackRequested += (s, e) => ShowSearchFlightsView();
            bookingControl.BookingConfirmed += (s, booking) =>
            {
                MessageBox.Show($"Booking confirmed! Your PNR is: {booking.PNR}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowMyTripsView();
            };
            SwitchView(bookingControl);
        }

        private void ShowMyTripsView()
        {
            MyTripControl myTripsControl = new MyTripControl(_currentUser, _bookingRepo, _passengerRepo, _flightRepo);
            myTripsControl.NewBookingClicked += (s, e) => ShowSearchFlightsView();
            myTripsControl.BookingManaged += async (s, bookingId) =>
            {
                var booking = _bookingService.GetBookingById(bookingId);
                if (booking != null)
                {
                    var dialog = new ManageBookingDialog(booking);
                    dialog.BookingCancelled += (ds, bid) =>
                    {
                        if (_bookingService.CancelBooking(bid))
                        {
                            MessageBox.Show("Booking cancelled successfully", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            myTripsControl.RefreshBookings();
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel booking", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    dialog.ShowDialog();
                }
            };
            SwitchView(myTripsControl);
        }

        private void ShowContactUs()
        {
            ContactUsControl contactUsControl = new ContactUsControl();
            SwitchView(contactUsControl);
        }

        private void ShowAboutUs()
        {
            AboutUsControl aboutUsControl = new AboutUsControl();
            SwitchView(aboutUsControl);
        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unsplashService?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}