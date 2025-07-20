using FlightBookingSystem;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Services;
using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Helpers;
namespace FlightBooker
{
    public partial class Registration : Form
    {
        private readonly UserService _userService;

        public Registration()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                User user = _userService.Login(
                    usernameTextBox.Text.Trim(),
                    passwordTextBox.Text.Trim()
                );
                this.Hide();
                UserRepository userRepo = new UserRepository();
                BookingDetailsRepository bookingRepo = new BookingDetailsRepository();
                PassengerRepository passengerRepo = new PassengerRepository();
            
                 new MainForm(
                    user,
                    userRepo,
                    bookingRepo,
                    passengerRepo
                ).Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheck.Checked;
        }
    }
}
