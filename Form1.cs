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
        private readonly List<
            (
                string Airline,
                string Duration,
                decimal Price,
                string Image,
                string From,
                string To,
                DateTime DepartureDate,
                DateTime DepartureTime,
                DateTime ArrivalDate,
                DateTime ArrivalTime
            )
        > allFlights = new()
        {
            (
                "Airline 1",
                "3h 45m",
                450,
                "https://cdn.aarp.net/content/dam/aarp/travel/budget_travel/2022/06/1140-big-ben-hero.jpg",
                "Paris",
                "London",
                new DateTime(2025, 6, 1),
                new DateTime(2025, 6, 1, 8, 0, 0),
                new DateTime(2025, 6, 1),
                new DateTime(2025, 6, 1, 11, 45, 0)
            ),
            (
                "Airline 2",
                "2h 30m",
                390,
                "https://www.cwmun.org/wp-content/uploads/2022/09/rome.png",
                "Berlin",
                "Rome",
                new DateTime(2025, 6, 1),
                new DateTime(2025, 6, 1, 9, 0, 0),
                new DateTime(2025, 6, 1),
                new DateTime(2025, 6, 1, 11, 30, 0)
            ),
            (
                "Airline 3",
                "4h 10m",
                500,
                "https://pohcdn.com/sites/default/files/styles/big_gallery_image/public/text_gallery/Berlin_6.jpg",
                "Paris",
                "Berlin",
                new DateTime(2025, 6, 2),
                new DateTime(2025, 6, 2, 7, 0, 0),
                new DateTime(2025, 6, 2),
                new DateTime(2025, 6, 2, 11, 10, 0)
            ),
            (
                "Airline 4",
                "5h 15m",
                600,
                "https://lp-cms-production.imgix.net/2025-05/shutterstock2121995255.jpg?w=780&h=425&fit=crop&auto=format&q=75",
                "New York",
                "Los Angeles",
                new DateTime(2025, 6, 3),
                new DateTime(2025, 6, 3, 6, 0, 0),
                new DateTime(2025, 6, 3),
                new DateTime(2025, 6, 3, 11, 15, 0)
            ),
            (
                "Airline 5",
                "7h 20m",
                750,
                "https://media.connections.be/image/upload/c_fill,g_auto,q_auto:best,w_3840,f_auto//v1652357449/Destinations/Asia/Japan/TOURS/Discover%20Tokyo/Header_Fujiyoshida.jpg",
                "Sydney",
                "Tokyo",
                new DateTime(2025, 6, 4),
                new DateTime(2025, 6, 4, 10, 0, 0),
                new DateTime(2025, 6, 4),
                new DateTime(2025, 6, 4, 17, 20, 0)
            ),
            (
                "Airline 6",
                "6h 50m",
                680,
                "https://www.edb.gov.sg/content/dam/edb-en/business-insights/insights/moving-to-singapore-which-neighbourhood-is-for-you/moving-to-singapore-which-neighbourhood-is-for-you-og-twitter-600x315.jpg",
                "Dubai",
                "Singapore",
                new DateTime(2025, 6, 5),
                new DateTime(2025, 6, 5, 14, 0, 0),
                new DateTime(2025, 6, 5),
                new DateTime(2025, 6, 5, 20, 50, 0)
            ),
            (
                "Airline 7",
                "3h 10m",
                320,
                "https://media.timeout.com/images/106185654/750/562/image.jpg",
                "Madrid",
                "Barcelona",
                new DateTime(2025, 6, 6),
                new DateTime(2025, 6, 6, 12, 0, 0),
                new DateTime(2025, 6, 6),
                new DateTime(2025, 6, 6, 15, 10, 0)
            ),
            (
                "Airline 8",
                "8h 30m",
                900,
                "https://cdn.britannica.com/13/77413-050-95217C0B/Golden-Gate-Bridge-San-Francisco.jpg",
                "Shanghai",
                "San Francisco",
                new DateTime(2025, 6, 7),
                new DateTime(2025, 6, 7, 5, 0, 0),
                new DateTime(2025, 6, 7),
                new DateTime(2025, 6, 7, 13, 30, 0)
            ),
            (
                "Airline 9",
                "2h 45m",
                280,
                "https://content.tui.co.uk/adamtui/2022_8/5_13/350cca2f-d21d-46ad-9b0a-aee800e1fdf8/LOC_000733_shutterstock_712426702WebOriginalCompressed.jpg",
                "Amsterdam",
                "Brussels",
                new DateTime(2025, 6, 8),
                new DateTime(2025, 6, 8, 16, 0, 0),
                new DateTime(2025, 6, 8),
                new DateTime(2025, 6, 8, 18, 45, 0)
            )
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
            ManageBooking manageBookingPage = new ManageBooking();
            mainContentPanel.Controls.Add(manageBookingPage);

            flightCardsPanel.Controls.Clear(); 

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
                (!departure.HasValue || f.DepartureDate.Date == departure.Value.Date)
            ).ToList();

            foreach (var flight in filteredFlights)
            {
                AddFlightCard(
                    flight.Airline,
                    flight.Duration,
                    flight.Price,
                    flight.Image,
                    flight.From,
                    flight.To,
                    flight.DepartureDate,
                    flight.DepartureTime,
                    flight.ArrivalDate,
                    flight.ArrivalTime
                );
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


        private void AddFlightCard(
            string airlineName,
            string duration,
            decimal price,
            string imageUrl,
            string origin,
            string destination,
            DateTime departureDate,
            DateTime departureTime,
            DateTime arrivalDate,
            DateTime arrivalTime
        )
        {
            Panel card = new Panel
            {
                Width = 220,
                Height = 360,
                Margin = new Padding(5),
                BackColor = Color.SteelBlue,
            };

            PictureBox image = new PictureBox
            {
                ImageLocation = imageUrl,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 200,
                Height = 100,
                Location = new Point(10, 10)
            };

            Label nameLabel = new Label
            {
                Text = airlineName,
                Location = new Point(10, 120),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White
            };

            Label routeLabel = new Label
            {
                Text = $"{origin} → {destination}",
                Location = new Point(10, 150),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                AutoSize = true,
                ForeColor = Color.WhiteSmoke
            };

            Label depLabel = new Label
            {
                Text = $"Departs: {departureDate:MMM dd, yyyy} {departureTime:hh:mm tt}",
                Location = new Point(10, 175),
                AutoSize = true,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),

            };

            Label arrLabel = new Label
            {
                Text = $"Arrives: {arrivalDate:MMM dd, yyyy} {arrivalTime:hh:mm tt}",
                Location = new Point(10, 200),
                AutoSize = true,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),


            };

            Label durationLabel = new Label
            {
                Text = $"Duration: {duration}",
                Location = new Point(10, 225),
                AutoSize = true,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),


            };

            Label priceLabel = new Label
            {
                Text = $"Price: ${price}",
                Location = new Point(10, 250),
                AutoSize = true,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),

            };

            Button selectBtn = new Button
            {
                Text = "Select",
                Width = 200,
                Height = 30,
                BackColor = Color.WhiteSmoke,
                Location = new Point(10, 300),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),

            };

            selectBtn.Click += (s, e) =>
            {
                ShowBookingPage();
            };

            card.Controls.Add(image);
            card.Controls.Add(nameLabel);
            card.Controls.Add(routeLabel);
            card.Controls.Add(depLabel);
            card.Controls.Add(arrLabel);
            card.Controls.Add(durationLabel);
            card.Controls.Add(priceLabel);
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

        private void flightCardsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
