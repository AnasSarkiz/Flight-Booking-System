using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Services
{
    public interface IApiService
    {
        Task<AboutUsResponse> GetAboutUsDataAsync();
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AboutUsResponse> GetAboutUsDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://dev2.alashiq.com/about.php");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AboutUsResponse>(content);
            }
            catch (Exception ex)
            {
                // Log the error here if needed
                throw new ApplicationException("Failed to fetch about us data", ex);
            }
        }
    }
}