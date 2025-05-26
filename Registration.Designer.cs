namespace FlightBooker
{
    partial class Registration
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label usernameLabel;
        private Label passwordLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(50, 50);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(150, 50);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(200, 23);
            usernameTextBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(50, 100);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(150, 100);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(200, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(150, 150);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(100, 30);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.Click += LoginButton_Click;
            // 
            // Registration
            // 
            AutoSize = true;
            ClientSize = new Size(400, 221);
            ControlBox = false;
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            MaximumSize = new Size(416, 260);
            MinimumSize = new Size(416, 260);
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
