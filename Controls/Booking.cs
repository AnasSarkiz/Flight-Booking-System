using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;

namespace FlightBookingSystem
{
    public partial class Booking : Form
    {
        private BookingDetails bookingDetails;

        public Booking(Flight selectedFlight)
        {
            InitializeComponent();
            InitializeBookingDetails(selectedFlight);
            InitializeUIComponents();
        }

        private void InitializeBookingDetails(Flight flight)
        {
            bookingDetails = new BookingDetails
            {
                Flight = flight,
                Passenger = new Passenger(),
                Payment = new PaymentInfo()
            };
        }

        private void InitializeUIComponents()
        {
            // Flight Information
            lblFlightNumber.Text = $"Flight: {bookingDetails.Flight.Airline}";
            lblRoute.Text = $"{bookingDetails.Flight.Origin} to {bookingDetails.Flight.Destination}";
            lblFlightData.Text = $"Departure: {bookingDetails.Flight.DepartureTime:g} | Arrival: {bookingDetails.Flight.ArrivalTime:g}";
            lblDuration.Text = $"Duration: {bookingDetails.Flight.FormattedDuration}";
            lblPrice.Text = $"Price: {bookingDetails.Flight.FormattedPrice}";

            // Set default date for date picker
            dtpDateOfBirth.Value = DateTime.Today.AddYears(-18);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                CollectPassengerInformation();
                CollectPaymentInformation();

                //var bookingService = new BookingService();
                //bookingService.ProcessBooking(bookingDetails);

                MessageBox.Show("Booking confirmed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing booking: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Add validation for other required fields
            return true;
        }

        private void CollectPassengerInformation()
        {
            bookingDetails.Passenger.FirstName = txtFirstName.Text;
            bookingDetails.Passenger.LastName = txtLastName.Text;
            bookingDetails.Passenger.PassportNumber = txtPassport.Text;
            bookingDetails.Passenger.Nationality = txtNationality.Text;
            bookingDetails.Passenger.Email = txtEmail.Text;
            bookingDetails.Passenger.Phone = txtPhone.Text;
            bookingDetails.Passenger.DateOfBirth = dtpDateOfBirth.Value;
        }

        private void CollectPaymentInformation()
        {
            bookingDetails.Payment.CardHolderName = txtCardName.Text;
            bookingDetails.Payment.CardNumber = txtCardNumber.Text;
            bookingDetails.Payment.ExpiryDate = txtExpiryDate.Text;
            bookingDetails.Payment.CVV = txtCVV.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}