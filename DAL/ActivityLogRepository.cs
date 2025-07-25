using FlightBookingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FlightBookingSystem.DAL
{
    public class ActivityLogRepository : DbHelper, IActivityLogRepository
    {
        public bool Add(ActivityLog log)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO ActivityLogs 
                               (UserId, ActivityType, Description, Timestamp, IpAddress)
                               VALUES 
                               (@UserId, @ActivityType, @Description, @Timestamp, @IpAddress);
                               SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", log.UserId);
                    cmd.Parameters.AddWithValue("@ActivityType", log.ActivityType);
                    cmd.Parameters.AddWithValue("@Description", log.Description);
                    cmd.Parameters.AddWithValue("@Timestamp", log.Timestamp);
                    cmd.Parameters.AddWithValue("@IpAddress", log.IpAddress ?? (object)DBNull.Value);

                    log.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    return log.Id > 0;
                }
            }
            finally { CloseConnection(); }
        }

        public IEnumerable<ActivityLog> GetAll()
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            try
            {
                OpenConnection();
                string query = @"SELECT al.*, u.Username 
                               FROM ActivityLogs al
                               JOIN Users u ON al.UserId = u.Id
                               ORDER BY al.Timestamp DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(MapLogFromReader(reader));
                    }
                }
            }
            finally { CloseConnection(); }
            return logs;
        }

        public IEnumerable<ActivityLog> GetByUserId(int userId)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            try
            {
                OpenConnection();
                string query = @"SELECT al.*, u.Username 
                               FROM ActivityLogs al
                               JOIN Users u ON al.UserId = u.Id
                               WHERE al.UserId = @UserId
                               ORDER BY al.Timestamp DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(MapLogFromReader(reader));
                        }
                    }
                }
            }
            finally { CloseConnection(); }
            return logs;
        }

        public IEnumerable<ActivityLog> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            List<ActivityLog> logs = new List<ActivityLog>();
            try
            {
                OpenConnection();
                string query = @"SELECT al.*, u.Username 
                               FROM ActivityLogs al
                               JOIN Users u ON al.UserId = u.Id
                               WHERE al.Timestamp BETWEEN @StartDate AND @EndDate
                               ORDER BY al.Timestamp DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(MapLogFromReader(reader));
                        }
                    }
                }
            }
            finally { CloseConnection(); }
            return logs;
        }

        private ActivityLog MapLogFromReader(SqlDataReader reader)
        {
            return new ActivityLog
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                ActivityType = reader.GetString(reader.GetOrdinal("ActivityType")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Timestamp = reader.GetDateTime(reader.GetOrdinal("Timestamp")),
                IpAddress = reader.IsDBNull(reader.GetOrdinal("IpAddress")) ? null : reader.GetString(reader.GetOrdinal("IpAddress")),
                User = new User
                {
                    Username = reader.GetString(reader.GetOrdinal("Username"))
                }
            };
        }
    }
}