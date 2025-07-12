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
            homeButton = new Button();
            searchFlightsButton = new Button();
            bookingsButton = new Button();
            profileButton = new Button();
            navLogo = new Label();
            logoIcon = new PictureBox();
            activeIndicator = new Panel();
            ((System.ComponentModel.ISupportInitialize)logoIcon).BeginInit();
            SuspendLayout();
            // 
            // homeButton
            // 
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            homeButton.ForeColor = Color.White;
            homeButton.ImageAlign = ContentAlignment.MiddleLeft;
            homeButton.Location = new Point(300, 20);
            homeButton.Name = "homeButton";
            homeButton.Padding = new Padding(10, 0, 0, 0);
            homeButton.Size = new Size(120, 40);
            homeButton.TabIndex = 0;
            homeButton.Text = "Home";
            homeButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            homeButton.UseVisualStyleBackColor = true;
            // 
            // searchFlightsButton
            // 
            searchFlightsButton.FlatAppearance.BorderSize = 0;
            searchFlightsButton.FlatStyle = FlatStyle.Flat;
            searchFlightsButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            searchFlightsButton.ForeColor = Color.White;
            searchFlightsButton.ImageAlign = ContentAlignment.MiddleLeft;
            searchFlightsButton.Location = new Point(430, 20);
            searchFlightsButton.Name = "searchFlightsButton";
            searchFlightsButton.Padding = new Padding(10, 0, 0, 0);
            searchFlightsButton.Size = new Size(150, 40);
            searchFlightsButton.TabIndex = 1;
            searchFlightsButton.Text = "Search Flights";
            searchFlightsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchFlightsButton.UseVisualStyleBackColor = true;
            // 
            // bookingsButton
            // 
            bookingsButton.FlatAppearance.BorderSize = 0;
            bookingsButton.FlatStyle = FlatStyle.Flat;
            bookingsButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            bookingsButton.ForeColor = Color.White;
            bookingsButton.ImageAlign = ContentAlignment.MiddleLeft;
            bookingsButton.Location = new Point(590, 20);
            bookingsButton.Name = "bookingsButton";
            bookingsButton.Padding = new Padding(10, 0, 0, 0);
            bookingsButton.Size = new Size(130, 40);
            bookingsButton.TabIndex = 2;
            bookingsButton.Text = "My Trips";
            bookingsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            bookingsButton.UseVisualStyleBackColor = true;
            // 
            // profileButton
            // 
            profileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profileButton.FlatAppearance.BorderSize = 0;
            profileButton.FlatStyle = FlatStyle.Flat;
            profileButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            profileButton.ForeColor = Color.White;
            profileButton.ImageAlign = ContentAlignment.MiddleLeft;
            profileButton.Location = new Point(1000, 20);
            profileButton.Name = "profileButton";
            profileButton.Padding = new Padding(10, 0, 0, 0);
            profileButton.Size = new Size(120, 40);
            profileButton.TabIndex = 3;
            profileButton.Text = "Logout";
            profileButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            profileButton.UseVisualStyleBackColor = true;
            // 
            // navLogo
            // 
            navLogo.AutoSize = true;
            navLogo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            navLogo.ForeColor = Color.FromArgb(0, 168, 255);
            navLogo.Location = new Point(70, 20);
            navLogo.Name = "navLogo";
            navLogo.Size = new Size(87, 32);
            navLogo.TabIndex = 4;
            navLogo.Text = "RE7LA";
            // 
            // logoIcon
            // 
            logoIcon.Location = new Point(20, 15);
            logoIcon.Name = "logoIcon";
            logoIcon.Size = new Size(40, 40);
            logoIcon.SizeMode = PictureBoxSizeMode.Zoom;
            logoIcon.TabIndex = 5;
            logoIcon.TabStop = false;
            // 
            // activeIndicator
            // 
            activeIndicator.BackColor = Color.FromArgb(0, 200, 255);
            activeIndicator.Height = 3;
            activeIndicator.Location = new Point(300, 60);
            activeIndicator.Name = "activeIndicator";
            activeIndicator.Size = new Size(120, 4);
            activeIndicator.TabIndex = 6;
            // Button styling
            var buttons = new[] { homeButton, searchFlightsButton, bookingsButton, profileButton };
            foreach (var btn in buttons)
            {
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 40, 80);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 160);
                btn.Cursor = Cursors.Hand;
            }
            // 
            // NavbarControl
            // 
            BackColor = Color.FromArgb(5, 15, 40);
            Controls.Add(activeIndicator);
            Controls.Add(logoIcon);
            Controls.Add(navLogo);
            Controls.Add(profileButton);
            Controls.Add(bookingsButton);
            Controls.Add(searchFlightsButton);
            Controls.Add(homeButton);
            Name = "NavbarControl";
            Size = new Size(1200, 80);
            ((System.ComponentModel.ISupportInitialize)logoIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}