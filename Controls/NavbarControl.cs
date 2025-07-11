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
        }

        private void WireUpEvents()
        {
            homeButton.Click += (s, e) => HomeClicked?.Invoke(this, e);
            searchFlightsButton.Click += (s, e) => SearchFlightsClicked?.Invoke(this, e);
            bookingsButton.Click += (s, e) => BookingsClicked?.Invoke(this, e);
            profileButton.Click += (s, e) => LogoutClicked?.Invoke(this, e);
        }
    }
}