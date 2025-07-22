using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class AddUserControl : UserControl
    {
        public event EventHandler<User> UserAdded;
        public event EventHandler Cancelled;

        public AddUserControl()
        {
            InitializeComponent();
            roleComboBox.DataSource = Enum.GetValues(typeof(User.Role));
            roleComboBox.SelectedItem = User.Role.User;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                User newUser = new User
                {
                    Username = txtUsername.Text,
                    PasswordHash = txtPassword.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserRole = (User.Role)roleComboBox.SelectedItem,
                    Balance = 0
                };
                UserAdded?.Invoke(this, newUser);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled?.Invoke(this, EventArgs.Empty);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Username is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Password is required");
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                ShowError("Password must be at least 8 characters");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}