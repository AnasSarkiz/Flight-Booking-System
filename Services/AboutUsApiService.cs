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

    public class AboutUsApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public AboutUsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AboutUsResponse> GetAboutUsDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://dev2.alashiq.com/about.php");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AboutUsResponse>(content);
        }
    }
}