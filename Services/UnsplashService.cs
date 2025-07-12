using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DotNetEnv;

namespace FlightBookingSystem.Services
{
    public class UnsplashService
    {
        private const string BaseUrl = "https://api.unsplash.com/";
        private readonly string _accessKey;
        private readonly HttpClient _httpClient;

        public UnsplashService()
        {
            var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
            Console.WriteLine($"Looking for .env at: {envPath}");
            Console.WriteLine($"File exists: {File.Exists(envPath)}");

            DotNetEnv.Env.Load();

            Console.WriteLine("Loaded environment variables:");
            foreach (System.Collections.DictionaryEntry env in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{env.Key}={env.Value}");
            }

            var accessKey = Environment.GetEnvironmentVariable("UNSPLASH_Access_Key");
            if (string.IsNullOrEmpty(accessKey))
            {
                throw new Exception(".env file found but UNSPLASH_Access_Key not loaded. Check:\n" +
                                  "1. .env file formatting\n" +
                                  "2. Variable name spelling\n" +
                                  $"Current directory: {Directory.GetCurrentDirectory()}");
            }
            // Initialize HttpClient
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri(BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Client-ID {_accessKey}");
            _httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");
        }

        public async Task<string> GetCityImageUrl(string cityName, string imageSize = "regular")
        {
            try
            {
                // Clean city name (remove airport code if present)
                var cleanCity = Uri.EscapeDataString(cityName.Split('(')[0].Trim());

                // API request
                var response = await _httpClient.GetAsync(
                    $"search/photos?query={cleanCity}+city&orientation=landscape&per_page=1");

                response.EnsureSuccessStatusCode();

                // Parse response
                var content = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(content);

                // Return the requested image size (defaults to 'regular')
                return result?.results[0]?.urls?[imageSize]?.ToString()
                       ?? GetDefaultImageUrl();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error fetching Unsplash image: {ex.Message}");
                return GetDefaultImageUrl();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Unsplash image: {ex.Message}");
                return GetDefaultImageUrl();
            }
        }

        public async Task<string> GetAirlineLogoUrl(string airlineName)
        {
            try
            {
                // Clean airline name
                var cleanName = Uri.EscapeDataString(airlineName
                    .Replace(" ", "")
                    .ToLower());

                return $"https://logo.clearbit.com/{cleanName}.com";
            }
            catch
            {
                return "https://logo.clearbit.com/example.com"; // Fallback logo
            }
        }

        private string GetDefaultImageUrl()
        {
            // Default travel image from Unsplash
            return "https://images.unsplash.com/photo-1500835556837-99ac94a94552?ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80";
        }

        // Dispose pattern for HttpClient
        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}