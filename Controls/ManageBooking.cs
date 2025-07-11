using FlightBookingSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls

{
    public partial class ManageBooking : UserControl
    {
        public event EventHandler ManageBookingClicked;

        public ManageBooking()
        {
            InitializeComponent();
        }

     
    }
}