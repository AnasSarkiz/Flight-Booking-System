using System;
using System.Drawing;
using FlightBookingSystem.Models;
namespace FlightBookingSystem.Controls
{
    public partial class NavbarControl : UserControl
    {
        public event EventHandler HomeClicked;
        public event EventHandler SearchFlightsClicked;
        public event EventHandler BookingsClicked;
        public event EventHandler LogoutClicked;
        public event EventHandler ContactUsClicked;
        public event EventHandler AboutUsClicked;
        public event EventHandler UserManagementClicked;
        public event EventHandler ActivityLogClicked;
        public event EventHandler UserProfileClicked;
        private bool _isAdmin;

        public NavbarControl(User.Role userRole)
        {
            _isAdmin = userRole == User.Role.Admin;
            InitializeComponent();
            WireUpEvents();
            SetActiveButton(homeButton);
            UpdateProfileMenu();
        }

        private void WireUpEvents()
        {
            homeButton.Click += (s, e) =>
            {
                HomeClicked?.Invoke(this, e);
                SetActiveButton(homeButton);
            };

            searchFlightsButton.Click += (s, e) =>
            {
                SearchFlightsClicked?.Invoke(this, e);
                SetActiveButton(searchFlightsButton);
            };

            bookingsButton.Click += (s, e) =>
            {
                BookingsClicked?.Invoke(this, e);
                SetActiveButton(bookingsButton);
            };
            profileButton.Click += (s, e) =>
            {
              
                profileMenu.Show(profileButton, new Point(0, profileButton.Height));
            };
        }

        private void UpdateProfileMenu()
        {
            profileMenu.Items.Clear();

            try
            {
                ToolStripMenuItem userItem = new ToolStripMenuItem("User Profile");
                userItem.Click += (s, e) => UserProfileClicked?.Invoke(this, e);

                ToolStripMenuItem contactItem = new ToolStripMenuItem("Contact Us");
                contactItem.Click += (s, e) => ContactUsClicked?.Invoke(this, e);

                ToolStripMenuItem aboutItem = new ToolStripMenuItem("About Us");
                aboutItem.Click += (s, e) => AboutUsClicked?.Invoke(this, e);

                ToolStripSeparator separator1 = new ToolStripSeparator();

                if (_isAdmin)
                {
                    ToolStripMenuItem userManagementItem = new ToolStripMenuItem("User Management");
                    userManagementItem.Click += (s, e) => UserManagementClicked?.Invoke(this, e);

                    ToolStripMenuItem activityLogItem = new ToolStripMenuItem("Activity Log");
                    activityLogItem.Click += (s, e) => ActivityLogClicked?.Invoke(this, e);

                    profileMenu.Items.Add(userManagementItem);
                    profileMenu.Items.Add(activityLogItem);
                    profileMenu.Items.Add(new ToolStripSeparator());
                }

                ToolStripMenuItem quitItem = new ToolStripMenuItem("Quit");
                quitItem.Click += (s, e) => Application.Exit();
                quitItem.ForeColor = Color.Red;

                ToolStripMenuItem logoutItem = new ToolStripMenuItem("Logout");
                logoutItem.Click += (s, e) => LogoutClicked?.Invoke(this, e);

                profileMenu.Items.Add(userItem);
                profileMenu.Items.Add(contactItem);
                profileMenu.Items.Add(aboutItem);
                profileMenu.Items.Add(separator1);

                profileMenu.Items.Add(logoutItem);
                profileMenu.Items.Add(quitItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading menu: {ex.Message}");
            }
        }
        private void SetActiveButton(Button activeButton)
        {
            activeIndicator.Location = new Point(
                activeButton.Location.X,
                activeButton.Location.Y + activeButton.Height - 3);
            activeIndicator.Width = activeButton.Width;
        }
    }
}