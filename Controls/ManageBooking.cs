using FlightBookingSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.Controls

{
    public partial class ManageBooking : UserControl
    {
        private readonly IBookingDetailsRepository _bookingRepository;
        private readonly BookingService _bookingService;
        private readonly User _currentUser;
        private readonly IPassengerRepository _passengerRepo;
        private readonly IFlightRepository _flightRepo;
        private readonly IBookingDetailsRepository _bookingRepo;

        public event EventHandler ManageBookingClicked;

        public ManageBooking(User currentUser, IBookingDetailsRepository bookingRepo, IPassengerRepository passengerRepo, IFlightRepository flightRepo)
        {
            _currentUser = currentUser;
            _bookingRepo = bookingRepo;
            _passengerRepo = passengerRepo;
            _flightRepo = flightRepo;
            _bookingService = new BookingService(bookingRepo, flightRepo, passengerRepo);
            InitializeComponent();
            InitializeBookings();
            WireUpEvents();
        }

        // Add new method to load bookings
        private void InitializeBookings()
        {
            try
            {
                bookingsPanel.Controls.Clear();

                var userBookings = _bookingService.GetUserBookings(_currentUser.Id);

                if (!userBookings.Any())
                {
                    var noBookingsLabel = new Label
                    {
                        Text = "You don't have any bookings yet.",
                        Font = new Font("Segoe UI", 12),
                        AutoSize = true
                    };
                    bookingsPanel.Controls.Add(noBookingsLabel);
                    return;
                }

                foreach (var booking in userBookings)
                {
                    var bookingCard = CreateBookingCard(booking);
                    bookingsPanel.Controls.Add(bookingCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add method to create booking cards
        private Control CreateBookingCard(BookingDetails booking)
        {
            var card = new Panel
            {
                Width = bookingsPanel.Width - 40,
                Height = 120,
                Margin = new Padding(0, 0, 0, 20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Add booking details to the card
            var flightInfo = new Label
            {
                Text = $"{booking.Airline} {booking.FlightNumber}",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            card.Controls.Add(flightInfo);

            var routeInfo = new Label
            {
                Text = $"{booking.Origin} → {booking.Destination}",
                Location = new Point(20, 50),
                AutoSize = true
            };
            card.Controls.Add(routeInfo);

            var dateInfo = new Label
            {
                Text = booking.DepartureTime.ToString("ddd, MMM dd yyyy"),
                Location = new Point(20, 80),
                AutoSize = true
            };
            card.Controls.Add(dateInfo);

            var cancelButton = new Button
            {
                Text = "Cancel",
                Location = new Point(card.Width - 120, 40),
                Size = new Size(80, 30),
                Tag = booking.Id
            };
            cancelButton.Click += (s, e) => CancelBooking((int)cancelButton.Tag);
            card.Controls.Add(cancelButton);

            return card;
        }

        // Add method to handle booking cancellation
        private void CancelBooking(int bookingId)
        {
            try
            {
                var result = MessageBox.Show("Are you sure you want to cancel this booking?",
                                           "Confirm Cancellation",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (_bookingService.CancelBooking(bookingId))
                    {
                        MessageBox.Show("Booking cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitializeBookings(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update the WireUpEvents method
        private void WireUpEvents()
        {
            newBookingButton.Click += (s, e) => ManageBookingClicked?.Invoke(this, EventArgs.Empty);
        }


    }
}