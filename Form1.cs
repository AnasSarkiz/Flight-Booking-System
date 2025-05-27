using Flight_Booking_System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlightBooker
{
    public partial class Form1 : Form
    {
        private readonly List<(string Airline, string Duration, decimal Price, string Image, string From, string To, DateTime Date)> allFlights
           = new()
           {
               ("Airline 1", "3h 45m", 450, "https://cdn.aarp.net/content/dam/aarp/travel/budget_travel/2022/06/1140-big-ben-hero.jpg", "Paris", "London", new DateTime(2025, 6, 1)),
               ("Airline 2", "2h 30m", 390, "https://www.cwmun.org/wp-content/uploads/2022/09/rome.png", "Berlin", "Rome", new DateTime(2025, 6, 1)),
               ("Airline 3", "4h 10m", 500, "https://pohcdn.com/sites/default/files/styles/big_gallery_image/public/text_gallery/Berlin_6.jpg", "Paris", "Berlin", new DateTime(2025, 6, 2)),
               ("Airline 4", "5h 15m", 600, "https://lp-cms-production.imgix.net/2025-05/shutterstock2121995255.jpg?w=780&h=425&fit=crop&auto=format&q=75", "New York", "Los Angeles", new DateTime(2025, 6, 3)),
               ("Airline 5", "7h 20m", 750, "https://media.connections.be/image/upload/c_fill,g_auto,q_auto:best,w_3840,f_auto//v1652357449/Destinations/Asia/Japan/TOURS/Discover%20Tokyo/Header_Fujiyoshida.jpg", "Sydney", "Tokyo", new DateTime(2025, 6, 4)),
               ("Airline 6", "6h 50m", 680, "https://www.edb.gov.sg/content/dam/edb-en/business-insights/insights/moving-to-singapore-which-neighbourhood-is-for-you/moving-to-singapore-which-neighbourhood-is-for-you-og-twitter-600x315.jpg", "Dubai", "Singapore", new DateTime(2025, 6, 5)),
               ("Airline 7", "3h 10m", 320, "https://media.timeout.com/images/106185654/750/562/image.jpg", "Madrid", "Barcelona", new DateTime(2025, 6, 6)),
               ("Airline 8", "8h 30m", 900, "https://cdn.britannica.com/13/77413-050-95217C0B/Golden-Gate-Bridge-San-Francisco.jpg", "Shanghai", "San Francisco", new DateTime(2025, 6, 7)),
               ("Airline 9", "2h 45m", 280, "https://content.tui.co.uk/adamtui/2022_8/5_13/350cca2f-d21d-46ad-9b0a-aee800e1fdf8/LOC_000733_shutterstock_712426702WebOriginalCompressed.jpg", "Amsterdam", "Brussels", new DateTime(2025, 6, 8))
           };

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(searchPanel);
            mainContentPanel.Controls.Add(flightCardsPanel);
            mainContentPanel.Controls.Add(filterPanel);
            flightCardsPanel.Controls.Clear();
            AddDummyFlightCards();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(searchPanel);
            mainContentPanel.Controls.Add(flightCardsPanel);
            mainContentPanel.Controls.Add(filterPanel);
            flightCardsPanel.Controls.Clear();
            AddDummyFlightCards();
        }

        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();

            Panel bookingsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightBlue
            };

            bookingsPanel.Controls.Add(new Label
            {
                Text = "My Bookings",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 14),
                Padding = new Padding(10),
            });

            mainContentPanel.Controls.Add(bookingsPanel);

            flightCardsPanel.Controls.Clear(); // Ensure flight cards are reset
            AddDummyFlightCards(); // Optional if bookings should show flights
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Registration registrationForm = new Registration();
            registrationForm.Show();
            this.Close();
        }

        private void AddDummyFlightCards(string origin = "", string destination = "", DateTime? departure = null)
        {
            flightCardsPanel.Controls.Clear();

            var filteredFlights = allFlights.Where(f =>
                (string.IsNullOrEmpty(origin) || f.From.ToLower().Contains(origin.ToLower())) &&
                (string.IsNullOrEmpty(destination) || f.To.ToLower().Contains(destination.ToLower())) &&
                (!departure.HasValue || f.Date.Date == departure.Value.Date)
            ).ToList();

            foreach (var flight in filteredFlights)
            {
                AddFlightCard(flight.Airline, flight.Duration, flight.Price, flight.Image,flight.From,flight.To);
            }

            if (filteredFlights.Count == 0)
            {
                flightCardsPanel.Controls.Add(new Label
                {
                    Text = "No flights found matching your search.",
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, 20)
                });
            }
        }

        private void AddFlightCard(string airlineName, string duration, decimal price, string imageUrl, string origin, string destination)
        {
            Panel card = new Panel
            {
                Width = 200,
                Height = 300,
                Margin = new Padding(10),
                BackColor = Color.SteelBlue
            };

            PictureBox image = new PictureBox
            {
                ImageLocation = imageUrl,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 180,
                Height = 100,
                Location = new Point(10, 10)
            };

            Label nameLabel = new Label
            {
                Text = airlineName,
                Location = new Point(10, 120),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label durationLabel = new Label
            {
                Text = $"Flight Duration: {duration}",
                Location = new Point(10, 150),
                AutoSize = true
            };

            Label priceLabel = new Label
            {
                Text = $"Price: ${price}",
                Location = new Point(10, 180),
                AutoSize = true
            };

            Label fromLbl = new Label
            {
                Text = $"From: {origin}",
                Location = new Point(10, 200),
                AutoSize = true
            };

            Label toLbl = new Label
            {
                Text = $"To: {destination}",
                Location = new Point(10, 220),
                AutoSize = true
            };

            Button selectBtn = new Button
            {
                Text = "Select",
                Width = 180,
                Height = 30,
                BackColor = Color.WhiteSmoke,
                Location = new Point(10, 240)
            };

            selectBtn.Click += (s, e) =>
            { 
                ShowBookingPage();
            };

            card.Controls.Add(image);
            card.Controls.Add(nameLabel);
            card.Controls.Add(durationLabel);
            card.Controls.Add(priceLabel);
            card.Controls.Add(fromLbl);
            card.Controls.Add(toLbl);
            card.Controls.Add(selectBtn);

            flightCardsPanel.Controls.Add(card);
        }
        private void ShowBookingPage()
        {
            mainContentPanel.Controls.Clear();
            Booking bookingPage = new Booking();
            mainContentPanel.Controls.Add(bookingPage);
        }
   
        private void searchButton_Click(object sender, EventArgs e)
        {
            string origin = originTextBox.Text.Trim();
            string destination = destinationTextBox.Text.Trim();
            DateTime departure = departureDatePicker.Value.Date;

            AddDummyFlightCards(origin, destination, departure);
        }
    }
}
