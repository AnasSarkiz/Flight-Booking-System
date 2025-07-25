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
        private readonly AmadeusService _amadeusService;

        public SearchBoxControl SearchBox => searchBoxControl;
        public FilterPanelControl FilterPanel => filterPanelControl;

        public SearchFlightsControl()
        {
            _amadeusService = new AmadeusService();
            _unsplashService = new UnsplashService();
            _unsplashService = new UnsplashService();
            InitializeComponent();
            WireUpEvents();
            ConfigureFlightCardsPanel();
            _ = InitializeTestFlightsAsync(); 
        }

        private async Task InitializeTestFlightsAsync()
        {
            var testFlights = new List<Flight>
              {
        await CreateTestFlight(1, "AA123", "AA", "New York (JFK)", "London (LHR)", 2, 8, 499.99m,"ECONOMY",0),
        await CreateTestFlight(2, "DL456", "DL", "Atlanta (ATL)", "Paris (CDG)", 4, 11, 599.99m,"ECONOMY",0),
        await CreateTestFlight(3, "UA789", "UA", "Chicago (ORD)", "Tokyo (NRT)", 6, 18, 1299.99m,"ECONOMY",0),
        await CreateTestFlight(4, "BA321", "BA", "London (LHR)", "New York (JFK)", 8, 14, 549.99m,"ECONOMY",0),
        
        await CreateTestFlight(5, "LH411", "LH", "Frankfurt (FRA)", "Singapore (SIN)", 3, 16, 899.99m,"ECONOMY",0),
        await CreateTestFlight(6, "AF268", "AF", "Paris (CDG)", "New York (JFK)", 4, 10, 659.99m,"ECONOMY",0),
        await CreateTestFlight(7, "KL602", "KL", "Amsterdam (AMS)", "Dubai (DXB)", 5, 12, 749.99m,"ECONOMY",0),
        await CreateTestFlight(8, "AY102", "AY", "Helsinki (HEL)", "Bangkok (BKK)", 6, 15, 799.99m,"ECONOMY",0),
        
        await CreateTestFlight(9, "SQ321", "SQ", "Singapore (SIN)", "London (LHR)", 7, 19, 1099.99m,"ECONOMY",0),
        await CreateTestFlight(10, "CX888", "CX", "Hong Kong (HKG)", "Vancouver (YVR)", 8, 16, 1199.99m,"ECONOMY",0),
        await CreateTestFlight(11, "JL45", "JL", "Tokyo (NRT)", "Sydney (SYD)", 9, 14, 999.99m,"ECONOMY",0),
        await CreateTestFlight(12, "EK412", "EK", "Dubai (DXB)", "New York (JFK)", 10, 20, 1399.99m,"ECONOMY",0),
        
        await CreateTestFlight(13, "WN234", "WN", "Las Vegas (LAS)", "Denver (DEN)", 1, 3, 199.99m,"ECONOMY",0),
        await CreateTestFlight(14, "B6123", "B6", "Boston (BOS)", "Los Angeles (LAX)", 2, 8, 349.99m,"ECONOMY",0),
        await CreateTestFlight(15, "AS789", "AS", "Seattle (SEA)", "Honolulu (HNL)", 3, 9, 499.99m,"ECONOMY",0),
        
        await CreateTestFlight(16, "QF12", "QF", "Los Angeles (LAX)", "Sydney (SYD)", 4, 18, 2999.99m,"BUSINESS",0),
        await CreateTestFlight(17, "EY101", "EY", "Abu Dhabi (AUH)", "New York (JFK)", 5, 16, 3499.99m,"FIRST",0),
        
        await CreateTestFlight(18, "FR123", "FR", "London (STN)", "Barcelona (BCN)", 1, 4, 59.99m,"STANDARD",0),
         await CreateTestFlight(19, "DY701", "DY", "Oslo (OSL)", "New York (JFK)", 2, 10, 299.99m,"STANDARD",0)
           };


            LoadFlights(testFlights);
        }

        private async Task<Flight> CreateTestFlight(int id, string number, string airline,
     string origin, string destination, int depHours, int arrHours, decimal price,string seatClass,int stopsNo)
        {
            var cityName = destination.Split('(')[0].Trim();
            return new Flight
            {
                Id = id,
                FlightNumber = number,
                Airline = airline,
                Origin = origin,
                Destination = destination,
                DepartureTime = DateTime.Now.AddHours(depHours*4),
                ArrivalTime = DateTime.Now.AddHours(arrHours*4),
                Duration = TimeSpan.FromHours(arrHours - depHours),
                Price = price,
                DestinationImageUrl = await _unsplashService.GetCityImageUrl(cityName),
                AirlineLogoUrl = $"https://content.airhex.com/content/logos/airlines_{airline}_80_80_s.png",
                Stops = stopsNo,
                SeatClass = seatClass

            };
        }

        private void WireUpEvents()
        {
            searchBoxControl.SearchTriggered += OnSearchTriggered;
            filterPanelControl.SortChanged += OnSortChanged;
            filterPanelControl.FiltersApplied += OnFiltersApplied;
        }
        private void OnFiltersApplied(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filteredFlights = _flights.Where(f =>
                (filterPanelControl.SelectedAirlines.Count == 0 ||
                 filterPanelControl.SelectedAirlines.Contains(f.Airline)) &&
                f.Price <= filterPanelControl.MaxPrice &&
                (filterPanelControl.SelectedStopOption == FilterPanelControl.StopOption.AnyStops ||
                 (filterPanelControl.SelectedStopOption == FilterPanelControl.StopOption.NonStop && f.Stops == 0) ||
                 (filterPanelControl.SelectedStopOption == FilterPanelControl.StopOption.OneStop && f.Stops == 1))
            ).ToList();

            var sortedFlights = SortFlights(filteredFlights, filterPanelControl.SelectedSortOption);
            DisplayFlights(sortedFlights);
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
            filterPanelControl.UpdateFilters(flights);
            DisplayFlights(flights);
        }

        private async void OnSearchTriggered(object sender, EventArgs e)
        {
            try
            {
                loadingLabel.Visible = true;
                flightCardsPanel.Visible = false;

                var origin = searchBoxControl.OriginAirport?.iata;
                var destination = searchBoxControl.DestinationAirport?.iata;
                var cabinClass = searchBoxControl.CabinClass;
                var destinationCity = searchBoxControl.DestinationAirport.city;

                if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
                {
                    MessageBox.Show("Please select valid airports");
                    return;
                }

                var flights = await _amadeusService.SearchFlightsAsync(
                    origin,
                    destination,
                    searchBoxControl.DepartureDate,
                    cabinClass
                );

                if (flights.Count == 0)
                {
                    MessageBox.Show("No flights found for your search criteria");
                    filterPanelControl.UpdateFilters(new List<Flight>());
                    return;
                }

                var cityName = searchBoxControl.DestinationAirport.city;

                foreach (Flight flight in flights)
                {
                    flight.DestinationImageUrl = await _unsplashService.GetCityImageUrl(destinationCity);
                    flight.AirlineLogoUrl = $"https://content.airhex.com/content/logos/airlines_{flight.Airline}_80_80_s.png";
                }

                LoadFlights(flights);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching flights: {ex.Message}");
                await InitializeTestFlightsAsync();
            }
            finally
            {
                loadingLabel.Visible = false;
                flightCardsPanel.Visible = true;
            }
        }

        private void OnSortChanged(object sender, EventArgs e)
        {
            var sortedFlights = SortFlights(
                _flights,
                filterPanelControl.SelectedSortOption
            );
            DisplayFlights(sortedFlights);
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
                var noResultsPanel = new Panel
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
            var card = new Panel
            {
                Width = flightCardsPanel.Width - 60,
                Height = 160,
                Margin = new Padding(10, 15, 10, 15),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Main content panel
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 15, 20, 15)
            };

            Panel airlinePanel = new Panel
            {
                Width = 50,
                Height = 50,
                Location = new Point(10, 15),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            _ = LoadImageAsync(airlinePanel, flight.AirlineLogoUrl);
            contentPanel.Controls.Add(airlinePanel);

            Panel detailsPanel = new Panel
            {
                Location = new Point(70, 15),
                Size = new Size(400, 110)
            };

            Label flightLabel = new Label
            {
                Text = $"{flight.Airline} • {flight.FlightNumber}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(0, 0),
                AutoSize = true,
                ForeColor = Color.FromArgb(50, 50, 70)
            };
            detailsPanel.Controls.Add(flightLabel);

            Label routeLabel = new Label
            {
                Text = $"{flight.Origin} → {flight.Destination}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(0, 25),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 50)
            };
            detailsPanel.Controls.Add(routeLabel);

            Label timeLabel = new Label
            {
                Text = $"{flight.DepartureTime:HH:mm} - {flight.ArrivalTime:HH:mm}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(0, 55),
                AutoSize = true,
                ForeColor = Color.FromArgb(80, 80, 100)
            };
            detailsPanel.Controls.Add(timeLabel);

            Label durationLabel = new Label
            {
                Text = $"Duration: {flight.FormattedDuration}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(0, 75),
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 140)
            };
            detailsPanel.Controls.Add(durationLabel);

            contentPanel.Controls.Add(detailsPanel);

            Panel pricePanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 150,
                Padding = new Padding(10)
            };

            Label priceLabel = new Label
            {
                Text = flight.FormattedPrice,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 115, 207),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleRight,
                Height = 40
            };
            pricePanel.Controls.Add(priceLabel);

            Label perPersonLabel = new Label
            {
                Text = "per person",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(140, 140, 160),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleRight,
                Height = 15
            };
            pricePanel.Controls.Add(perPersonLabel);

            Button selectButton = new Button
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
            selectButton.Click += (s, e) => FlightSelected?.Invoke(this, flight);
            pricePanel.Controls.Add(selectButton);

            contentPanel.Controls.Add(pricePanel);
            card.Controls.Add(contentPanel);

      

            return card;
        }
        public void SetSearchDestination(string destination)
        {
            searchBoxControl.SetDestination(destination);
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

                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var fallbackUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Airplane_silhouette.svg/512px-Airplane_silhouette.svg.png";
                        var fallbackBytes = await httpClient.GetByteArrayAsync(fallbackUrl);
                        await using (var ms = new MemoryStream(fallbackBytes))
                        {
                            panel.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    panel.BackColor = Color.FromArgb(240, 245, 255);
                    panel.BackgroundImage = null;
                }
            }

        }
    }
   
}