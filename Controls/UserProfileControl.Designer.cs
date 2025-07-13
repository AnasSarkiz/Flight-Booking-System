namespace FlightBookingSystem.Controls
{
    partial class UserProfileControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMemberSince;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.PictureBox pictureBoxProfile;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfileControl));
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            lblTotalBookings = new Label();
            lblMemberSince = new Label();
            lblEmail = new Label();
            lblName = new Label();
            pictureBoxProfile = new PictureBox();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.Control;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.ForeColor = Color.FromArgb(8, 18, 44);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(8, 18, 44);
            lblTitle.Location = new Point(140, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(120, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Profile";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(lblTotalBookings);
            panelContent.Controls.Add(lblMemberSince);
            panelContent.Controls.Add(lblEmail);
            panelContent.Controls.Add(lblName);
            panelContent.Controls.Add(pictureBoxProfile);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(30);
            panelContent.Size = new Size(800, 540);
            panelContent.TabIndex = 1;
            // 
            // lblTotalBookings
            // 
            lblTotalBookings.AutoSize = true;
            lblTotalBookings.Font = new Font("Segoe UI", 12F);
            lblTotalBookings.Location = new Point(490, 140);
            lblTotalBookings.Name = "lblTotalBookings";
            lblTotalBookings.Size = new Size(126, 21);
            lblTotalBookings.TabIndex = 4;
            lblTotalBookings.Text = "Total bookings: 0";
            // 
            // lblMemberSince
            // 
            lblMemberSince.AutoSize = true;
            lblMemberSince.Font = new Font("Segoe UI", 12F);
            lblMemberSince.Location = new Point(200, 140);
            lblMemberSince.Name = "lblMemberSince";
            lblMemberSince.Size = new Size(151, 21);
            lblMemberSince.TabIndex = 3;
            lblMemberSince.Text = "Member since: 2023";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(200, 106);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(154, 21);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "email@example.com";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.Location = new Point(200, 60);
            lblName.Name = "lblName";
            lblName.Size = new Size(96, 25);
            lblName.TabIndex = 1;
            lblName.Text = "John Doe";
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.Silver;
            pictureBoxProfile.BackgroundImage = (Image)resources.GetObject("pictureBoxProfile.BackgroundImage");
            pictureBoxProfile.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxProfile.ErrorImage = (Image)resources.GetObject("pictureBoxProfile.ErrorImage");
            pictureBoxProfile.InitialImage = (Image)resources.GetObject("pictureBoxProfile.InitialImage");
            pictureBoxProfile.Location = new Point(30, 30);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(150, 150);
            pictureBoxProfile.TabIndex = 0;
            pictureBoxProfile.TabStop = false;
            // 
            // UserProfileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Name = "UserProfileControl";
            Size = new Size(800, 600);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ResumeLayout(false);
        }
    }
}