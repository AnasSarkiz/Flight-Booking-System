using FlightBookingSystem.Helpers;
using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.UserMgmtForms
{
    public partial class TopUpForm : Form
    {
        public decimal TopUpAmount { get; private set; }
        private readonly decimal currentBalance;

        public TopUpForm(decimal currentBalance)
        {
            InitializeComponent();
            this.currentBalance = currentBalance;
            lblCurrentBalance.Text = currentBalance.ToString("C");
            UpdateNewBalanceDisplay();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && amount > 0)
            {
                TopUpAmount = amount;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid positive amount", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateNewBalanceDisplay();
        }

        private void UpdateNewBalanceDisplay()
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                lblNewBalance.Text = (currentBalance + amount).ToString("C");
            }
            else
            {
                lblNewBalance.Text = currentBalance.ToString("C");
            }
        }
    }
}