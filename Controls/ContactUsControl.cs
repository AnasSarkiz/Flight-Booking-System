using System;
using System.Drawing;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.Controls
{
    public partial class ContactUsControl : UserControl
    {
        private readonly IContactService _contactService;
        private readonly User _currentUser;

        public ContactUsControl(IContactService contactService, User currentUser)
        {
            InitializeComponent();
            _contactService = contactService;
            _currentUser = currentUser;

            // Auto-fill for logged in users
            if (_currentUser != null)
            {
                nameTextBox.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            }
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                SetLoadingState(true);

                string fullMessage = FormatMessageContent();

                bool success = await _contactService.SendContactMessage(
                    _currentUser?.Id ?? 0,
                    _currentUser?.Username ?? "guest",
                    fullMessage);

                HandleSubmissionResult(success);
            }
            catch (Exception ex)
            {
                ShowError($"Error sending message: {ex.Message}");
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(messageTextBox.Text))
            {
                ShowWarning("Please fill in all required fields");
                return false;
            }

            if (!IsValidEmail(emailTextBox.Text))
            {
                ShowWarning("Please enter a valid email address");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string FormatMessageContent()
        {
            return $"Name: {nameTextBox.Text}\n" +
                   $"Email: {emailTextBox.Text}\n" +
                   $"Message Type: {messageTypeComboBox.SelectedItem}\n" +
                   $"Message: {messageTextBox.Text}";
        }

        private void HandleSubmissionResult(bool success)
        {
            if (success)
            {
                ShowSuccess("Message sent successfully! We'll get back to you soon.");
                ClearForm();
            }
            else
            {
                ShowError("Failed to send message. Please try again later.");
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            submitButton.Enabled = !isLoading;
            submitButton.Text = isLoading ? "Sending..." : "Send Message";
            submitButton.IconChar = isLoading ? FontAwesome.Sharp.IconChar.Spinner : FontAwesome.Sharp.IconChar.PaperPlane;
            submitButton.IconColor = isLoading ? Color.Gray : Color.White;
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private void ClearForm()
        {
            nameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            messageTextBox.Text = string.Empty;
            messageTypeComboBox.SelectedIndex = 0;
        }

        private void ShowSuccess(string message)
        {
            notificationLabel.Text = message;
            notificationLabel.ForeColor = Color.FromArgb(0, 150, 0);
            notificationLabel.Visible = true;
            notificationTimer.Start();
        }

        private void ShowWarning(string message)
        {
            notificationLabel.Text = message;
            notificationLabel.ForeColor = Color.FromArgb(200, 150, 0);
            notificationLabel.Visible = true;
            notificationTimer.Start();
        }

        private void ShowError(string message)
        {
            notificationLabel.Text = message;
            notificationLabel.ForeColor = Color.FromArgb(200, 0, 0);
            notificationLabel.Visible = true;
            notificationTimer.Start();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            notificationLabel.Visible = false;
            notificationTimer.Stop();
        }

        private void MessageTextBox_Enter(object sender, EventArgs e)
        {
            messagePanel.BackColor = Color.FromArgb(0, 168, 255);
        }

        private void MessageTextBox_Leave(object sender, EventArgs e)
        {
            messagePanel.BackColor = Color.Silver;
        }
    }
}