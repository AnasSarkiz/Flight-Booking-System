using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.Services
{
    public class ActivityLogService
    {
        private readonly IActivityLogRepository _activityLogRepository;

        public ActivityLogService(IActivityLogRepository activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }

        public void LogActivity(int userId, string activityType, string description, string ipAddress = null)
        {
            var log = new ActivityLog
            {
                UserId = userId,
                ActivityType = activityType,
                Description = description,
                IpAddress = ipAddress,
                Timestamp = DateTime.UtcNow
            };

            _activityLogRepository.Add(log);
        }

        public IEnumerable<ActivityLog> GetAllActivities()
        {
            return _activityLogRepository.GetAll();
        }

        public IEnumerable<ActivityLog> GetUserActivities(int userId)
        {
            return _activityLogRepository.GetByUserId(userId);
        }

        public IEnumerable<ActivityLog> GetActivitiesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _activityLogRepository.GetByDateRange(startDate, endDate);
        }
    }
}