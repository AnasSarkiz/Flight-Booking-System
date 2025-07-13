// SearchFlightsControl.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.Controls
{
    public partial class SearchFlightsControl : UserControl
    {
        public event EventHandler<Flight> FlightSelected;
        public event EventHandler BackToHomeClicked;

        private List<Flight> _flights = new List<Flight>();
        private readonly UnsplashService _unsplashService;

        public SearchBoxControl SearchBox => searchBoxControl;
        public FilterPanelControl FilterPanel => filterPanelControl;

        public SearchFlightsControl()
        {
            _unsplashService = new UnsplashService();
            InitializeComponent();
            WireUpEvents();
            ConfigureFlightCardsPanel();
            _ = InitializeTestFlightsAsync(); // Async initialization
        }

        private async Task InitializeTestFlightsAsync()
        {
            var testFlights = new List<Flight>
            {
                await CreateTestFlight(1, "AA123", "American Airlines", "New York (JFK)", "London (LHR)", 2, 8, 499.99m),
                await CreateTestFlight(2, "DL456", "Delta Airlines", "Atlanta (ATL)", "Paris (CDG)", 4, 11, 599.99m),
                await CreateTestFlight(3, "UA789", "United Airlines", "Chicago (ORD)", "Tokyo (NRT)", 6, 18, 1299.99m),
                await CreateTestFlight(4, "BA321", "British Airways", "London (LHR)", "New York (JFK)", 8, 14, 549.99m)
            };

            LoadFlights(testFlights);
        }

        private async Task<Flight> CreateTestFlight(int id, string number, string airline,
            string origin, string destination, int depHours, int arrHours, decimal price)
        {
            var cityName = destination.Split('(')[0].Trim();
            return new Flight
            {
                Id = id,
                FlightNumber = number,
                Airline = airline,
                Origin = origin,
                Destination = destination,
                DepartureTime = DateTime.Now.AddHours(depHours),
                ArrivalTime = DateTime.Now.AddHours(arrHours),
                Duration = TimeSpan.FromHours(arrHours - depHours),
                Price = price,
                DestinationImageUrl = await _unsplashService.GetCityImageUrl(cityName),
                AirlineLogoUrl = $"https://logo.clearbit.com/{airline.Replace(" ", "").ToLower()}.com"
            };
        }

        private void WireUpEvents()
        {
            searchBoxControl.SearchTriggered += OnSearchTriggered;
            filterPanelControl.SortChanged += OnSortChanged;
        }

        private void ConfigureFlightCardsPanel()
        {
            flightCardsPanel.AutoScroll = true;
            flightCardsPanel.WrapContents = false;
            flightCardsPanel.FlowDirection = FlowDirection.TopDown;
            flightCardsPanel.Padding = new Padding(20, 15, 20, 15);
        }

        public void LoadFlights(List<Flight> flights)
        {
            _flights = flights ?? throw new ArgumentNullException(nameof(flights));
            DisplayFlights(flights);
        }

        private void OnSearchTriggered(object sender, EventArgs e)
        {
            var filteredFlights = FilterFlights(
                searchBoxControl.Origin,
                searchBoxControl.Destination,
                searchBoxControl.DepartureDate
            );
            DisplayFlights(filteredFlights);
        }

        private void OnSortChanged(object sender, EventArgs e)
        {
            var sortedFlights = SortFlights(
                _flights,
                filterPanelControl.SelectedSortOption
            );
            DisplayFlights(sortedFlights);
        }

        private List<Flight> FilterFlights(string origin, string destination, DateTime departureDate)
        {
            return _flights.FindAll(f =>
                (string.IsNullOrEmpty(origin) || f.Origin.Contains(origin, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(destination) || f.Destination.Contains(destination, StringComparison.OrdinalIgnoreCase)) &&
                f.DepartureTime.Date == departureDate.Date
            );
        }

        private List<Flight> SortFlights(List<Flight> flights, FilterPanelControl.SortOption sortOption)
        {
            return sortOption switch
            {
                FilterPanelControl.SortOption.Price => flights.OrderBy(f => f.Price).ToList(),
                FilterPanelControl.SortOption.Duration => flights.OrderBy(f => f.Duration).ToList(),
                FilterPanelControl.SortOption.DepartureTime => flights.OrderBy(f => f.DepartureTime).ToList(),
                _ => flights
            };
        }

        private void DisplayFlights(List<Flight> flights)
        {
            flightCardsPanel.SuspendLayout();
            flightCardsPanel.Controls.Clear();

            if (flights.Count == 0)
            {
                var noResultsPanel = new RoundedPanel
                {
                    Width = flightCardsPanel.Width - 40,
                    Height = 100,
                    BackColor = Color.White,
                    Padding = new Padding(20)
                };

                var noResultsLabel = new Label
                {
                    Text = "✈️ No flights found matching your criteria",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(100, 100, 120),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                noResultsPanel.Controls.Add(noResultsLabel);
                flightCardsPanel.Controls.Add(noResultsPanel);
            }
            else
            {
                foreach (var flight in flights)
                {
                    var card = CreateFlightCard(flight);
                    flightCardsPanel.Controls.Add(card);
                }
            }

            flightCardsPanel.ResumeLayout();
        }

        private Panel CreateFlightCard(Flight flight)
        {
            var card = new RoundedPanel
            {
                Width = flightCardsPanel.Width - 60,
                Height = 160,
                Margin = new Padding(10, 15, 10, 15),
                BackColor = Color.White,
                BorderColor = Color.FromArgb(220, 230, 240),
                BorderWidth = 1,
                CornerRadius = 12,
                Cursor = Cursors.Hand
            };

            // Add hover effect
            card.MouseEnter += (s, e) => {
                card.BackColor = Color.FromArgb(248, 250, 255);
                card.BorderColor = Color.FromArgb(0, 120, 215);
            };
            card.MouseLeave += (s, e) => {
                card.BackColor = Color.White;
                card.BorderColor = Color.FromArgb(220, 230, 240);
            };

            // Main content panel
            var contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 15, 20, 15)
            };

            // Airline info
            var airlinePanel = new Panel
            {
                Width = 50,
                Height = 50,
                Location = new Point(10, 15),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            _ = LoadImageAsync(airlinePanel, flight.AirlineLogoUrl);
            contentPanel.Controls.Add(airlinePanel);

            // Flight details
            var detailsPanel = new Panel
            {
                Location = new Point(70, 15),
                Size = new Size(400, 110)
            };

            var flightLabel = new Label
            {
                Text = $"{flight.Airline} • {flight.FlightNumber}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(0, 0),
                AutoSize = true,
                ForeColor = Color.FromArgb(50, 50, 70)
            };
            detailsPanel.Controls.Add(flightLabel);

            var routeLabel = new Label
            {
                Text = $"{flight.Origin} → {flight.Destination}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(0, 25),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 50)
            };
            detailsPanel.Controls.Add(routeLabel);

            var timeLabel = new Label
            {
                Text = $"{flight.DepartureTime:HH:mm} - {flight.ArrivalTime:HH:mm}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 55),
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 100)
            };
            detailsPanel.Controls.Add(timeLabel);

            var durationLabel = new Label
            {
                Text = $"Duration: {flight.FormattedDuration}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(0, 75),
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 140)
            };
            detailsPanel.Controls.Add(durationLabel);

            contentPanel.Controls.Add(detailsPanel);

            // Price and select button
            var pricePanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 150,
                Padding = new Padding(10)
            };

            var priceLabel = new Label
            {
                Text = flight.FormattedPrice,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 115, 207),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleRight,
                Height = 40
            };
            pricePanel.Controls.Add(priceLabel);

            var perPersonLabel = new Label
            {
                Text = "per person",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(140, 140, 160),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleRight,
                Height = 15
            };
            pricePanel.Controls.Add(perPersonLabel);

            var selectButton = new RoundedButton
            {
                Text = "SELECT FLIGHT",
                Size = new Size(130, 36),
                Dock = DockStyle.Bottom,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 115, 207),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 9, FontStyle.Bold),
            };
            selectButton.FlatAppearance.BorderSize = 0;
            selectButton.MouseEnter += (s, e) => selectButton.BackColor = Color.FromArgb(0, 95, 180);
            selectButton.MouseLeave += (s, e) => selectButton.BackColor = Color.FromArgb(0, 115, 207);
            selectButton.Click += (s, e) => FlightSelected?.Invoke(this, flight);
            pricePanel.Controls.Add(selectButton);

            contentPanel.Controls.Add(pricePanel);
            card.Controls.Add(contentPanel);

            // Add subtle shadow effect
            card.Paint += (sender, e) => {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadowBrush,
                        new Rectangle(3, card.Height - 4, card.Width - 6, 4));
                }
            };

            return card;
        }
        public void SetSearchDestination(string destination)
        {
            searchBoxControl.SetDestination(destination); // You'll need to implement this in SearchBoxControl
        }
        private async Task LoadImageAsync(Panel panel, string imageUrl)
        {
            try

            {
                using (var httpClient = new HttpClient())
                {
                    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                    await using (var ms = new MemoryStream(imageBytes))
                    {
                        panel.BackgroundImage = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                // Use a placeholder if image fails to load
                panel.BackColor = Color.FromArgb(240, 245, 255);
                panel.BackgroundImage = null;
            }
        }
    }

    // Custom rounded panel class for modern UI
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 8;
        public Color BorderColor { get; set; } = Color.LightGray;
        public int BorderWidth { get; set; } = 1;

        public RoundedPanel()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var path = new GraphicsPath())
            using (var borderPen = new Pen(BorderColor, BorderWidth))
            {
                var rect = new Rectangle(0, 0, Width, Height);
                path.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(rect.X + rect.Width - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(rect.X + rect.Width - CornerRadius, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                path.CloseFigure();

                Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(BackColor), path);
                e.Graphics.DrawPath(borderPen, path);
            }
        }
    }

    // Custom rounded button class
    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; } = 8;

        public RoundedButton()
        {
            DoubleBuffered = true;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw rounded background
            using (var path = new GraphicsPath())
            {
                var rect = new Rectangle(0, 0, Width, Height);
                path.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(rect.X + rect.Width - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(rect.X + rect.Width - CornerRadius, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                path.CloseFigure();

                Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(BackColor), path);
            }

            // Draw the text
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, flags);
        }
    }
}