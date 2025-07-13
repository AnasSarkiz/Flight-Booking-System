using System;
using System.Data;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class ActivityLogControl : UserControl
    {
        public ActivityLogControl()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Timestamp");
            dt.Columns.Add("User");
            dt.Columns.Add("Activity");
            dt.Columns.Add("Details");

            dt.Rows.Add("2023-05-15 14:30:22", "admin", "Login", "Successful login from 192.168.1.1");
            dt.Rows.Add("2023-05-15 14:35:18", "admin", "User Edit", "Modified user 'user1'");
            dt.Rows.Add("2023-05-15 15:02:45", "user1", "Flight Search", "Searched for flights to Paris");
            dt.Rows.Add("2023-05-15 15:30:10", "user2", "Booking", "Booked flight AA123");

            logGrid.DataSource = dt;
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            // In a real application, this would filter the log data
            MessageBox.Show($"Filtering logs for {datePicker.Value.ToShortDateString()}", "Filter Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}