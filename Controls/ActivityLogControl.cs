using System;
using System.Data;
using System.Windows.Forms;
using FlightBookingSystem.Services;
using FlightBookingSystem.Models;
using FlightBookingSystem.DAL;

namespace FlightBookingSystem.Controls
{
    public partial class ActivityLogControl : UserControl
    {
        private readonly ActivityLogService _activityLogService;

        public ActivityLogControl(IActivityLogRepository activityLogRepository)
        {
            InitializeComponent();
            _activityLogService = new ActivityLogService(activityLogRepository);
            LoadActivityData();
        }

        private void LoadActivityData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Timestamp");
                dt.Columns.Add("User");
                dt.Columns.Add("Activity");
                dt.Columns.Add("Details");

                var activities = _activityLogService.GetAllActivities();

                foreach (var activity in activities)
                {
                    dt.Rows.Add(
                        activity.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                        activity.User.Username,
                        activity.ActivityType,
                        activity.Description
                    );
                }

                logGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading activity data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (logGrid.DataSource is DataTable dataTable)
                {
                    DateTime selectedDate = datePicker.Value.Date;
                    DateTime nextDay = selectedDate.AddDays(1);

                    dataTable.DefaultView.RowFilter = $"Timestamp >= '{selectedDate:yyyy-MM-dd}' AND Timestamp < '{nextDay:yyyy-MM-dd}'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadActivityData();
        }
    }
}