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
        private readonly UserService _userService;
        private readonly User _currentUser;

        public UserProfileControl(UserService userService, User currentUser)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                lblName.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
                lblEmail.Text = _currentUser.Username;
                lblMemberSince.Text = $"Member since: {_currentUser.DateCreated:MMMM yyyy}";
                lblTotalBookings.Text = $"{_currentUser.NumberOfBookings}";
                lblBalance.Text = $"{_currentUser.Balance:C}";

                // Set user role
                lblRole.Text = _currentUser.UserRole == User.Role.Admin ? "Administrator" : "Standard User";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Do you want to edit your profile?", "Edit Profile",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _userService.UpdateUser(_currentUser);
                    MessageBox.Show("Profile updated successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}