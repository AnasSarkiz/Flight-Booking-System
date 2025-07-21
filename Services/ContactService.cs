using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        private const string SystemId = "129381741827871";

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ContactMessage>> GetAllMessagesAsync()
        {
            try
            {
                string url = $"http://dev2.alashiq.com/message.php?systemId={SystemId}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new DateTimeConverter() }
                };

                MessageResponse result = await JsonSerializer.DeserializeAsync<MessageResponse>(
                    await response.Content.ReadAsStreamAsync(), options);

                return result.Success ? result.Data.Messages : new List<ContactMessage>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to fetch messages", ex);
            }
        }

        public async Task<bool> SendContactMessage(int userId, string username, string messageContent)
        {
            try
            {
                object requestData = new
                {
                    user_id = userId,
                    username = username,
                    message = messageContent
                };

                string json = JsonSerializer.Serialize(requestData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(
                    $"http://dev2.alashiq.com/send.php?systemId={SystemId}", content);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId)
        {
            try
            {
                object requestData = new { message_id = messageId };
                string json = JsonSerializer.Serialize(requestData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(
                    $"http://dev2.alashiq.com/message_read.php?systemId={SystemId}", content);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private class DateTimeConverter : JsonConverter<DateTime>
        {
            private const string Format = "yyyy-MM-dd HH:mm:ss";

            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    string dateString = reader.GetString();
                    if (DateTime.TryParseExact(dateString, Format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime date))
                    {
                        return date;
                    }
                }
                return DateTime.MinValue;
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(Format));
            }
        }
    }
}