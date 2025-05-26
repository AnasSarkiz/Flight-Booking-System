using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Booking_System
{
    public partial class Booking : UserControl
    {
        public Booking()
        {
            InitializeComponent();
            for (int i = 1; i <= 30; i++)
                this.seatCombo.Items.Add($"Seat {i}");
        }
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            string flightClass = economyRadio.Checked ? "Economy" : "Business";
            string message = $"Booking Confirmed:\n\n" +
                             $"Name: {txtFirstName.Text} {txtLastName.Text}\n" +
                             $"Passport: {txtPassport.Text}\n" +
                             $"Nationality: {txtNationality.Text}\n" +
                             $"DOB: {dobPicker.Value.ToShortDateString()}\n" +
                             $"Email: {txtEmail.Text}\n" +
                             $"Seat: {seatCombo.SelectedItem}\n" +
                             $"Class: {flightClass}\n" +
                             $"Card: {txtCardNumber.Text}";

            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     
    }
}
