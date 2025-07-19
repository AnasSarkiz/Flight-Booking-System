using DotNetEnv;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static FlightBookingSystem.Models.Flight;

namespace FlightBookingSystem.Services
{
    public class AmadeusService : IDisposable
    {
        private const string AuthUrl = "https://test.api.amadeus.com/v1/security/oauth2/token";
        private const string FlightOffersUrl = "https://test.api.amadeus.com/v2/shopping/flight-offers";

        private readonly HttpClient _httpClient;
        private string _accessToken;
        private DateTime _tokenExpiration;

        public AmadeusService()
        {
            Env.Load();
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_accessToken) && DateTime.UtcNow < _tokenExpiration)
                return _accessToken;

            var clientId = Environment.GetEnvironmentVariable("AMADEUS_CLIENT_ID");
            var clientSecret = Environment.GetEnvironmentVariable("AMADEUS_CLIENT_SECRET");

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                throw new Exception("Amadeus credentials not configured");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            });

            var response = await _httpClient.PostAsync(AuthUrl, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            _accessToken = doc.RootElement.GetProperty("access_token").GetString();
            var expiresIn = doc.RootElement.GetProperty("expires_in").GetInt32();
            _tokenExpiration = DateTime.UtcNow.AddSeconds(expiresIn - 60);

            return _accessToken;
        }

        public async Task<List<Flight>> SearchFlightsAsync(string origin, string destination, DateTime departureDate,string SeatClass )
        {
            var token = await GetAccessTokenAsync();

            // Create initial originDestinations list
            var originDestinations = new List<object>
    {
        new
        {
            id = "1",
            originLocationCode = origin,
            destinationLocationCode = destination,
            departureDateTimeRange = new
            {
                date = departureDate.ToString("yyyy-MM-dd")
            }
        }
    };


            var request = new
            {
                currencyCode = "USD",
                originDestinations = new[]
      {
        new
        {
            id = "1",
            originLocationCode = origin,
            destinationLocationCode = destination,
            departureDateTimeRange = new
            {
                date = departureDate.ToString("yyyy-MM-dd")
            }
        }
    },
                travelers = new[]
      {
        new
        {
            id = "1",
            travelerType = "ADULT",
            fareOptions = new[] { "STANDARD" },
            cabin = SeatClass  
        }
    },
                sources = new[] { "GDS" },
                searchCriteria = new { maxFlightOffers = 50 }
            };

            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, FlightOffersUrl)
            {
                Content = httpContent,
                Headers = { { "Authorization", $"Bearer {token}" } }
            };

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            return await ParseFlightOffers(await response.Content.ReadAsStringAsync());
        }

        private async Task<List<Flight>> ParseFlightOffers(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var flights = new List<Flight>();

            foreach (var offer in root.GetProperty("data").EnumerateArray())
            {
                var firstItinerary = offer.GetProperty("itineraries")[0];
                var firstSegment = firstItinerary.GetProperty("segments")[0];
                var price = offer.GetProperty("price").GetProperty("total").GetString();

                var travelerPricing = offer.GetProperty("travelerPricings")[0];
                var cabinClass = travelerPricing.GetProperty("fareOption").GetString();

                var flight = new Flight
                {
                    FlightNumber = firstSegment.GetProperty("number").GetString(),
                    Airline = firstSegment.GetProperty("carrierCode").GetString(),
                    Origin = firstSegment.GetProperty("departure").GetProperty("iataCode").GetString(),
                    Destination = firstSegment.GetProperty("arrival").GetProperty("iataCode").GetString(),
                    DepartureTime = DateTime.Parse(firstSegment.GetProperty("departure").GetProperty("at").GetString()),
                    ArrivalTime = DateTime.Parse(firstSegment.GetProperty("arrival").GetProperty("at").GetString()),
                    Price = decimal.Parse(price),
                    Duration = ParseDuration(firstItinerary.GetProperty("duration").GetString()),
                    SeatClass = cabinClass ?? "ECONOMY",
                    Stops = firstItinerary.GetProperty("segments").GetArrayLength() - 1
                };

                flights.Add(flight);
            }

            return flights;
                }
        

        private TimeSpan ParseDuration(string durationString)
        {
            // Remove "PT" prefix
            durationString = durationString.Replace("PT", "");

            int hours = 0;
            int minutes = 0;

            // Check for hours
            var hourIndex = durationString.IndexOf('H');
            if (hourIndex > 0)
            {
                hours = int.Parse(durationString.Substring(0, hourIndex));
                durationString = durationString.Substring(hourIndex + 1);
            }

            // Check for minutes
            var minuteIndex = durationString.IndexOf('M');
            if (minuteIndex > 0)
            {
                minutes = int.Parse(durationString.Substring(0, minuteIndex));
            }

            return new TimeSpan(hours, minutes, 0);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}