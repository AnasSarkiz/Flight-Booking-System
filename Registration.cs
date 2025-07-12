using FlightBookingSystem;
using System;
using System.Windows.Forms;

namespace FlightBooker
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Add your actual authentication logic here
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheck.Checked;
        }
    }
}