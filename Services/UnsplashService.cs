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
        private static readonly ConcurrentDictionary<string, string> _cityImageCache = new ConcurrentDictionary<string, string>();
        private readonly string _cacheFilePath;

        public UnsplashService()
        {
            DotNetEnv.Env.Load();
            _accessKey = Environment.GetEnvironmentVariable("UNSPLASH_Access_Key");
            if (string.IsNullOrEmpty(_accessKey))
            {
                throw new Exception("UNSPLASH_Access_Key not found in environment variables");
            }

            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri(BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Client-ID {_accessKey}");
            _httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");

            _cacheFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "FlightBookingSystem",
                "unsplash_cache.json");

            LoadCacheFromFile();
        }

        public async Task<string> GetCityImageUrl(string cityName, string imageSize = "regular")
        {
            string cacheKey = $"{cityName.ToLowerInvariant()}_{imageSize}";

            if (_cityImageCache.TryGetValue(cacheKey, out string cachedUrl))
            {
                return cachedUrl;
            }

            string cleanCity = Uri.EscapeDataString(cityName.Split('(')[0].Trim());

            HttpResponseMessage response = await _httpClient.GetAsync(
                $"search/photos?query={cleanCity}+city&orientation=landscape&per_page=1");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(content);

            string imageUrl = result?.results[0]?.urls?[imageSize]?.ToString()
                         ?? GetDefaultImageUrl();

            _cityImageCache.TryAdd(cacheKey, imageUrl);
            SaveCacheToFile();

            return imageUrl;
        }

        public async Task<string> GetAirlineLogoUrl(string iataCode)
        {
            iataCode = iataCode?.ToUpper().Trim();

            if (string.IsNullOrWhiteSpace(iataCode) || iataCode.Length != 2)
            {
                return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Airplane_silhouette.svg/512px-Airplane_silhouette.svg.png";
            }

            string logoUrl = $"https://content.airhex.com/content/logos/airlines_{iataCode}_80_80_s.png";

            HttpResponseMessage response = await _httpClient.GetAsync(logoUrl);
            if (response.IsSuccessStatusCode)
                return logoUrl;
            else
                return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Airplane_silhouette.svg/512px-Airplane_silhouette.svg.png";
        }

        private string GetDefaultImageUrl()
        {
            return "https://images.unsplash.com/photo-1500835556837-99ac94a94552?ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80";
        }

        private void LoadCacheFromFile()
        {
            if (File.Exists(_cacheFilePath))
            {
                string json = File.ReadAllText(_cacheFilePath);
                ConcurrentDictionary<string, string> cache = JsonConvert.DeserializeObject<ConcurrentDictionary<string, string>>(json);
                if (cache != null)
                {
                    foreach (KeyValuePair<string, string> item in cache)
                    {
                        _cityImageCache.TryAdd(item.Key, item.Value);
                    }
                }
            }
        }

        private void SaveCacheToFile()
        {
            string directory = Path.GetDirectoryName(_cacheFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonConvert.SerializeObject(_cityImageCache);
            File.WriteAllText(_cacheFilePath, json);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}