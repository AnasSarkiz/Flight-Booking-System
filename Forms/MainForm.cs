﻿using System.Windows.Forms;
using System.Windows.Forms.Design;
using FlightBooker;
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
        private readonly IApiService _apiService;
        private readonly IPassengerRepository _passengerRepo;
        private readonly BookingService _bookingService;
        private readonly IActivityLogRepository _activityLogRepository;
        
        public MainForm(User user, IUserRepository userRepo, IBookingDetailsRepository bookingRepo,
              IPassengerRepository passengerRepo, IApiService apiService, IActivityLogRepository activityLogRepository) : this()
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (userRepo == null) throw new ArgumentNullException(nameof(userRepo));
            if (bookingRepo == null) throw new ArgumentNullException(nameof(bookingRepo));
            if (passengerRepo == null) throw new ArgumentNullException(nameof(passengerRepo));
            if (apiService == null) throw new ArgumentNullException(nameof(apiService));
            if (activityLogRepository == null) throw new ArgumentNullException(nameof(activityLogRepository));
            
            navbarControl = new Controls.NavbarControl(user.UserRole);
            this.FormClosing += MainForm_FormClosing;
            InitializeComponent();
            _currentUser = user;
            _userRepo = userRepo;
            _bookingRepo = bookingRepo;
            _passengerRepo = passengerRepo;
            _apiService = apiService;
            _activityLogRepository = activityLogRepository;
            _unsplashService = new UnsplashService();
            _userService = new UserService(_userRepo);
            _bookingService = new BookingService(_bookingRepo, _passengerRepo);

            navbarControl.HomeClicked += (s, e) => ShowHomeView();
            navbarControl.SearchFlightsClicked += (s, e) => ShowSearchFlightsView();
            navbarControl.BookingsClicked += (s, e) => ShowMyTripsView();
            navbarControl.ContactUsClicked += (s, e) => ShowContactUs();
            navbarControl.AboutUsClicked += (s, e) => ShowAboutUs();
            navbarControl.LogoutClicked += (s, e) => Logout();
            navbarControl.UserManagementClicked += (s, e) => ShowUserManagement();
            navbarControl.UserProfileClicked += (s, e) => ShowUserProfile();
            navbarControl.ActivityLogClicked += (s, e) => ShowActivityLog();
            navbarControl.MessagesClicked += (s, e) => ShowMessages();
            ShowHomeView();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void ShowActivityLog()
        {
            var activityLogControl = new ActivityLogControl(_activityLogRepository);
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
            BookingControl bookingControl = new BookingControl(flight, _currentUser, _passengerRepo, _bookingRepo, _userService);
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
            MyTripControl myTripsControl = new MyTripControl(_currentUser, _bookingRepo, _passengerRepo);
            myTripsControl.NewBookingClicked += (s, e) => ShowSearchFlightsView();
            myTripsControl.BookingManaged += async (s, bookingId) =>
            {
                var booking = _bookingService.GetBookingById(bookingId);
                if (booking != null)
                {
                    var dialog = new ManageBookingDialog(booking, _passengerRepo, _bookingRepo);
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
            HttpClient httpClient = new HttpClient();
            IContactService contactService = new ContactService(httpClient);

            ContactUsControl contactUsControl = new ContactUsControl(contactService, _currentUser);
            SwitchView(contactUsControl);
        }

        private void ShowAboutUs()
        {
            AboutUsControl aboutUsControl = new AboutUsControl(_apiService);
            SwitchView(aboutUsControl);
        }

        private void ShowMessages()
        {
            HttpClient httpClient = new HttpClient();
            IContactService contactService = new ContactService(httpClient);

            MessagesControl messagesControl = new MessagesControl(contactService);
            SwitchView(messagesControl);
        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Registration loginForm = new Registration();
                loginForm.Show();
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