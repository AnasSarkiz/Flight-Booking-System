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
        private System.Windows.Forms.ContextMenuStrip profileMenu;
        private System.Windows.Forms.ToolStripMenuItem userProfileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactUsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsMenuItem;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripMenuItem userManagementMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activityLogMenuItem;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavbarControl));
            homeButton = new Button();
            searchFlightsButton = new Button();
            bookingsButton = new Button();
            profileButton = new Button();
            navLogo = new Label();
            logoIcon = new PictureBox();
            activeIndicator = new Panel();
            profileMenu = new ContextMenuStrip(components);
            userProfileMenuItem = new ToolStripMenuItem();
            contactUsMenuItem = new ToolStripMenuItem();
            aboutUsMenuItem = new ToolStripMenuItem();
            separator1 = new ToolStripSeparator();
            userManagementMenuItem = new ToolStripMenuItem();
            activityLogMenuItem = new ToolStripMenuItem();
            separator2 = new ToolStripSeparator();
            logoutMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)logoIcon).BeginInit();
            profileMenu.SuspendLayout();
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
            profileButton.Text = "Menu";
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
            navLogo.Size = new Size(99, 37);
            navLogo.TabIndex = 4;
            navLogo.Text = "RE7LA";
            // 
            // logoIcon
            // 
            logoIcon.BackgroundImage = (Image)resources.GetObject("logoIcon.BackgroundImage");
            logoIcon.BackgroundImageLayout = ImageLayout.Stretch;
            logoIcon.ErrorImage = (Image)resources.GetObject("logoIcon.ErrorImage");
            logoIcon.InitialImage = (Image)resources.GetObject("logoIcon.InitialImage");
            logoIcon.Location = new Point(24, 20);
            logoIcon.Name = "logoIcon";
            logoIcon.Size = new Size(40, 40);
            logoIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            logoIcon.TabIndex = 5;
            logoIcon.TabStop = false;
            // 
            // activeIndicator
            // 
            activeIndicator.BackColor = Color.FromArgb(0, 200, 255);
            activeIndicator.Location = new Point(300, 60);
            activeIndicator.Name = "activeIndicator";
            activeIndicator.Size = new Size(120, 4);
            activeIndicator.TabIndex = 6;
            // 
            // profileMenu
            // 
            profileMenu.BackColor = Color.White;
            profileMenu.Font = new Font("Segoe UI", 10F);
            profileMenu.Items.AddRange(new ToolStripItem[] { userProfileMenuItem, contactUsMenuItem, aboutUsMenuItem, separator1, userManagementMenuItem, activityLogMenuItem, separator2, logoutMenuItem });
            profileMenu.Name = "profileMenu";
            profileMenu.ShowImageMargin = false;
            profileMenu.Size = new Size(168, 160);
            // 
            // userProfileMenuItem
            // 
            userProfileMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userProfileMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            userProfileMenuItem.Name = "userProfileMenuItem";
            userProfileMenuItem.Size = new Size(167, 24);
            userProfileMenuItem.Text = "User Profile";
            // 
            // contactUsMenuItem
            // 
            contactUsMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contactUsMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            contactUsMenuItem.Name = "contactUsMenuItem";
            contactUsMenuItem.Size = new Size(167, 24);
            contactUsMenuItem.Text = "Contact Us";
            // 
            // aboutUsMenuItem
            // 
            aboutUsMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aboutUsMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            aboutUsMenuItem.Name = "aboutUsMenuItem";
            aboutUsMenuItem.Size = new Size(167, 24);
            aboutUsMenuItem.Text = "About Us";
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(164, 6);
            // 
            // userManagementMenuItem
            // 
            userManagementMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userManagementMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            userManagementMenuItem.Name = "userManagementMenuItem";
            userManagementMenuItem.Size = new Size(167, 24);
            userManagementMenuItem.Text = "User Management";
            userManagementMenuItem.Visible = false;
            // 
            // activityLogMenuItem
            // 
            activityLogMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activityLogMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            activityLogMenuItem.Name = "activityLogMenuItem";
            activityLogMenuItem.Size = new Size(167, 24);
            activityLogMenuItem.Text = "Activity Log";
            activityLogMenuItem.Visible = false;
            // 
            // separator2
            // 
            separator2.Name = "separator2";
            separator2.Size = new Size(164, 6);
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoutMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Size = new Size(167, 24);
            logoutMenuItem.Text = "Logout";
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
            profileMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}