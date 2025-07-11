using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class FilterPanelControl : UserControl
    {
        public enum SortOption { Price, Duration, DepartureTime }

        public event EventHandler SortChanged;

        private SortOption _selectedSortOption = SortOption.Price;
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

        public FilterPanelControl()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
         
        }
    }
}