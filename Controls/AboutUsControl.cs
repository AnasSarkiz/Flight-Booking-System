// AboutUsControl.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using FlightBookingSystem.Services;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Controls
{
    public partial class AboutUsControl : UserControl
    {
        private readonly IApiService _apiService;

        public AboutUsControl(IApiService apiService)
        {
            _apiService = apiService;
            InitializeComponent();
            LoadAboutUsData();
        }

        private async void LoadAboutUsData()
        {
            try
            {
                AboutUsResponse aboutData = await _apiService.GetAboutUsDataAsync();

                if (aboutData?.Success == true)
                {
                    titleLabel.Text = aboutData.Data.Title;
                    aboutTextLabel.Text = aboutData.Data.Description;
                }
                else
                {
                    aboutTextLabel.Text = "Failed to load about us information.";
                }
            }
            catch (Exception ex)
            {
                aboutTextLabel.Text = $"Error loading about us: {ex.Message}";
            }
        }
    }
}