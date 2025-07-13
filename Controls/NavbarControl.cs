using System;
using System.Drawing;
using System.Windows.Forms;

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

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                UpdateProfileMenu();
            }
        }

        public NavbarControl()
        {
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

            // User profile item
            var userItem = new ToolStripMenuItem("User Profile");
            userItem.Click += (s, e) => UserProfileClicked?.Invoke(this, e);
            //userItem.Image = Image.FromFile("./resources/img/user.png");

            // Contact Us item
            var contactItem = new ToolStripMenuItem("Contact Us");
            contactItem.Click += (s, e) => ContactUsClicked?.Invoke(this, e);
            //userItem.Image = Image.FromFile("./resources/img/contact.png");

            // About Us item
            var aboutItem = new ToolStripMenuItem("About Us");
            aboutItem.Click += (s, e) => AboutUsClicked?.Invoke(this, e);
            //userItem.Image = Image.FromFile("./resources/img/about.png");

            // Separator
            var separator = new ToolStripSeparator();

            // Add all items to menu
            profileMenu.Items.Add(userItem);
            profileMenu.Items.Add(contactItem);
            profileMenu.Items.Add(aboutItem);
            profileMenu.Items.Add(separator);

            // Admin-only items
            if (true)
            {
                var userManagementItem = new ToolStripMenuItem("User Management");
                userManagementItem.Click += (s, e) => UserManagementClicked?.Invoke(this, e);
                //userItem.Image = Image.FromFile("./resources/img/user.png");

                var activityLogItem = new ToolStripMenuItem("Activity Log");
                activityLogItem.Click += (s, e) => ActivityLogClicked?.Invoke(this, e);
                //userItem.Image = Image.FromFile("./resources/img/logout.png");

                profileMenu.Items.Add(userManagementItem);
                profileMenu.Items.Add(activityLogItem);
                profileMenu.Items.Add(new ToolStripSeparator());
            }

            // Logout item
            var logoutItem = new ToolStripMenuItem("Logout");
            logoutItem.Click += (s, e) => LogoutClicked?.Invoke(this, e);
            //logoutItem.Image = Properties.Resources.LogoutIcon;

            profileMenu.Items.Add(logoutItem);
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