namespace FlightBookingSystem.Controls
{
    partial class NavbarControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button searchFlightsButton;
        private System.Windows.Forms.Button bookingsButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Label navLogo;
        private System.Windows.Forms.PictureBox logoIcon;
        private System.Windows.Forms.Panel activeIndicator;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavbarControl));
            this.homeButton = new System.Windows.Forms.Button();
            this.searchFlightsButton = new System.Windows.Forms.Button();
            this.bookingsButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.navLogo = new System.Windows.Forms.Label();
            this.logoIcon = new System.Windows.Forms.PictureBox();
            this.activeIndicator = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.logoIcon)).BeginInit();
            this.SuspendLayout();

            // homeButton
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.homeButton.ForeColor = System.Drawing.Color.White;
            this.homeButton.Image = ((System.Drawing.Image)(resources.GetObject("homeButton.Image")));
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.Location = new System.Drawing.Point(300, 20);
            this.homeButton.Name = "homeButton";
            this.homeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.homeButton.Size = new System.Drawing.Size(120, 40);
            this.homeButton.TabIndex = 0;
            this.homeButton.Text = "Home";
            this.homeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.homeButton.UseVisualStyleBackColor = true;

            // searchFlightsButton
            this.searchFlightsButton.FlatAppearance.BorderSize = 0;
            this.searchFlightsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchFlightsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.searchFlightsButton.ForeColor = System.Drawing.Color.White;
            this.searchFlightsButton.Image = ((System.Drawing.Image)(resources.GetObject("searchFlightsButton.Image")));
            this.searchFlightsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchFlightsButton.Location = new System.Drawing.Point(430, 20);
            this.searchFlightsButton.Name = "searchFlightsButton";
            this.searchFlightsButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.searchFlightsButton.Size = new System.Drawing.Size(150, 40);
            this.searchFlightsButton.TabIndex = 1;
            this.searchFlightsButton.Text = "Search Flights";
            this.searchFlightsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.searchFlightsButton.UseVisualStyleBackColor = true;

            // bookingsButton
            this.bookingsButton.FlatAppearance.BorderSize = 0;
            this.bookingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookingsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.bookingsButton.ForeColor = System.Drawing.Color.White;
            this.bookingsButton.Image = ((System.Drawing.Image)(resources.GetObject("bookingsButton.Image")));
            this.bookingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookingsButton.Location = new System.Drawing.Point(590, 20);
            this.bookingsButton.Name = "bookingsButton";
            this.bookingsButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bookingsButton.Size = new System.Drawing.Size(130, 40);
            this.bookingsButton.TabIndex = 2;
            this.bookingsButton.Text = "My Trips";
            this.bookingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bookingsButton.UseVisualStyleBackColor = true;

            // profileButton
            this.profileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.profileButton.ForeColor = System.Drawing.Color.White;
            this.profileButton.Image = ((System.Drawing.Image)(resources.GetObject("profileButton.Image")));
            this.profileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileButton.Location = new System.Drawing.Point(1000, 20);
            this.profileButton.Name = "profileButton";
            this.profileButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.profileButton.Size = new System.Drawing.Size(120, 40);
            this.profileButton.TabIndex = 3;
            this.profileButton.Text = "Profile";
            this.profileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.profileButton.UseVisualStyleBackColor = true;

            // navLogo
            this.navLogo.AutoSize = true;
            this.navLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navLogo.ForeColor = System.Drawing.Color.White;
            this.navLogo.Location = new System.Drawing.Point(70, 20);
            this.navLogo.Name = "navLogo";
            this.navLogo.Size = new System.Drawing.Size(194, 32);
            this.navLogo.TabIndex = 4;
            this.navLogo.Text = "NEBULA TRAVEL";

            // logoIcon
            this.logoIcon.Image = ((System.Drawing.Image)(resources.GetObject("logoIcon.Image")));
            this.logoIcon.Location = new System.Drawing.Point(20, 15);
            this.logoIcon.Name = "logoIcon";
            this.logoIcon.Size = new System.Drawing.Size(40, 40);
            this.logoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoIcon.TabIndex = 5;
            this.logoIcon.TabStop = false;

            // activeIndicator
            this.activeIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.activeIndicator.Location = new System.Drawing.Point(300, 60);
            this.activeIndicator.Name = "activeIndicator";
            this.activeIndicator.Size = new System.Drawing.Size(120, 4);
            this.activeIndicator.TabIndex = 6;

            // NavbarControl
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(18)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.activeIndicator);
            this.Controls.Add(this.logoIcon);
            this.Controls.Add(this.navLogo);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.bookingsButton);
            this.Controls.Add(this.searchFlightsButton);
            this.Controls.Add(this.homeButton);
            this.Name = "NavbarControl";
            this.Size = new System.Drawing.Size(1200, 80);
            ((System.ComponentModel.ISupportInitialize)(this.logoIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}