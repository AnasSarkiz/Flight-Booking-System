using FlightBookingSystem;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Services;
using System;
using System.Net.Http;
using System.Windows.Forms;
using FlightBookingSystem.Models;

namespace FlightBooker
{
    public partial class Registration : Form
    {
        private readonly UserService _userService;
        private readonly HttpClient _httpClient;

        public Registration()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
            _httpClient = new HttpClient(); // Initialize HttpClient
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
                ApiService apiService = new ApiService(_httpClient);

                new MainForm(
                    user,
                    userRepo,
                    bookingRepo,
                    passengerRepo,
                    apiService
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

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}