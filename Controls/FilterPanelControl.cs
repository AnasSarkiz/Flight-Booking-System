using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private decimal _minFlightPrice = 0;
        private decimal _maxFlightPrice = 1000;
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
        }

        private void WireUpEvents()
        {
            priceTrackBar.Scroll += (s, e) =>
            {
                _maxPrice = _minFlightPrice + (priceTrackBar.Value * (_maxFlightPrice - _minFlightPrice)) / 100;
                maxPriceLabel.Text = $"${_maxPrice:0}";
            };

            nonStopRadio.CheckedChanged += (s, e) =>
            {
                if (nonStopRadio.Checked)
                {
                    _selectedStopOption = StopOption.NonStop;
                    UpdateFilterButtonState();
                }
            };

            oneStopRadio.CheckedChanged += (s, e) =>
            {
                if (oneStopRadio.Checked)
                {
                    _selectedStopOption = StopOption.OneStop;
                    UpdateFilterButtonState();
                }
            };

            anyStopsRadio.CheckedChanged += (s, e) =>
            {
                if (anyStopsRadio.Checked)
                {
                    _selectedStopOption = StopOption.AnyStops;
                    UpdateFilterButtonState();
                }
            };

            applyFiltersButton.Click += (s, e) => FiltersApplied?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateFilterButtonState()
        {
            applyFiltersButton.Enabled = nonStopRadio.Enabled || oneStopRadio.Enabled || anyStopsRadio.Enabled;
        }

        public void UpdateFilters(List<Flight> flights)
        {
            if (flights.Any())
            {
                _minFlightPrice = flights.Min(f => f.Price);
                _maxFlightPrice = flights.Max(f => f.Price);

                priceTrackBar.Minimum = 0;
                priceTrackBar.Maximum = 100;
                priceTrackBar.Value = 100;

                minPriceLabel.Text = $"${_minFlightPrice:0}";
                maxPriceLabel.Text = $"${_maxFlightPrice:0}";
                _maxPrice = _maxFlightPrice;
            }

            List<string> airlines = flights.Select(f => f.Airline).Distinct().ToList();
            airlinesGroupBox.Controls.Clear();

            int yPos = 20;
            foreach (string airline in airlines)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Text = airline,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(20, yPos),
                    AutoSize = true,
                    Tag = airline
                };
                //checkBox.CheckedChanged += UpdateSelectedAirlines;
                airlinesGroupBox.Controls.Add(checkBox);
                yPos += 25;
            }
            airlinesGroupBox.Height = yPos + 10;

            // Enhanced stop filtering logic
            bool hasNonStop = flights.Any(f => f.IsNonStop);
            bool hasOneStop = flights.Any(f => !f.IsNonStop && f.StopCount == 1);
            bool hasMultiStop = flights.Any(f => !f.IsNonStop && f.StopCount > 1);

            nonStopRadio.Enabled = hasNonStop;
            oneStopRadio.Enabled = hasOneStop;
            anyStopsRadio.Enabled = hasNonStop || hasOneStop || hasMultiStop;

            nonStopRadio.Text = hasNonStop ? "Non-stop" : "Non-stop (none available)";
            oneStopRadio.Text = hasOneStop ? "1 stop" : "1 stop (none available)";
            anyStopsRadio.Text = "All flights";

            if ((_selectedStopOption == StopOption.NonStop && !hasNonStop) ||
                (_selectedStopOption == StopOption.OneStop && !hasOneStop))
            {
                anyStopsRadio.Checked = true;
            }

            UpdateFilterButtonState();
        }
    }
}
