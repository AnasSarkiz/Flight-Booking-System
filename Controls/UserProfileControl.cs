using System;
using System.Drawing;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
namespace FlightBookingSystem.Controls
{
    public partial class UserProfileControl : UserControl
    {
        public event EventHandler BackRequested;

        public UserProfileControl()
        {
            InitializeComponent();
            SetupProfileData();
        }

        private void SetupProfileData()
        {

            // Sample data - replace with actual user data
            lblName.Text = "John Doe";
            lblEmail.Text = "john.doe@example.com";
            lblMemberSince.Text = "Member since: January 2023";
            lblTotalBookings.Text = "Total bookings: 12";
            lblBalance.Text = "Current balance: $150.00";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit profile functionality would go here",
                          "Edit Profile",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}