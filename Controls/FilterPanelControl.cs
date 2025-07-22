using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class FilterPanelControl : UserControl
    {
        public enum SortOption { Price, Duration, DepartureTime }
        public enum StopOption { NonStop, OneStop, AnyStops }

        public event EventHandler FiltersApplied;
        public event EventHandler SortChanged;

        private SortOption _selectedSortOption = SortOption.Price;
        private StopOption _selectedStopOption = StopOption.NonStop;
        private decimal _maxPrice = 1000;
        private List<string> _selectedAirlines = new List<string>();

        public SortOption SelectedSortOption
        {
            get => _selectedSortOption;
            set
            {
                if (_selectedSortOption != value)
                {
                    _selectedSortOption = value;
                    SortChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public StopOption SelectedStopOption => _selectedStopOption;
        public decimal MaxPrice => _maxPrice;
        public List<string> SelectedAirlines => _selectedAirlines;

        public FilterPanelControl()
        {
            InitializeComponent(); 
            WireUpEvents();
            InitializeAirlines();
        }
        private void WireUpEvents()
        {
            priceTrackBar.Scroll += (s, e) =>
            {
                _maxPrice = priceTrackBar.Value;
                maxPriceLabel.Text = $"${_maxPrice}";
            };

            // Stops filter
            nonStopRadio.CheckedChanged += (s, e) =>
            {
                if (nonStopRadio.Checked) _selectedStopOption = StopOption.NonStop;
            };
            oneStopRadio.CheckedChanged += (s, e) =>
            {
                if (oneStopRadio.Checked) _selectedStopOption = StopOption.OneStop;
            };
            anyStopsRadio.CheckedChanged += (s, e) =>
            {
                if (anyStopsRadio.Checked) _selectedStopOption = StopOption.AnyStops;
            };

            airlineCheckBox1.CheckedChanged += UpdateSelectedAirlines;
            airlineCheckBox2.CheckedChanged += UpdateSelectedAirlines;
            airlineCheckBox3.CheckedChanged += UpdateSelectedAirlines;

            applyFiltersButton.Click += (s, e) => FiltersApplied?.Invoke(this, EventArgs.Empty);
        }
        private void InitializeAirlines()
        {
            airlineCheckBox1.Text = "AirLine 1";
            airlineCheckBox2.Text = "Airline 2";
            airlineCheckBox3.Text = "Airline 2";
        }
        public void UpdateFilters(List<Flight> flights)
        {
            List<String> airlines = flights.Select(f => f.Airline).Distinct().ToList();
            airlinesGroupBox.Controls.Clear();

            int yPos = 40;
            foreach (String airline in airlines)
            {
                CheckBox checkBox = new()
                {
                    Text = airline,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(20, yPos),
                    AutoSize = true
                };
                checkBox.CheckedChanged += UpdateSelectedAirlines;
                airlinesGroupBox.Controls.Add(checkBox);
                yPos += 30;
            }
            airlinesGroupBox.Height = yPos + 10;

            bool hasNonStop = flights.Any(f => f.Stops == 0);
            bool hasOneStop = flights.Any(f => f.Stops == 1);
            bool hasMultiStop = flights.Any(f => f.Stops > 1);

            nonStopRadio.Enabled = hasNonStop;
            oneStopRadio.Enabled = hasOneStop;
            anyStopsRadio.Enabled = hasNonStop || hasOneStop || hasMultiStop;

            if ((_selectedStopOption == StopOption.NonStop && !hasNonStop) ||
                (_selectedStopOption == StopOption.OneStop && !hasOneStop))
            {
                anyStopsRadio.Checked = true;
            }
        }
        private void UpdateSelectedAirlines(object sender, EventArgs e)
        {
            _selectedAirlines.Clear();
            if (airlineCheckBox1.Checked) _selectedAirlines.Add(airlineCheckBox1.Text);
            if (airlineCheckBox2.Checked) _selectedAirlines.Add(airlineCheckBox2.Text);
            if (airlineCheckBox3.Checked) _selectedAirlines.Add(airlineCheckBox3.Text);
        }
    }
}