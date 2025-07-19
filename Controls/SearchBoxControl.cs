using Flight_Booking_System.Properties;
using FlightBookingSystem.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class SearchBoxControl : UserControl
    {
        public event EventHandler SearchTriggered;

        private List<Airport> _airports;
        private ListBox _suggestionListBox;
        private TextBox _currentTextBox;

        public string Origin => originTextBox.Text.Trim();
        public string Destination => destinationTextBox.Text.Trim();
        public DateTime DepartureDate => departureDatePicker.Value.Date;
        public Airport OriginAirport { get; private set; }
        public Airport DestinationAirport { get; private set; }
        public string GetOriginIata() => OriginAirport?.iata;
        public string GetDestinationIata() => DestinationAirport?.iata;
        public SearchBoxControl()
        {
            InitializeComponent();
            WireUpEvents();
            LoadAirportData();
            InitializeSuggestionListBox();
        }

        private void LoadAirportData()
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string resourcesPath = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\resources\airports.json"));

                string json = File.ReadAllText(resourcesPath);
                var airportDict = JsonSerializer.Deserialize<Dictionary<string, Airport>>(json);

                _airports = airportDict.Values
                    .Where(a => !string.IsNullOrEmpty(a.iata)
                             && !string.IsNullOrEmpty(a.name)
                             && !string.IsNullOrEmpty(a.city)
                             && !string.IsNullOrEmpty(a.country))
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load airport data: {ex.Message}");
                _airports = new List<Airport>();
            }
        }

        private void InitializeSuggestionListBox()
        {
            _suggestionListBox = new ListBox
            {
                Visible = false,
                Font = new Font("Segoe UI", 12F),
                BorderStyle = BorderStyle.FixedSingle,
                Width = originTextBox.Width,
                Height = 150,
                IntegralHeight = false
            };

            _suggestionListBox.Click += SuggestionListBox_Click;
            this.Controls.Add(_suggestionListBox);
            _suggestionListBox.BringToFront();
        }

        private void WireUpEvents()
        {
            searchButton.Click += (s, e) => SearchTriggered?.Invoke(this, EventArgs.Empty);

            originTextBox.TextChanged += TextBox_TextChanged;
            originTextBox.KeyDown += TextBox_KeyDown;
            originTextBox.LostFocus += TextBox_LostFocus;

            destinationTextBox.TextChanged += TextBox_TextChanged;
            destinationTextBox.KeyDown += TextBox_KeyDown;
            destinationTextBox.LostFocus += TextBox_LostFocus;

        }
        public string CabinClass
        {
            get
            {
                return cabinClassComboBox.SelectedItem.ToString().ToUpper();
            }
        }
        public void SetDestination(string destination)
        {
            // Implementation to set the destination in your search box
            destinationTextBox.Text = destination;
        }
        private async void TextBox_LostFocus(object sender, EventArgs e)
        {
            await Task.Delay(200);

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => _suggestionListBox.Visible = false));
            }
            else
            {
                _suggestionListBox.Visible = false;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            _currentTextBox = (TextBox)sender;
            string searchText = _currentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                _suggestionListBox.Visible = false;
                return;
            }

            var suggestions = _airports
                .Where(a => a.name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                           a.city.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                           a.iata.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.name)
                .Take(10)
                .ToList();

            if (suggestions.Any())
            {
                _suggestionListBox.Items.Clear();
                _suggestionListBox.Items.AddRange(suggestions.Select(a => a.DisplayText).ToArray());

                Point location = _currentTextBox.Location;
                location.Y += _currentTextBox.Height;
                _suggestionListBox.Location = location;
                _suggestionListBox.Width = _currentTextBox.Width;
                _suggestionListBox.Visible = true;
            }
            else
            {
                _suggestionListBox.Visible = false;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_suggestionListBox.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (_suggestionListBox.SelectedIndex < _suggestionListBox.Items.Count - 1)
                {
                    _suggestionListBox.SelectedIndex++;
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (_suggestionListBox.SelectedIndex > 0)
                {
                    _suggestionListBox.SelectedIndex--;
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (_suggestionListBox.SelectedIndex >= 0)
                {
                    string selectedText = _suggestionListBox.SelectedItem.ToString();
                    _currentTextBox.Text = selectedText;

                    if (Airport.TryParseFromDisplay(selectedText, _airports, out var airport))
                    {
                        if (_currentTextBox == originTextBox)
                        {
                            OriginAirport = airport;
                        }
                        else if (_currentTextBox == destinationTextBox)
                        {
                            DestinationAirport = airport;
                        }
                    }
                }
                _suggestionListBox.Visible = false;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                _suggestionListBox.Visible = false;
                e.Handled = true;
            }
        }

        private void SuggestionListBox_Click(object sender, EventArgs e)
        {
            if (_suggestionListBox.SelectedIndex >= 0 && _currentTextBox != null)
            {
                string selectedText = _suggestionListBox.SelectedItem.ToString();
                _currentTextBox.Text = selectedText;

                if (Airport.TryParseFromDisplay(selectedText, _airports, out var airport))
                {
                    if (_currentTextBox == originTextBox)
                    {
                        OriginAirport = airport;
                    }
                    else if (_currentTextBox == destinationTextBox)
                    {
                        DestinationAirport = airport;
                    }
                }

                _suggestionListBox.Visible = false;
                _currentTextBox.Focus();
            }
        }
    }
}