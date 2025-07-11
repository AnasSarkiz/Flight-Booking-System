using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Controls
{
    public partial class SearchFlightsControl : UserControl
    {
        public event EventHandler<Flight> FlightSelected;
        public event EventHandler BackToHomeClicked;

        private List<Flight> _flights = new List<Flight>();

        public SearchBoxControl SearchBox => searchBoxControl;
        public FilterPanelControl FilterPanel => filterPanelControl;

        public SearchFlightsControl()
        {
            InitializeComponent();
            WireUpEvents();
            ConfigureFlightCardsPanel();
        }

        private void WireUpEvents()
        {
            searchBoxControl.SearchTriggered += OnSearchTriggered;
            filterPanelControl.SortChanged += OnSortChanged;
            //backButton.Click += (s, e) => BackToHomeClicked?.Invoke(this, e);
        }

        private void ConfigureFlightCardsPanel()
        {
            flightCardsPanel.AutoScroll = true;
            flightCardsPanel.WrapContents = false;
            flightCardsPanel.FlowDirection = FlowDirection.LeftToRight;
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
                var noResultsLabel = new Label
                {
                    Text = "No flights found matching your criteria",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                flightCardsPanel.Controls.Add(noResultsLabel);
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

        private Control CreateFlightCard(Flight flight)
        {
            var card = new Panel
            {
                Width = 280,
                Height = 380,
                Margin = new Padding(15),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Flight Image
            var pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(15, 15),
                Size = new Size(250, 120),
                Image = LoadFlightImage(flight.ImageUrl)
            };
            card.Controls.Add(pictureBox);

            // Flight Details
            var airlineLabel = new Label
            {
                Text = flight.Airline,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 150),
                AutoSize = true
            };
            card.Controls.Add(airlineLabel);

            var routeLabel = new Label
            {
                Text = $"{flight.Origin} → {flight.Destination}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 180),
                AutoSize = true
            };
            card.Controls.Add(routeLabel);

            var priceLabel = new Label
            {
                Text = $"Price: ${flight.Price}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                Location = new Point(15, 210),
                AutoSize = true
            };
            card.Controls.Add(priceLabel);

            // Select Button
            var selectButton = new Button
            {
                Text = "Select Flight",
                Size = new Size(250, 40),
                Location = new Point(15, 320),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            selectButton.Click += (s, e) => FlightSelected?.Invoke(this, flight);
            card.Controls.Add(selectButton);

            return card;
        }

        private Image LoadFlightImage(string imageUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    return Image.FromFile(imageUrl);
                }
            }
            catch
            {
                // Fallback image
                return CreateDefaultFlightImage();
            }
            return CreateDefaultFlightImage();
        }

        private Image CreateDefaultFlightImage()
        {
            var bmp = new Bitmap(250, 120);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightSteelBlue);
                using (var font = new Font("Segoe UI", 14, FontStyle.Bold))
                {
                    g.DrawString("Flight Image", font, Brushes.White, new PointF(50, 50));
                }
            }
            return bmp;
        }
    }
}