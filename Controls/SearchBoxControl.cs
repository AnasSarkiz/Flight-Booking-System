using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class SearchBoxControl : UserControl
    {
        public event EventHandler SearchTriggered;

        public string Origin => originTextBox.Text.Trim();
        public string Destination => destinationTextBox.Text.Trim();
        public DateTime DepartureDate => departureDatePicker.Value.Date;

        public SearchBoxControl()
        {
            InitializeComponent();
            WireUpEvents();
        }

      

        private void WireUpEvents()
        {
            searchButton.Click += (s, e) => SearchTriggered?.Invoke(this, EventArgs.Empty);
        }
    }
}