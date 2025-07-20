using FlightBookingSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class ManageBookingDialog : Form
    {
        private readonly BookingDetails _booking;

        public event EventHandler<int> BookingCancelled;

        public ManageBookingDialog(BookingDetails booking)
        {
            _booking = booking;
            InitializeComponent();
            InitializeBookingDetails();
            this.Text = $"Manage Booking - {_booking.PNR}";
        }

        private void InitializeBookingDetails()
        {
            // Parse airport codes from origin/destination (e.g., "Amsterdam (AMS)")
            string originCity = GetCityName(_booking.Origin);
            string originCode = GetAirportCode(_booking.Origin);
            string destCity = GetCityName(_booking.Destination);
            string destCode = GetAirportCode(_booking.Destination);

            // Set all labels with proper formatting
            lblFlightInfo.Text = $"{_booking.Airline} {_booking.FlightNumber}";
            lblRoute.Text = $"{originCity} ({originCode}) → {destCity} ({destCode})";

            lblDepartureInfo.Text = $"{_booking.DepartureTime:ddd, MMM dd yyyy hh:mm tt}";
            lblArrivalInfo.Text = $"{_booking.ArrivalTime:ddd, MMM dd yyyy hh:mm tt}";
            lblDuration.Text = $"Duration: {FormatDuration(_booking.ArrivalTime - _booking.DepartureTime)}";

            lblPassenger.Text = $"{_booking.Passenger.FirstName} {_booking.Passenger.LastName}";
            lblSeat.Text = $"Seat: {_booking.SeatNumber} ({_booking.SeatClass})";
            lblStatus.Text = $"Status: {_booking.Status}";
            lblStatus.ForeColor = _booking.Status == "Confirmed" ? Color.Green : Color.OrangeRed;

            lblPNR.Text = $"PNR: {_booking.PNR}";
            lblIssuedAt.Text = $"Issued at: {_booking.BookingDate:MMM dd, yyyy hh:mm tt}";
            lblPrice.Text = $"Total Paid: {_booking.FormattedTotalPrice}";
        }

        private string GetCityName(string airportInfo)
        {
            // Format: "City Name (CODE)" - extract city name
            int parenIndex = airportInfo.IndexOf('(');
            return parenIndex > 0 ? airportInfo.Substring(0, parenIndex).Trim() : airportInfo;
        }

        private string GetAirportCode(string airportInfo)
        {
            // Format: "City Name (CODE)" - extract code
            int parenIndex = airportInfo.IndexOf('(');
            if (parenIndex > 0 && airportInfo.EndsWith(")"))
            {
                return airportInfo.Substring(parenIndex + 1, airportInfo.Length - parenIndex - 2);
            }
            return airportInfo;
        }

        private string FormatDuration(TimeSpan duration)
        {
            return $"{duration.Hours}h {duration.Minutes}m";
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this booking?",
                                      "Confirm Cancellation",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BookingCancelled?.Invoke(this, _booking.Id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}