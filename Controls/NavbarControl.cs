using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class NavbarControl : UserControl
    {
        public event EventHandler HomeClicked;
        public event EventHandler SearchFlightsClicked;
        public event EventHandler BookingsClicked;
        public event EventHandler LogoutClicked;

        public NavbarControl()
        {
            InitializeComponent();
            WireUpEvents();
            SetActiveButton(homeButton); // Default to home button active
        }

        private void WireUpEvents()
        {
            homeButton.Click += (s, e) =>
            {
                HomeClicked?.Invoke(this, e);
                SetActiveButton(homeButton);
            };

            searchFlightsButton.Click += (s, e) =>
            {
                SearchFlightsClicked?.Invoke(this, e);
                SetActiveButton(searchFlightsButton);
            };

            bookingsButton.Click += (s, e) =>
            {
                BookingsClicked?.Invoke(this, e);
                SetActiveButton(bookingsButton);
            };

            profileButton.Click += (s, e) => LogoutClicked?.Invoke(this, e);
        }

        private void SetActiveButton(Button activeButton)
        {
            // Position the indicator under the active button
            activeIndicator.Location = new Point(
                activeButton.Location.X,
                activeButton.Location.Y + activeButton.Height - 3);
            activeIndicator.Width = activeButton.Width;

           
        }
    }
}