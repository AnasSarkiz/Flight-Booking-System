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
        private System.Windows.Forms.Button submitButton;

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
            titleLabel = new Label();
            contentPanel = new Panel();
            submitButton = new Button();
            messageTextBox = new TextBox();
            messageLabel = new Label();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            contentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(8, 18, 44);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(800, 60);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Contact Us";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(submitButton);
            contentPanel.Controls.Add(messageTextBox);
            contentPanel.Controls.Add(messageLabel);
            contentPanel.Controls.Add(emailTextBox);
            contentPanel.Controls.Add(emailLabel);
            contentPanel.Controls.Add(nameTextBox);
            contentPanel.Controls.Add(nameLabel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(40);
            contentPanel.Size = new Size(800, 540);
            contentPanel.TabIndex = 1;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.FromArgb(0, 168, 255);
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitButton.ForeColor = Color.White;
            submitButton.Location = new Point(200, 350);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(150, 40);
            submitButton.TabIndex = 6;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += SubmitButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageTextBox.Location = new Point(150, 147);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.ScrollBars = ScrollBars.Vertical;
            messageTextBox.Size = new Size(300, 150);
            messageTextBox.TabIndex = 5;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageLabel.Location = new Point(50, 150);
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
            ResumeLayout(false);
        }
    }
}