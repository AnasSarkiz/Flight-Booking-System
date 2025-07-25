using FlightBookingSystem.Models;
using System.Collections.Generic;

namespace FlightBookingSystem.DAL
{

    public interface IActivityLogRepository
    {

        bool Add(ActivityLog log);
        IEnumerable<ActivityLog> GetAll();
        IEnumerable<ActivityLog> GetByUserId(int userId);
        IEnumerable<ActivityLog> GetByDateRange(DateTime startDate, DateTime endDate);
    }
}