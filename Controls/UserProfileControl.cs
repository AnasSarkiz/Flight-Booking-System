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
        public event EventHandler BalanceUpdated;

        private readonly UserService _userService;
        private User _currentUser;
        private Button btnEditProfile; // Add this declaration
        private Button btnTopUp; // Add this declaration

        public UserProfileControl(UserService userService, User currentUser)
        {
            InitializeComponent();
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            // Initialize buttons
            btnEditProfile = new Button
            {
                Text = "Edit Profile",
                Location = new Point(20, 150),
                Size = new Size(100, 30)
            };
            btnEditProfile.Click += btnEditProfile_Click;
            this.Controls.Add(btnEditProfile);

            btnTopUp = new Button
            {
                Text = "Top Up Balance",
                Location = new Point(btnEditProfile.Right + 10, btnEditProfile.Top),
                Size = btnEditProfile.Size
            };
            btnTopUp.Click += BtnTopUp_Click;
            this.Controls.Add(btnTopUp);

            LoadUserProfile();
        }

        private void BtnTopUp_Click(object sender, EventArgs e)
        {
            var topUpControl = new TopUpControl(_currentUser.Balance);
            var form = new Form
            {
                Text = "Top Up Balance",
                Size = new Size(350, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            topUpControl.Dock = DockStyle.Fill;
            form.Controls.Add(topUpControl);

            topUpControl.TopUpConfirmed += (s, amount) =>
            {
                try
                {
                    bool success = _userService.UpdateUserBalance(_currentUser.Id, amount);
                    if (success)
                    {
                        _currentUser = _userService.GetUserById(_currentUser.Id);
                        LoadUserProfile();
                        BalanceUpdated?.Invoke(this, EventArgs.Empty);
                        form.DialogResult = DialogResult.OK;
                        form.Close();
                        MessageBox.Show("Balance updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            topUpControl.Cancelled += (s, args) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            form.ShowDialog();
        }

        public void RefreshUserData()
        {
            try
            {
                _currentUser = _userService.GetUserById(_currentUser.Id);
                LoadUserProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing user data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    bool success = _userService.UpdateUser(_currentUser);
                    if (success)
                    {
                        _currentUser = _userService.GetUserById(_currentUser.Id);
                        LoadUserProfile();
                        MessageBox.Show("Profile updated successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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