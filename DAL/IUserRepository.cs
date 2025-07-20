using FlightBookingSystem.Models;
using System.Collections.Generic;

namespace FlightBookingSystem.DAL
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        User GetById(int id);
        IEnumerable<User> GetAll();
        bool Add(User user, int adminId);
        bool Update(User user);
        bool Delete(int userId);
        bool UsernameExists(string username);
        void UpdateLastLogin(int userId);
        bool UpdateBalance(int userId, decimal amount);
        bool IncrementBookingCount(int userId);
    }
}