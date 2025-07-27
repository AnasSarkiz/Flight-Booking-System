using FlightBookingSystem;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Services;
using FlightBookingSystem.Models;

namespace FlightBooker
{
    public partial class Registration : Form
    {
        private readonly UserService _userService;
        private readonly HttpClient _httpClient;
        private readonly IActivityLogRepository _activityLogRepository;

        public Registration()
        {
            InitializeComponent();
            _activityLogRepository = new ActivityLogRepository(); 
            _userService = new UserService(new UserRepository(_activityLogRepository));
            _httpClient = new HttpClient();
            passwordTextBox.KeyDown += PasswordTextBox_KeyDown;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(usernameTextBox.Text))
                {
                    errorProvider.SetError(usernameTextBox, "Username is required.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                {
                   errorProvider.SetError(passwordTextBox, "Password is required.");
                    return;
                }
                User user = _userService.Login(
                    usernameTextBox.Text.Trim(),
                    passwordTextBox.Text.Trim()
                );

                this.Hide();

                UserRepository userRepo = new UserRepository(_activityLogRepository);
                BookingDetailsRepository bookingRepo = new BookingDetailsRepository(_activityLogRepository);
                PassengerRepository passengerRepo = new PassengerRepository();
                AboutUsApiService apiService = new AboutUsApiService(_httpClient);

                new MainForm(
                    user,
                    userRepo,
                    bookingRepo,
                    passengerRepo,
                    apiService,
                    _activityLogRepository
                ).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                passwordTextBox.Text = "";
                passwordTextBox.Focus();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginButton_Click(sender, e);
            }
        }

        private void showPasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheck.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (passwordTextBox != null)
                {
                    passwordTextBox.KeyDown -= PasswordTextBox_KeyDown;
                }
                _httpClient?.Dispose();
          }
            
            base.Dispose(disposing);
        }
    }
}