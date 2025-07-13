using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class ContactUsControl : UserControl
    {
        public ContactUsControl()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Handle form submission
            MessageBox.Show("Thank you for your message! We'll get back to you soon.", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}