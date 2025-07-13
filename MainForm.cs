using System;
using System.Windows.Forms;
using FlightBookingSystem.Controls;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;

namespace FlightBookingSystem
{
    public partial class MainForm : Form
    {
        private UserControl currentView;
        private readonly UnsplashService _unsplashService;

        public MainForm()
        {
            InitializeComponent();
            _unsplashService = new UnsplashService();

            // Wire up navbar events
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
        private void ShowUserProfile()
        {
            var userProfileControl = new UserProfileControl();
            SwitchView(userProfileControl);
        }
        private void ShowUserManagement()
        {
            var userManagementControl = new UserManagementControl();
            SwitchView(userManagementControl);
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
            var bookingControl = new BookingControl(flight);
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

        partial void AdditionalDispose(bool disposing)
        {
            if (disposing)
            {
                _unsplashService?.Dispose();
            }
        }
    }
}