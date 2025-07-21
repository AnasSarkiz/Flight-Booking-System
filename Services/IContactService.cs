using FlightBookingSystem.Models;

namespace FlightBookingSystem.Services
{
    public interface IContactService
    {
        Task<bool> SendContactMessage(int userId, string username, string message);
        Task<IEnumerable<ContactMessage>> GetAllMessagesAsync();
        Task<bool> MarkMessageAsReadAsync(int messageId);
    }
}