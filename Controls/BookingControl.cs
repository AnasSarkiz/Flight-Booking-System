using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Controls
{
    public partial class BookingControl : UserControl
    {
        public event EventHandler<BookingDetails> BookingConfirmed;
        public event EventHandler BackRequested;

        private readonly Flight _selectedFlight;
        private BookingDetails _bookingDetails;
        private string _selectedSeat = "";

        public BookingControl(Flight flight)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight));

            _selectedFlight = flight;
            InitializeBookingDetails();
            InitializeComponent();
            InitializePassengerTab();
            InitializePaymentTab();
            UpdateFlightInfo();
            WireUpEvents();
        }

        private void InitializeBookingDetails()
        {
            _bookingDetails = new BookingDetails
            {
                Flight = _selectedFlight,
                Passenger = new Passenger(),
                Payment = new PaymentInfo(),
                SeatNumber = "",
                PNR = GeneratePNR(),
                TotalPrice = _selectedFlight.Price
            };
        }

        private string GeneratePNR()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void UpdateFlightInfo()
        {
            lblFlightInfo.Text = $"{_selectedFlight.Airline} {_selectedFlight.FlightNumber} | " +
                               $"{_selectedFlight.Origin} → {_selectedFlight.Destination} | " +
                               $"{_selectedFlight.DepartureTime:ddd, MMM dd yyyy} | " +
                               $"Price: {_selectedFlight.FormattedPrice}";
        }

        private void InitializePassengerTab()
        {
            passengerTab.Controls.Clear();

            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 7,
                AutoScroll = true,
                Padding = new Padding(15),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            AddFormField(panel, "First Name:", CreateTextBox(nameof(Passenger.FirstName)), 0);
            AddFormField(panel, "Last Name:", CreateTextBox(nameof(Passenger.LastName)), 1);
            AddFormField(panel, "Passport Number:", CreateTextBox(nameof(Passenger.PassportNumber)), 2);
            AddFormField(panel, "Nationality:", CreateComboBox(new[] { "US", "UK", "CA", "AU", "JP" }, nameof(Passenger.Nationality)), 3);
            AddFormField(panel, "Email:", CreateTextBox(nameof(Passenger.Email)), 4);
            AddFormField(panel, "Phone:", CreateTextBox(nameof(Passenger.Phone)), 5);

            var dobPicker = new DateTimePicker
            {
                Value = DateTime.Now.AddYears(-20),
                Format = DateTimePickerFormat.Short,
                Dock = DockStyle.Fill
            };
            dobPicker.ValueChanged += (s, e) => _bookingDetails.Passenger.DateOfBirth = dobPicker.Value;
            AddFormField(panel, "Date of Birth:", dobPicker, 6);

            passengerTab.Controls.Add(panel);
        }

        private void InitializePaymentTab()
        {
            paymentTab.Controls.Clear();

            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                AutoScroll = true,
                Padding = new Padding(15),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            AddFormField(panel, "Cardholder Name:", CreateTextBox(nameof(PaymentInfo.CardHolderName)), 0);
            AddFormField(panel, "Card Number:", CreateTextBox(nameof(PaymentInfo.CardNumber)), 1);
            AddFormField(panel, "Expiry Date:", CreateTextBox(nameof(PaymentInfo.ExpiryDate)), 2);
            AddFormField(panel, "CVV:", CreateTextBox(nameof(PaymentInfo.CVV)), 3);

            paymentTab.Controls.Add(panel);
        }

        private TextBox CreateTextBox(string propertyName)
        {
            var textBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            textBox.TextChanged += (s, e) =>
            {
                var property = _bookingDetails.Passenger.GetType().GetProperty(propertyName) ??
                              _bookingDetails.Payment.GetType().GetProperty(propertyName);
                property?.SetValue(property.DeclaringType == typeof(Passenger) ?
                    _bookingDetails.Passenger : _bookingDetails.Payment, textBox.Text);
            };

            return textBox;
        }

        private ComboBox CreateComboBox(string[] items, string propertyName)
        {
            var comboBox = new ComboBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndexChanged += (s, e) =>
            {
                _bookingDetails.Passenger.GetType().GetProperty(propertyName)?
                    .SetValue(_bookingDetails.Passenger, comboBox.SelectedItem?.ToString());
            };
            return comboBox;
        }

        private void AddFormField(TableLayoutPanel panel, string labelText, Control inputControl, int row)
        {
            var label = new Label
            {
                Text = labelText,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 100)
            };

            panel.Controls.Add(label, 0, row);
            panel.Controls.Add(inputControl, 1, row);
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        }

        private void WireUpEvents()
        {
            btnBack.Click += btnBack_Click;
            btnConfirm.Click += btnConfirm_Click;
            seatMapControl.SeatSelected += seatMapControl_SeatSelected;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateBooking()) return;

            _bookingDetails.SeatNumber = _selectedSeat;
            _bookingDetails.TotalPrice = _selectedFlight.Price;

            BookingConfirmed?.Invoke(this, _bookingDetails);
        }

        private bool ValidateBooking()
        {
            if (string.IsNullOrWhiteSpace(_bookingDetails.Passenger.FirstName))
            {
                MessageBox.Show("Please enter first name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(_bookingDetails.Passenger.LastName))
            {
                MessageBox.Show("Please enter last name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(_bookingDetails.Payment.CardNumber) ||
                _bookingDetails.Payment.CardNumber.Length != 16)
            {
                MessageBox.Show("Please enter valid 16-digit card number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(_selectedSeat))
            {
                MessageBox.Show("Please select a seat", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void seatMapControl_SeatSelected(object sender, string seat)
        {
            _selectedSeat = seat;
            lblSeatInfo.Text = $"Selected Seat: {seat}";
            lblSeatInfo.ForeColor = Color.DarkGreen;
        }
    }
}