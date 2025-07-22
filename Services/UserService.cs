using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username and password are required.");

            User user = _userRepo.Authenticate(username, password);

            if (user == null)
                throw new Exception("Invalid credentials.");

            if (user.IsLocked)
                throw new Exception("Account is locked. Contact support.");

            _userRepo.UpdateLastLogin(user.Id);
            return user;
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }

        public void AddUser(User newUser, int adminId)
        {
            if (_userRepo.UsernameExists(newUser.Username))
                throw new Exception("Username already exists.");

            if (string.IsNullOrEmpty(newUser.PasswordHash))
                throw new Exception("Password is required.");

            if (!_userRepo.Add(newUser, adminId))
                throw new Exception("Failed to create user.");
        }

        public bool UpdateUser(User user)
        {
            if (!_userRepo.Update(user))
                throw new Exception("Failed to update user.");
            return true;
        }

        public void DeleteUser(int userId)
        {
            if (!_userRepo.Delete(userId))
                throw new Exception("Failed to delete user.");
        }

        public bool LockUnlockUser(int userId, bool lockStatus)
        {
            User user = _userRepo.GetById(userId);
            if (user == null) return false;

            user.IsLocked = lockStatus;
            return _userRepo.Update(user);
        }

        public bool UpdateUserBalance(int userId, decimal amount)
        {
            return _userRepo.UpdateBalance(userId, amount);
        }

        public bool DecreaseUserBalance(int userId, decimal amount)
        {
            User user = _userRepo.GetById(userId);
            if (user == null) return false;

            if (user.Balance < amount)
            {
                throw new Exception("Insufficient balance for this transaction");
            }

            return UpdateUserBalance(userId, -amount);
        }

        public bool IncrementUserBookingCount(int userId)
        {
            return _userRepo.IncrementBookingCount(userId);
        }

        public bool ChangeUserRole(int userId, User.Role newRole)
        {
            User user = _userRepo.GetById(userId);
            if (user == null) return false;

            user.UserRole = newRole;
            return _userRepo.Update(user);
        }
    }
}