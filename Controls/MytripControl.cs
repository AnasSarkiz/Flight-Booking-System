using FlightBookingSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Services;


namespace FlightBookingSystem.Controls
{
    public partial class MyTripControl : UserControl
    {
        private readonly IBookingDetailsRepository _bookingRepository;
        private readonly BookingService _bookingService;
        private readonly User _currentUser;
        private readonly IPassengerRepository _passengerRepo;

        public event EventHandler NewBookingClicked;
        public event EventHandler<int> BookingManaged;

        public MyTripControl(User currentUser, IBookingDetailsRepository bookingRepo,
            IPassengerRepository passengerRepo)
        {
            _currentUser = currentUser;
            _bookingRepository = bookingRepo;
            _passengerRepo = passengerRepo;
            _bookingService = new BookingService(bookingRepo, passengerRepo);

            InitializeComponent();
            InitializeBookings();
            WireUpEvents();
        }

        private async void InitializeBookings()
        {
            try
            {
                bookingsPanel.Controls.Clear();
                loadingIndicator.Visible = true;

                var userBookings = await Task.Run(() => _bookingService.GetUserBookings(_currentUser.Id));

                if (!userBookings.Any())
                {
                    ShowNoBookingsMessage();
                    return;
                }

                foreach (var booking in userBookings)
                {
                    var bookingCard = await CreateBookingCard(booking);
                    bookingsPanel.Controls.Add(bookingCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingIndicator.Visible = false;
            }
        }
     
        private void ShowNoBookingsMessage()
        {
            var noBookingsPanel = new Panel
            {
                Width = bookingsPanel.Width - 40,
                Height = 200,
                BackColor = Color.White,
                Padding = new Padding(20),
                Margin = new Padding(0, 0, 0, 20)
            };

            var noBookingsLabel = new Label
            {
                Text = "✈️ You don't have any bookings yet",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 100, 120),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            noBookingsPanel.Controls.Add(noBookingsLabel);
            bookingsPanel.Controls.Add(noBookingsPanel);
        }

        private async Task<Panel> CreateBookingCard(BookingDetails booking)
        {
            var card = new Panel
            {
                Width = bookingsPanel.Width - 20,
                Height = 180,
                Margin = new Padding(0, 10, 0, 20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            var imagePanel = new Panel
            {
                Width = 200,
                Height = 140,
                Location = new Point(20, 20),
                BackgroundImageLayout = ImageLayout.Zoom,

            };
            var contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };


            try
            {
                string imageUrl = booking.DestinationImageUrl;
                await LoadImageAsync(imagePanel, imageUrl);
            }
            catch
            {
                imagePanel.BackColor = Color.FromArgb(240, 245, 255);
            }
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 200,
                Padding = new Padding(10)
            };

            // Manage button
            var manageButton = new Button
            {
                Text = "MANAGE",
                Size = new Size(180, 36),
                Location = new Point(10, 20),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 115, 207),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Tag = booking.Id
            };
            manageButton.FlatAppearance.BorderSize = 0;
            manageButton.Click += (s, e) => BookingManaged?.Invoke(this, (int)manageButton.Tag);

            // Airline logo (under manage button)
            var logoPanel = new Panel
            {
                Size = new Size(30, 30),
                Location = new Point(15, 70), // Below manage button
                BackgroundImageLayout = ImageLayout.Zoom
            };

            try
            {
                var airlineLogoUrl = $"https://content.airhex.com/content/logos/airlines_{booking.Airline}_80_80_s.png";
                LoadImageAsync(logoPanel, airlineLogoUrl);
            }
            catch
            {
                logoPanel.BackColor = Color.FromArgb(240, 245, 255);
            }

            // Price label (to the right of airline logo)
            var priceLabel = new Label
            {
                Text = booking.FormattedTotalPrice,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 115, 207),
                Location = new Point(70, 70), // Right of airline logo
                AutoSize = true
            };

            var perPersonLabel = new Label
            {
                Text = "total price",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(140, 140, 160),
                Location = new Point(70, 95), // Right of airline logo
                AutoSize = true
            };


            buttonPanel.Controls.Add(manageButton);
            buttonPanel.Controls.Add(logoPanel);
            buttonPanel.Controls.Add(priceLabel);
            buttonPanel.Controls.Add(perPersonLabel);

            var detailsPanel = new Panel
            {
                Location = new Point(240, 20),
                Size = new Size(400, 140)
            };

            CreateFlightDetailLabels(booking, detailsPanel);

       

            // Assemble all components
            contentPanel.Controls.Add(imagePanel);
            contentPanel.Controls.Add(detailsPanel);
            card.Controls.Add(contentPanel);
            contentPanel.Controls.Add(buttonPanel);



            // Add shadow effect
            card.Paint += (sender, e) => {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadowBrush,
                        new Rectangle(3, card.Height - 4, card.Width - 6, 4));
                }
            };

            return card;
        }

        private void CreateFlightDetailLabels(BookingDetails booking, Panel detailsPanel)
        {
            var airlineLabel = new Label
            {
                Text = $"{booking.Airline} • {booking.FlightNumber}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(0, 0),
                AutoSize = true,
                ForeColor = Color.FromArgb(50, 50, 70)
            };

            var routeLabel = new Label
            {
                Text = $"{booking.Origin} → {booking.Destination}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(0, 25),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 50)
            };

            var dateLabel = new Label
            {
                Text = booking.DepartureTime.ToString("ddd, MMM dd yyyy"),
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 55),
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 100)
            };

            var passengerLabel = new Label
            {
                Text = $"Passenger: {booking.Passenger.FirstName} {booking.Passenger.LastName}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(0, 80),
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 140)
            };

            var statusLabel = new Label
            {
                Text = $"Status: {booking.Status}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(0, 100),
                AutoSize = true,
                ForeColor = booking.Status == "Confirmed" ? Color.DarkBlue : Color.DarkBlue
            };

            detailsPanel.Controls.AddRange(new Control[] {
                airlineLabel, routeLabel, dateLabel, passengerLabel, statusLabel
            });
        }


        private async Task LoadImageAsync(Panel panel, string imageUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        panel.BackgroundImage = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                panel.BackColor = Color.FromArgb(240, 245, 255);
            }
        }

        private void WireUpEvents()
        {
            newBookingButton.Click += (s, e) => NewBookingClicked?.Invoke(this, EventArgs.Empty);
        }

        public void RefreshBookings()
        {
            InitializeBookings();
        }
    }
}