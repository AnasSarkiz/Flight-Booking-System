using System;
using System.Windows.Forms;
using FlightBookingSystem.Controls;
using FlightBookingSystem.Models;

namespace FlightBookingSystem
{
    public partial class MainForm : Form
    {
        private UserControl currentView;

        public MainForm()
        {
            InitializeComponent();

            // Wire up events for the designer-created navbar
            navbarControl.HomeClicked += (s, e) => ShowHomeView();
            navbarControl.SearchFlightsClicked += (s, e) => ShowSearchFlightsView();
            navbarControl.BookingsClicked += (s, e) => ShowBookingsView();
            navbarControl.LogoutClicked += (s, e) => Logout();

            ShowHomeView();
        }

        private void ShowHomeView()
        {
            var homeControl = new HomeControl();
            homeControl.ExploreFlightsClicked += (s, e) => ShowSearchFlightsView();
            SwitchView(homeControl);
        }

        private void ShowSearchFlightsView()
        {
            var searchControl = new SearchFlightsControl();
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
                ShowHomeView();
            };
            SwitchView(bookingControl);
        }

        private void ShowBookingsView()
        {
            var bookingsControl = new ManageBooking();
            SwitchView(bookingsControl);
        }

        private void SwitchView(UserControl newView)
        {
            // Remove current view if exists
            if (currentView != null)
            {
                mainContentPanel.Controls.Remove(currentView);
                currentView.Dispose();
            }

            // Add new view to the content panel
            currentView = newView;
            currentView.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(currentView);
            currentView.BringToFront();
        }

        private void Logout()
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}