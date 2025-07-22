using DotNetEnv;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Net;
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

            string clientId = Environment.GetEnvironmentVariable("AMADEUS_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("AMADEUS_CLIENT_SECRET");

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                throw new Exception("Amadeus credentials not configured");

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            });

            HttpResponseMessage response = await _httpClient.PostAsync(AuthUrl, content);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);
            _accessToken = doc.RootElement.GetProperty("access_token").GetString();
            int expiresIn = doc.RootElement.GetProperty("expires_in").GetInt32();
            _tokenExpiration = DateTime.UtcNow.AddSeconds(expiresIn - 60);

            return _accessToken;
        }

        public async Task<List<Flight>> SearchFlightsAsync(string origin, string destination, DateTime departureDate, string seatClass)
        {
            if (string.IsNullOrEmpty(origin) || origin.Length != 3)
                throw new ArgumentException("Invalid origin airport code");

            if (string.IsNullOrEmpty(destination) || destination.Length != 3)
                throw new ArgumentException("Invalid destination airport code");

            if (departureDate < DateTime.Today)
                throw new ArgumentException("Departure date cannot be in the past");

            if (string.IsNullOrEmpty(seatClass))
                seatClass = "ECONOMY";
            if (!new[] { "ECONOMY", "PREMIUM_ECONOMY", "BUSINESS", "FIRST" }.Contains(seatClass.ToUpper()))
                throw new ArgumentException("Invalid seat class. Valid options are: ECONOMY, PREMIUM_ECONOMY, BUSINESS, FIRST");

            try {
            string token = await GetAccessTokenAsync();

            object request = new
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
                        cabin = seatClass
                    }
                },
                sources = new[] { "GDS" },
                searchCriteria = new { maxFlightOffers = 50 }
            };

            string json = JsonSerializer.Serialize(request);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, FlightOffersUrl)
            {
                Content = httpContent,
                Headers = { { "Authorization", $"Bearer {token}" } }
            };

            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            return await ParseFlightOffers(await response.Content.ReadAsStringAsync());
             }
              catch (HttpRequestException ex) when(ex.StatusCode == HttpStatusCode.TooManyRequests)
               {
                throw new Exception("Too many requests - please wait before searching again");
                }
              catch (HttpRequestException ex) when(ex.StatusCode == HttpStatusCode.InternalServerError)
               {
                throw new Exception("Flight search service is currently unavailable. Please try again later.");
                  }
                catch (Exception ex)
                {
                throw new Exception("Failed to search flights", ex);
                }
        }

        private async Task<List<Flight>> ParseFlightOffers(string json)
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            List<Flight> flights = new List<Flight>();

            foreach (JsonElement offer in root.GetProperty("data").EnumerateArray())
            {
                JsonElement firstItinerary = offer.GetProperty("itineraries")[0];
                JsonElement firstSegment = firstItinerary.GetProperty("segments")[0];
                string price = offer.GetProperty("price").GetProperty("total").GetString();

                JsonElement travelerPricing = offer.GetProperty("travelerPricings")[0];
                string cabinClass = travelerPricing.GetProperty("fareOption").GetString();

                Flight flight = new Flight
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
            durationString = durationString.Replace("PT", "");

            int hours = 0;
            int minutes = 0;

            int hourIndex = durationString.IndexOf('H');
            if (hourIndex > 0)
            {
                hours = int.Parse(durationString.Substring(0, hourIndex));
                durationString = durationString.Substring(hourIndex + 1);
            }

            int minuteIndex = durationString.IndexOf('M');
            if (minuteIndex > 0)
            {
                minutes = int.Parse(durationString.Substring(0, minuteIndex));
            }

            return new TimeSpan(hours, minutes, 0);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}