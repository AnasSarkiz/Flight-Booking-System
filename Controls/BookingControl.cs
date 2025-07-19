using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using Newtonsoft.Json;

namespace FlightBookingSystem.Controls
{
    public partial class BookingControl : UserControl
    {
        public event EventHandler<BookingDetails> BookingConfirmed;
        public event EventHandler BackRequested;

        private List<string> _nationalities;
        private readonly Flight _selectedFlight;
        private readonly User _currentUser;
        private BookingDetails _bookingDetails;

        public BookingControl(Flight flight, User user)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight));
            if (user == null) throw new ArgumentNullException(nameof(user));

            _selectedFlight = flight;
            _currentUser = user;

            InitializeComponent();
            InitializeBooking();
            WireUpEvents();
            LoadNationalities();
            UpdateBalanceDisplay();
        }

        private void UpdateBalanceDisplay()
        {
            lblBalance.Text = $"Available Balance: {_currentUser.Balance:C}";
            lblBalance.ForeColor = _currentUser.Balance >= _selectedFlight.Price ? Color.Green : Color.Red;
        }

        private void LoadNationalities()
        {
            try
            {
                string jsonPath = @"C:\Users\aness\Desktop\flightBooker\resources\countries.json";

                if (!File.Exists(jsonPath))
                {
                    throw new FileNotFoundException("Countries.json not found at: " + jsonPath);
                }

                string json = File.ReadAllText(jsonPath);
                var countries = JsonConvert.DeserializeObject<List<CountryData>>(json);

                _nationalities = countries
                    .Select(c => c.nationality)
                    .Distinct()
                    .OrderBy(n => n)
                    .ToList();

                cmbNationality.DropDownStyle = ComboBoxStyle.DropDown;
                cmbNationality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbNationality.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbNationality.DataSource = _nationalities;
            }
            catch (Exception ex)
            {
                _nationalities = new List<string>
                {
                    "American", "British", "Canadian", "French", "German", "Japanese"
                };

                cmbNationality.DataSource = _nationalities;
                MessageBox.Show($"Failed to load nationalities: {ex.Message}\nUsing default values instead.",
                              "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private class CountryData
        {
            public string num_code { get; set; }
            public string alpha_2_code { get; set; }
            public string alpha_3_code { get; set; }
            public string en_short_name { get; set; }
            public string nationality { get; set; }
        }

        private void InitializeBooking()
        {
            _bookingDetails = new BookingDetails
            {
                Flight = _selectedFlight,
                Passenger = new Passenger(),
                SeatNumber = GenerateRandomSeat(),
                PNR = GeneratePNR(),
                TotalPrice = _selectedFlight.Price,
                BookedBuy = _currentUser
            };

            lblSeatInfo.Text = $"Assigned Seat: {_bookingDetails.SeatNumber}";
            lblFlightInfo.Text = $"{_selectedFlight.Airline} • {_selectedFlight.FlightNumber}\n" +
                               $"{_selectedFlight.Origin} → {_selectedFlight.Destination}\n" +
                               $"{_selectedFlight.DepartureTime:ddd, MMM dd yyyy hh:mm tt}";
            lblTotalPrice.Text = $"Total Price: {_selectedFlight.FormattedPrice}";
        }

        private string GeneratePNR()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomSeat()
        {
            var random = new Random();
            int row = random.Next(1, 30);
            char seat = (char)('A' + random.Next(0, 6));
            return $"{row}{seat}";
        }

        private void WireUpEvents()
        {
            btnBack.Click += (s, e) => BackRequested?.Invoke(this, EventArgs.Empty);
            btnConfirm.Click += (s, e) => ProcessBooking();

            txtFirstName.TextChanged += (s, e) => _bookingDetails.Passenger.FirstName = txtFirstName.Text;
            txtLastName.TextChanged += (s, e) => _bookingDetails.Passenger.LastName = txtLastName.Text;
            txtPassport.TextChanged += (s, e) => _bookingDetails.Passenger.PassportNumber = txtPassport.Text;
            cmbNationality.SelectedIndexChanged += (s, e) => _bookingDetails.Passenger.Nationality = cmbNationality.SelectedItem?.ToString();
            txtEmail.TextChanged += (s, e) => _bookingDetails.Passenger.Email = txtEmail.Text;
            txtPhone.TextChanged += (s, e) => _bookingDetails.Passenger.Phone = txtPhone.Text;
            dtpDob.ValueChanged += (s, e) => _bookingDetails.Passenger.DateOfBirth = dtpDob.Value;
        }

        private void ProcessBooking()
        {
            if (!ValidateBooking()) return;

            if (_currentUser.Balance < _selectedFlight.Price)
            {
                MessageBox.Show($"Insufficient balance. Your balance is {_currentUser.Balance:C} but the flight costs {_selectedFlight.Price:C}.",
                              "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Confirm booking for {_selectedFlight.Price:C}? This amount will be deducted from your balance.",
                                             "Confirm Booking",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                BookingConfirmed?.Invoke(this, _bookingDetails);
            }
        }

        private bool ValidateBooking()
        {
            if (string.IsNullOrWhiteSpace(_bookingDetails.Passenger.FirstName))
            {
                MessageBox.Show("First name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(_bookingDetails.Passenger.LastName))
            {
                MessageBox.Show("Last name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}