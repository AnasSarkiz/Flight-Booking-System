using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DotNetEnv;
using System.Collections.Concurrent;
using System.IO;

namespace FlightBookingSystem.Services
{
    public class UnsplashService : IDisposable
    {
        private const string BaseUrl = "https://api.unsplash.com/";
        private readonly string _accessKey;
        private readonly HttpClient _httpClient;

        // Cache for city image URLs
        private static readonly ConcurrentDictionary<string, string> _cityImageCache = new ConcurrentDictionary<string, string>();
        // Cache file path
        private readonly string _cacheFilePath;

        public UnsplashService()
        {
            // Load environment variables
            var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
            DotNetEnv.Env.Load();

            _accessKey = Environment.GetEnvironmentVariable("UNSPLASH_Access_Key");
            if (string.IsNullOrEmpty(_accessKey))
            {
                throw new Exception("UNSPLASH_Access_Key not found in environment variables");
            }

            // Initialize HttpClient
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri(BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Client-ID {_accessKey}");
            _httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");

            // Set up cache file path
            _cacheFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "FlightBookingSystem",
                "unsplash_cache.json");

            // Load cache from file if exists
            LoadCacheFromFile();
        }

        public async Task<string> GetCityImageUrl(string cityName, string imageSize = "regular")
        {
            // Create cache key with city name and size
            var cacheKey = $"{cityName.ToLowerInvariant()}_{imageSize}";

            // Check cache first
            if (_cityImageCache.TryGetValue(cacheKey, out var cachedUrl))
            {
                return cachedUrl;
            }

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

                // Get the requested image size (defaults to 'regular')
                var imageUrl = result?.results[0]?.urls?[imageSize]?.ToString()
                             ?? GetDefaultImageUrl();

                // Add to cache
                _cityImageCache.TryAdd(cacheKey, imageUrl);
                SaveCacheToFile();

                return imageUrl;
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

        public async Task<string> GetAirlineLogoUrl(string iataCode)
        {
            iataCode = iataCode?.ToUpper().Trim();

            if (string.IsNullOrWhiteSpace(iataCode) || iataCode.Length != 2)
            {
                return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Airplane_silhouette.svg/512px-Airplane_silhouette.svg.png";
            }

            // AirHex image URL (assuming you're using the free CDN version)
            var logoUrl = $"https://content.airhex.com/content/logos/airlines_{iataCode}_80_80_s.png";

            // Optional: Validate the logo exists
            try
            {
                var response = await _httpClient.GetAsync(logoUrl);
                if (response.IsSuccessStatusCode)
                    return logoUrl;
                else
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Airplane_silhouette.svg/512px-Airplane_silhouette.svg.png";
            }
            catch
            {
                 return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Airplane_silhouette.svg/512px-Airplane_silhouette.svg.png";
            }
        }

     


        private string GetDefaultImageUrl()
        {
            return "https://images.unsplash.com/photo-1500835556837-99ac94a94552?ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80";
        }

        private void LoadCacheFromFile()
        {
            try
            {
                if (File.Exists(_cacheFilePath))
                {
                    var json = File.ReadAllText(_cacheFilePath);
                    var cache = JsonConvert.DeserializeObject<ConcurrentDictionary<string, string>>(json);
                    if (cache != null)
                    {
                        foreach (var item in cache)
                        {
                            _cityImageCache.TryAdd(item.Key, item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading cache file: {ex.Message}");
            }
        }

        private void SaveCacheToFile()
        {
            try
            {
                var directory = Path.GetDirectoryName(_cacheFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var json = JsonConvert.SerializeObject(_cityImageCache);
                File.WriteAllText(_cacheFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cache file: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}