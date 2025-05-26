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

            if (true)
            {
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
