using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using Newtonsoft.Json;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Services;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Transactions;
using System.Text.RegularExpressions;
using System.Net.Mail;


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
        private readonly IPassengerRepository _passengerRepository;
        private readonly IBookingDetailsRepository _bookingRepository;
        private readonly BookingService _bookingService;
        private readonly UserService _userService;
        public bool IsNonStop { get; set; }
        public string StopsInfo { get; set; }
        public BookingControl(Flight flight, User user,
                         IPassengerRepository passengerRepository,
                         IBookingDetailsRepository bookingRepository,
                         UserService userService)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight));
            if (user == null) throw new ArgumentNullException(nameof(user));

            _selectedFlight = flight;
            _currentUser = user;
            _userService = userService;
            _passengerRepository = passengerRepository;
            _bookingRepository = bookingRepository;
            _bookingService = new BookingService(bookingRepository, passengerRepository);

            InitializeComponent();
            InitializeBooking();
            WireUpEvents();
            LoadNationalities();
            UpdateBalanceDisplay();
          
        }

        private void UpdateBalanceDisplay()
        {
            lblBalance.Text = $"Available Balance: {_currentUser.Balance.ToString():USD}";
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
                List<CountryData> countries = JsonConvert.DeserializeObject<List<CountryData>>(json);

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
                FlightNumber = _selectedFlight.FlightNumber,
                Airline = _selectedFlight.Airline,
                Origin = _selectedFlight.Origin,
                Destination = _selectedFlight.Destination,
                DepartureTime = _selectedFlight.DepartureTime,
                ArrivalTime = _selectedFlight.ArrivalTime,
                DestinationImageUrl = _selectedFlight.DestinationImageUrl,
                OriginalPrice = _selectedFlight.Price,
                Passenger = new Passenger(),
                SeatNumber = GenerateRandomSeat(),
                PNR = GeneratePNR(),
                TotalPrice = _selectedFlight.Price,
                BookedBuy = _currentUser,
                IsNonStop = _selectedFlight.IsNonStop,
                Stops = _selectedFlight.Stops?.ToList() ?? new List<FlightStop>()
            };


            lblFlightInfo.Text = $"{_selectedFlight.Airline} • {_selectedFlight.FlightNumber}\n" +
                               $"{_selectedFlight.Origin} → {_selectedFlight.Destination}\n" +
                               $"{_selectedFlight.DepartureTime:ddd, MMM dd yyyy hh:mm tt}";
            lblTotalPrice.Text = $"Total Price: {_selectedFlight.FormattedPrice}";
            string stopsInfo = _selectedFlight.IsNonStop ? "Non-stop" :
           $"{_selectedFlight.StopCount} stop{(_selectedFlight.StopCount > 1 ? "s" : "")}";

            lblFlightInfo.Text = $"{_selectedFlight.Airline} • {_selectedFlight.FlightNumber}\n" +
                               $"{_selectedFlight.Origin} → {_selectedFlight.Destination}\n" +
                               $"{_selectedFlight.DepartureTime:ddd, MMM dd yyyy hh:mm tt}\n" +
                               $"({stopsInfo})";
        }

        private string GeneratePNR()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomSeat()
        {
            Random random = new Random();
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
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!_passengerRepository.Add(_bookingDetails.Passenger))
                {
                    throw new Exception("Failed to save passenger details");
                }

                BookingDetails booking = _bookingService.CreateBooking(
                    _selectedFlight,
                    _bookingDetails.Passenger,
                    _currentUser,
                    _selectedFlight.SeatClass
                );

                if (!_userService.DecreaseUserBalance(_currentUser.Id, _selectedFlight.Price))
                {
                    throw new Exception("Failed to update user balance");
                }

                if (!_userService.IncrementUserBookingCount(_currentUser.Id))
                {
                    throw new Exception("Failed to update booking count");
                }

                User updatedUser = _userService.GetUserById(_currentUser.Id);
                _currentUser.Balance = updatedUser.Balance;

                BookingConfirmed?.Invoke(this, booking);
                MessageBox.Show($"Booking confirmed! PNR: {booking.PNR}", "Success");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errorMessage += $"\nInner Exception: {ex.Message}";
                }

                MessageBox.Show($"Booking failed: {errorMessage}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateBooking()
        {
            bool isValid = true;
            errorProvider.Clear(); 

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "First name is required");
                isValid = false;
            }
            else if (txtFirstName.Text.Length > 50)
            {
                errorProvider.SetError(txtFirstName, "First name cannot exceed 50 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Last name is required");
                isValid = false;
            }
            else if (txtLastName.Text.Length > 50)
            {
                errorProvider.SetError(txtLastName, "Last name cannot exceed 50 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email is required");
                isValid = false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Please enter a valid email address");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Phone number is required");
                isValid = false;
            }
            else if (!IsValidPhoneNumber(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Format: +[country code][number] (e.g., +218123456789)");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassport.Text))
            {
                errorProvider.SetError(txtPassport, "Passport number is required");
                isValid = false;
            }
            else if (!IsValidPassport(txtPassport.Text))
            {
                errorProvider.SetError(txtPassport, "Only letters and numbers allowed");
                isValid = false;
            }
            else if (txtPassport.Text.Length < 6 || txtPassport.Text.Length > 20)
            {
                errorProvider.SetError(txtPassport, "Must be between 6-20 characters");
                isValid = false;
            }

            if (dtpDob.Value > DateTime.Today)
            {
                errorProvider.SetError(dtpDob, "Date cannot be in the future");
                isValid = false;
            }
            else if (CalculateAge(dtpDob.Value) < 1)
            {
                errorProvider.SetError(dtpDob, "Passenger must be at least 1 year old");
                isValid = false;
            }

            if (cmbNationality.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbNationality.Text))
            {
                errorProvider.SetError(cmbNationality, "Please select a nationality");
                isValid = false;
            }

            return isValid;
        }

        // Helper method to calculate age
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private bool IsValidPhoneNumber(string phoneNumber) { 
        
            return Regex.IsMatch(phoneNumber, @"^\+\d{1,4}\d{7,14}$");
        }

        private bool IsValidPassport(string passportNumber)
        {
            return Regex.IsMatch(passportNumber, @"^[a-zA-Z0-9]+$");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}