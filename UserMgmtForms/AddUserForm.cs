using FlightBookingSystem.Helpers;
using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.UserMgmtForms
{
    public partial class AddUserForm : Form
    {
        public User NewUser { get; private set; }

        public AddUserForm(User currentUser)
        {
            InitializeComponent();
            roleComboBox.DataSource = Enum.GetValues(typeof(User.Role));
            roleComboBox.SelectedItem = User.Role.User;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                NewUser = new User
                {
                    Username = txtUsername.Text,
                    PasswordHash = txtPassword.Text, 

                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserRole = (User.Role)roleComboBox.SelectedItem,
                    Balance = 0
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateInput()
        {
            string debugPlainPassword = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}