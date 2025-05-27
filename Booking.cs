using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flight_Booking_System
{
    public partial class Booking : UserControl
    {
        public string SelectedSeat { get; private set; } = "";

        public Booking()
        {
            InitializeComponent();
            ConfigureSeatPanel();
            PopulateSeatButtons();
            businessRadio.CheckedChanged += ClassRadio_CheckedChanged;
            economyRadio.CheckedChanged += ClassRadio_CheckedChanged;
            confirmBtn.Click += ConfirmBtn_Click;
        }

        private void ConfigureSeatPanel()
        {
            seatPanel.RowStyles.Clear();
            for (int i = 0; i < 30; i++)
            {
                seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }
        }

        private void PopulateSeatButtons()
        {
            int totalRows = 30;
            char[] leftSeats = { 'A', 'B', 'C' };
            char[] rightSeats = { 'D', 'E', 'F' };

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (col == 3) continue; // aisle

                    string seatLetter = (col < 3) ? leftSeats[col].ToString() : rightSeats[col - 4].ToString();
                    int rowNumber = row + 1;
                    string seatName = $"{seatLetter}{rowNumber}";

                    var btn = new Button
                    {
                        Text = seatName,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(2),
                        BackColor = Color.LightGreen,
                        Tag = seatName,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand
                    };
                    btn.FlatAppearance.BorderColor = Color.DarkGray;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Click += SeatButton_Click;

                    seatPanel.Controls.Add(btn, col, row);
                }
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (!(sender is Button clickedBtn)) return;

            // Reset all back to LightGreen
            foreach (Control ctl in seatPanel.Controls)
                if (ctl is Button b)
                    b.BackColor = Color.LightGreen;

            // Mark this one as selected
            clickedBtn.BackColor = Color.LightBlue;
            SelectedSeat = clickedBtn.Tag as string;
        }

        private void ClassRadio_CheckedChanged(object sender, EventArgs e)
        {
            // Example: update price as soon as class changes
            if (businessRadio.Checked)
                txtPrice.Text = "$500";
            else if (economyRadio.Checked)
                txtPrice.Text = "$300";
            else
                txtPrice.Text = "";
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPassport.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNationality.Text) ||
                string.IsNullOrEmpty(SelectedSeat) ||
                string.IsNullOrEmpty(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtCardName.Text) ||
                string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
                string.IsNullOrWhiteSpace(txtExpiry.Text) ||
                string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MessageBox.Show(
                    "Please complete all fields, select a seat, and enter payment details.",
                    "Incomplete Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // TODO: Insert booking into database (collect all info here).
            MessageBox.Show(
                $"Booking confirmed:\n\n" +
                $"Name: {txtFirstName.Text} {txtLastName.Text}\n" +
                $"Passport: {txtPassport.Text}\n" +
                $"Email: {txtEmail.Text}\n" +
                $"Nationality: {txtNationality.Text}\n" +
                $"Flight Date: {dobPicker.Value.ToShortDateString()}\n" +
                $"Seat: {SelectedSeat}\n" +
                $"Class: {(businessRadio.Checked ? "Business" : "Economy")}\n" +
                $"Price: {txtPrice.Text}\n\n" +
                $"Payment:\n" +
                $"Card Holder: {txtCardName.Text}\n" +
                $"Card Number: {txtCardNumber.Text}\n" +
                $"Expiry: {txtExpiry.Text}\n" +
                $"CVV: {txtCVV.Text}",
                "Booking Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
