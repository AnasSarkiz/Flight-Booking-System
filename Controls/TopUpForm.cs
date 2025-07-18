using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class TopUpForm : Form
    {
        public decimal NewBalance => currentBalance + topUpAmount;
        private decimal currentBalance;
        private decimal topUpAmount => decimal.Parse(txtAmount.Text);

        public TopUpForm(string username, decimal currentBalance)
        {
            InitializeComponent();
            lblUsername.Text = username;
            this.currentBalance = currentBalance;
            lblCurrentBalance.Text = currentBalance.ToString("0.00");
        }

        private void btnTopUp_Click(object sender, EventArgs e)
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
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                lblNewBalance.Text = (currentBalance + amount).ToString("0.00");
            }
            else
            {
                lblNewBalance.Text = "Invalid amount";
            }
        }
    }
}