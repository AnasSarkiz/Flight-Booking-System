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
        private PictureBox pictureBox1;
        private Label titleLabel;
        private Panel panel1;
        private Panel panel2;
        private CheckBox showPasswordCheck;
        ErrorProvider errorProvider = new ErrorProvider();


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            pictureBox1 = new PictureBox();
            titleLabel = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            showPasswordCheck = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            usernameLabel.ForeColor = Color.FromArgb(8, 18, 44);
            usernameLabel.Location = new Point(256, 120);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(74, 19);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.BackColor = Color.White;
            usernameTextBox.BorderStyle = BorderStyle.None;
            usernameTextBox.Font = new Font("Segoe UI", 12F);
            usernameTextBox.ForeColor = Color.FromArgb(8, 18, 44);
            usernameTextBox.Location = new Point(256, 140);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(300, 22);
            usernameTextBox.TabIndex = 1;
            //errorProvider.SetError(usernameTextBox, "Username Required");
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            passwordLabel.ForeColor = Color.FromArgb(8, 18, 44);
            passwordLabel.Location = new Point(256, 180);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(71, 19);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.White;
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.Font = new Font("Segoe UI", 12F);
            passwordTextBox.ForeColor = Color.FromArgb(8, 18, 44);
            passwordTextBox.Location = new Point(256, 200);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(300, 22);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            //errorProvider.SetError(passwordTextBox, "Password Requierd");
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(0, 168, 255);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(256, 280);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(300, 40);
            loginButton.TabIndex = 4;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += LoginButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.MidnightBlue;
            titleLabel.Location = new Point(256, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(246, 45);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "It's Re7la Time!";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(8, 18, 44);
            panel1.Location = new Point(256, 165);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 1);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(8, 18, 44);
            panel2.Location = new Point(256, 225);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 1);
            panel2.TabIndex = 7;
            // 
            // showPasswordCheck
            // 
            showPasswordCheck.AutoSize = true;
            showPasswordCheck.Font = new Font("Segoe UI", 9F);
            showPasswordCheck.ForeColor = Color.FromArgb(8, 18, 44);
            showPasswordCheck.Location = new Point(256, 240);
            showPasswordCheck.Name = "showPasswordCheck";
            showPasswordCheck.Size = new Size(108, 19);
            showPasswordCheck.TabIndex = 10;
            showPasswordCheck.Text = "Show Password";
            showPasswordCheck.UseVisualStyleBackColor = true;
            showPasswordCheck.CheckedChanged += showPasswordCheck_CheckedChanged;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(594, 400);
            Controls.Add(showPasswordCheck);
            Controls.Add(titleLabel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RE7LA - Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}