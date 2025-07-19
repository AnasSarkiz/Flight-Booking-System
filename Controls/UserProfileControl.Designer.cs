namespace FlightBookingSystem.Controls
{
    partial class UserProfileControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMemberSince;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBack;

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
            btnBack = new Button();
            panelContent = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblRole = new Label();
            lblBalance = new Label();
            lblTotalBookings = new Label();
            lblMemberSince = new Label();
            lblEmail = new Label();
            lblName = new Label();
            pictureBoxUser = new PictureBox();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(5, 15, 40);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(60, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(148, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "User Profile";
            // 
            // btnBack
            // 
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnBack.Location = new Point(10, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(40, 40);
            btnBack.TabIndex = 0;
            btnBack.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(label5);
            panelContent.Controls.Add(label4);
            panelContent.Controls.Add(label3);
            panelContent.Controls.Add(label2);
            panelContent.Controls.Add(label1);
            panelContent.Controls.Add(lblRole);
            panelContent.Controls.Add(lblBalance);
            panelContent.Controls.Add(lblTotalBookings);
            panelContent.Controls.Add(lblMemberSince);
            panelContent.Controls.Add(lblEmail);
            panelContent.Controls.Add(lblName);
            panelContent.Controls.Add(pictureBoxUser);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(800, 540);
            panelContent.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(376, 299);
            label5.Name = "label5";
            label5.Size = new Size(43, 19);
            label5.TabIndex = 11;
            label5.Text = "Role:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(376, 259);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 10;
            label4.Text = "Balance:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(376, 219);
            label3.Name = "label3";
            label3.Size = new Size(112, 19);
            label3.TabIndex = 9;
            label3.Text = "Total Bookings:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(376, 179);
            label2.Name = "label2";
            label2.Size = new Size(109, 19);
            label2.TabIndex = 8;
            label2.Text = "Member Since:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(376, 139);
            label1.Name = "label1";
            label1.Size = new Size(80, 19);
            label1.TabIndex = 7;
            label1.Text = "Username:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(496, 299);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(96, 19);
            lblRole.TabIndex = 6;
            lblRole.Text = "Standard User";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 10F);
            lblBalance.Location = new Point(496, 259);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(44, 19);
            lblBalance.TabIndex = 5;
            lblBalance.Text = "$0.00";
            // 
            // lblTotalBookings
            // 
            lblTotalBookings.AutoSize = true;
            lblTotalBookings.Font = new Font("Segoe UI", 10F);
            lblTotalBookings.Location = new Point(496, 219);
            lblTotalBookings.Name = "lblTotalBookings";
            lblTotalBookings.Size = new Size(17, 19);
            lblTotalBookings.TabIndex = 4;
            lblTotalBookings.Text = "0";
            // 
            // lblMemberSince
            // 
            lblMemberSince.AutoSize = true;
            lblMemberSince.Font = new Font("Segoe UI", 10F);
            lblMemberSince.Location = new Point(496, 179);
            lblMemberSince.Name = "lblMemberSince";
            lblMemberSince.Size = new Size(107, 19);
            lblMemberSince.TabIndex = 3;
            lblMemberSince.Text = "January 1, 2023";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(496, 139);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(127, 19);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "user@example.com";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblName.Location = new Point(376, 79);
            lblName.Name = "lblName";
            lblName.Size = new Size(109, 30);
            lblName.TabIndex = 1;
            lblName.Text = "John Doe";
            // 
            // pictureBoxUser
            // 
            pictureBoxUser.Image = (Image)resources.GetObject("pictureBoxUser.Image");
            pictureBoxUser.Location = new Point(100, 80);
            pictureBoxUser.Name = "pictureBoxUser";
            pictureBoxUser.Size = new Size(150, 150);
            pictureBoxUser.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUser.TabIndex = 0;
            pictureBoxUser.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxUser).EndInit();
            ResumeLayout(false);
        }
    }
}