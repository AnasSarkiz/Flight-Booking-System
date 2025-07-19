using FlightBookingSystem.Helpers;
using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.UserMgmtForms
{
    public partial class EditUserForm : Form
    {
        public User UpdatedUser { get; private set; }

        public EditUserForm(User user)
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
            UpdatedUser.FirstName = txtFirstName.Text;
            UpdatedUser.LastName = txtLastName.Text;
            UpdatedUser.UserRole = (User.Role)roleComboBox.SelectedItem;
            UpdatedUser.Balance = decimal.Parse(txtBalance.Text);
            UpdatedUser.IsLocked = chkLocked.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}