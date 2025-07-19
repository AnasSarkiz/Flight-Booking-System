using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class TopUpControl : UserControl
    {
        public event EventHandler<decimal> TopUpConfirmed;
        public event EventHandler Cancelled;

        public decimal TopUpAmount { get; private set; }
        private readonly decimal currentBalance;

        public TopUpControl(decimal currentBalance)
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
                TopUpConfirmed?.Invoke(this, amount);
            }
            else
            {
                MessageBox.Show("Please enter a valid positive amount", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled?.Invoke(this, EventArgs.Empty);
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