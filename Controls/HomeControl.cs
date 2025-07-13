using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.IO;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.Controls
{
    public partial class HomeControl : UserControl
    {
        public event EventHandler ExploreFlightsClicked;
        public event EventHandler<string> PromotionClicked;
        private readonly string[] cities = { "Paris", "Tokyo", "New York", "Dubai", "London", "Rome", "Sydney", "Barcelona" };

        private readonly UnsplashService _unsplashService;

        public HomeControl(UnsplashService unsplashService)
        {
            _unsplashService = unsplashService ?? throw new ArgumentNullException(nameof(unsplashService));
            InitializeComponent();
            WireUpEvents();
            _ = LoadPromotionImagesAsync();
        }

        private void WireUpEvents()
        {
            exploreButton.Click += (s, e) => ExploreFlightsClicked?.Invoke(this, e);
            for (int i = 0; i < cities.Length; i++)
            {
                int index = i;
                cityButtons[i].Click += (s, e) => PromotionClicked?.Invoke(this, cities[index]);
            }
        }

        private async Task LoadPromotionImagesAsync()
        {
            try
            {
                var tasks = new Task[cities.Length];
                for (int i = 0; i < cities.Length; i++)
                {
                    int index = i;
                    tasks[i] = LoadCityImageAsync(cityImages[index], cities[index]);
                }
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading images: {ex.Message}");
            }
        }

        private async Task LoadCityImageAsync(PictureBox pictureBox, string cityName)
        {
            try
            {
                var imageUrl = await _unsplashService.GetCityImageUrl(cityName);
                using (var httpClient = new HttpClient())
                {
                    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                // fallback placeholder
                using (var bmp = new Bitmap(pictureBox.Width, pictureBox.Height))
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.LightGray);
                    using (var font = new Font("Segoe UI", 12))
                    {
                        g.DrawString(cityName, font, Brushes.DarkGray, new PointF(10, pictureBox.Height / 2 - 10));
                    }
                    pictureBox.Image = (Image)bmp.Clone();
                }
            }
        }
    }
}