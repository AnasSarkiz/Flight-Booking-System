using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class AddEditUserForm : Form
    {
        public string Username => txtUsername.Text;
        public string Email => txtEmail.Text;
        public string Role => cmbRole.SelectedItem.ToString();
        public decimal Balance => decimal.Parse(txtBalance.Text);

        public AddEditUserForm()
        {
            InitializeComponent();
            cmbRole.SelectedIndex = 0;
            txtBalance.Enabled = false;
        }

        public AddEditUserForm(string username, string email, string role, decimal balance) : this()
        {
            txtUsername.Text = username;
            txtEmail.Text = email;
            cmbRole.SelectedItem = role;
            txtBalance.Text = balance.ToString("0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
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
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtBalance.Text, out _))
            {
                MessageBox.Show("Please enter a valid balance", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}