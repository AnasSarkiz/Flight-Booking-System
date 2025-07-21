using Timer = System.Windows.Forms.Timer;
namespace FlightBookingSystem.Controls

{
    partial class ContactUsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private FontAwesome.Sharp.IconButton submitButton;
        private System.Windows.Forms.Label notificationLabel;
        private System.Windows.Forms.Timer notificationTimer;
        private System.Windows.Forms.Label messageTypeLabel;
        private System.Windows.Forms.ComboBox messageTypeComboBox;
        private System.Windows.Forms.Panel messagePanel;

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
            components = new System.ComponentModel.Container();
            titleLabel = new Label();
            contentPanel = new Panel();
            messagePanel = new Panel();
            messageTextBox = new TextBox();
            notificationLabel = new Label();
            messageTypeComboBox = new ComboBox();
            messageTypeLabel = new Label();
            submitButton = new FontAwesome.Sharp.IconButton();
            messageLabel = new Label();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            notificationTimer = new Timer(components);
            contentPanel.SuspendLayout();
            messagePanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(8, 18, 44);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(800, 80);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Contact Us";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(messagePanel);
            contentPanel.Controls.Add(notificationLabel);
            contentPanel.Controls.Add(messageTypeComboBox);
            contentPanel.Controls.Add(messageTypeLabel);
            contentPanel.Controls.Add(submitButton);
            contentPanel.Controls.Add(messageLabel);
            contentPanel.Controls.Add(emailTextBox);
            contentPanel.Controls.Add(emailLabel);
            contentPanel.Controls.Add(nameTextBox);
            contentPanel.Controls.Add(nameLabel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 80);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(40, 20, 40, 40);
            contentPanel.Size = new Size(800, 520);
            contentPanel.TabIndex = 1;
            // 
            // messagePanel
            // 
            messagePanel.BorderStyle = BorderStyle.FixedSingle;
            messagePanel.Controls.Add(messageTextBox);
            messagePanel.Location = new Point(150, 197);
            messagePanel.Name = "messagePanel";
            messagePanel.Padding = new Padding(5);
            messagePanel.Size = new Size(500, 150);
            messagePanel.TabIndex = 9;
            // 
            // messageTextBox
            // 
            messageTextBox.BorderStyle = BorderStyle.None;
            messageTextBox.Dock = DockStyle.Fill;
            messageTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageTextBox.Location = new Point(5, 5);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.PlaceholderText = "Type your message here...";
            messageTextBox.ScrollBars = ScrollBars.Vertical;
            messageTextBox.Size = new Size(488, 138);
            messageTextBox.TabIndex = 5;
            messageTextBox.Enter += MessageTextBox_Enter;
            messageTextBox.Leave += MessageTextBox_Leave;
            // 
            // notificationLabel
            // 
            notificationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            notificationLabel.Location = new Point(150, 400);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(500, 40);
            notificationLabel.TabIndex = 8;
            notificationLabel.TextAlign = ContentAlignment.MiddleCenter;
            notificationLabel.Visible = false;
            // 
            // messageTypeComboBox
            // 
            messageTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            messageTypeComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageTypeComboBox.FormattingEnabled = true;
            messageTypeComboBox.Items.AddRange(new object[] {
            "General Inquiry",
            "Booking Assistance",
            "Technical Support",
            "Feedback",
            "Complaint"});
            messageTypeComboBox.Location = new Point(150, 147);
            messageTypeComboBox.Name = "messageTypeComboBox";
            messageTypeComboBox.Size = new Size(300, 25);
            messageTypeComboBox.TabIndex = 7;
            // 
            // messageTypeLabel
            // 
            messageTypeLabel.AutoSize = true;
            messageTypeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageTypeLabel.Location = new Point(50, 150);
            messageTypeLabel.Name = "messageTypeLabel";
            messageTypeLabel.Size = new Size(92, 19);
            messageTypeLabel.TabIndex = 6;
            messageTypeLabel.Text = "Message Type:";
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.FromArgb(0, 168, 255);
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitButton.ForeColor = Color.White;
            submitButton.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            submitButton.IconColor = Color.White;
            submitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submitButton.IconSize = 24;
            submitButton.ImageAlign = ContentAlignment.MiddleLeft;
            submitButton.Location = new Point(300, 370);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(200, 45);
            submitButton.TabIndex = 6;
            submitButton.Text = "Send Message";
            submitButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += SubmitButton_Click;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageLabel.Location = new Point(50, 200);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(66, 19);
            messageLabel.TabIndex = 4;
            messageLabel.Text = "Message:";
            // 
            // emailTextBox
            // 
            emailTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTextBox.Location = new Point(150, 97);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(300, 25);
            emailTextBox.TabIndex = 3;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(50, 100);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(44, 19);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "Email:";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTextBox.Location = new Point(150, 47);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(300, 25);
            nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(50, 50);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(48, 19);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // notificationTimer
            // 
            notificationTimer.Interval = 5000;
            notificationTimer.Tick += NotificationTimer_Tick;
            // 
            // ContactUsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentPanel);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ContactUsControl";
            Size = new Size(800, 600);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            messagePanel.ResumeLayout(false);
            messagePanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}