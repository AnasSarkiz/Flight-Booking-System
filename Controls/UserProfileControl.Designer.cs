namespace FlightBookingSystem.Controls
{
    partial class UserProfileControl
    {
        private System.ComponentModel.IContainer components = null;

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
            lblName = new Label();
            lblEmail = new Label();
            lblMemberSince = new Label();
            lblTotalBookings = new Label();
            lblBalance = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(24, 44);
            lblName.Name = "lblName";
            lblName.Size = new Size(55, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(24, 91);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblMemberSince
            // 
            lblMemberSince.AutoSize = true;
            lblMemberSince.Location = new Point(24, 128);
            lblMemberSince.Name = "lblMemberSince";
            lblMemberSince.Size = new Size(85, 15);
            lblMemberSince.TabIndex = 2;
            lblMemberSince.Text = "Member since:";
            // 
            // lblTotalBookings
            // 
            lblTotalBookings.AutoSize = true;
            lblTotalBookings.Location = new Point(24, 166);
            lblTotalBookings.Name = "lblTotalBookings";
            lblTotalBookings.Size = new Size(88, 15);
            lblTotalBookings.TabIndex = 3;
            lblTotalBookings.Text = "Total bookings:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalance.Location = new Point(24, 204);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(109, 15);
            lblBalance.TabIndex = 6;
            lblBalance.Text = "Current balance";
            // 
            // UserProfileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblBalance);
            Controls.Add(lblTotalBookings);
            Controls.Add(lblMemberSince);
            Controls.Add(lblEmail);
            Controls.Add(lblName);
            Name = "UserProfileControl";
            Size = new Size(350, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMemberSince;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.Label lblBalance;
    }
}