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
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public ActivityLogControl(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            _userService = new UserService(_userRepository);
            LoadActivityData();
        }

        private void LoadActivityData()
        {
            try
            {
                // In a real application, you would have an ActivityLogService and Repository
                // For now, we'll simulate getting activity data
                DataTable dt = new DataTable();
                dt.Columns.Add("Timestamp");
                dt.Columns.Add("User");
                dt.Columns.Add("Activity");
                dt.Columns.Add("Details");

                // Get all users to populate the activity log
                var users = _userService.GetAllUsers();

                // Sample activities - in a real app, these would come from a database
                foreach (var user in users)
                {
                    if (user.LastLogin.HasValue)
                    {
                        dt.Rows.Add(
                            user.LastLogin.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                            user.Username,
                            "Login",
                            $"Successful login for {user.Username}"
                        );
                    }

                    // Add other activities as needed
                    dt.Rows.Add(
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        user.Username,
                        "Profile View",
                        $"Viewed profile of {user.Username}"
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
                // Filter the data based on the selected date
                if (logGrid.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = $"Timestamp >= '{datePicker.Value.Date:yyyy-MM-dd}' AND Timestamp < '{datePicker.Value.Date.AddDays(1):yyyy-MM-dd}'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}