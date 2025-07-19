using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class EditUserControl : UserControl
    {
        public event EventHandler<User> UserUpdated;
        public event EventHandler Cancelled;

        public User UpdatedUser { get; private set; }

        public EditUserControl(User user)
        {
            InitializeComponent();
            UpdatedUser = user;

            // Populate form
            txtUsername.Text = user.Username;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            roleComboBox.DataSource = Enum.GetValues(typeof(User.Role));
            roleComboBox.SelectedItem = user.UserRole;
            txtBalance.Text = user.Balance.ToString("0.00");
            chkLocked.Checked = user.IsLocked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatedUser.FirstName = txtFirstName.Text;
                UpdatedUser.LastName = txtLastName.Text;
                UpdatedUser.UserRole = (User.Role)roleComboBox.SelectedItem;
                UpdatedUser.Balance = decimal.Parse(txtBalance.Text);
                UpdatedUser.IsLocked = chkLocked.Checked;

                UserUpdated?.Invoke(this, UpdatedUser);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid balance amount", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled?.Invoke(this, EventArgs.Empty);
        }
    }
}