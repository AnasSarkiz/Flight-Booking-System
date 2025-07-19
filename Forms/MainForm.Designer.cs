namespace FlightBookingSystem
{
    partial class MainForm()
    {
        private System.ComponentModel.IContainer components = null;
        private FlightBookingSystem.Controls.NavbarControl navbarControl;
        private System.Windows.Forms.Panel mainContentPanel;

        private void InitializeComponent()
        {
            navbarControl = new Controls.NavbarControl();
            mainContentPanel = new Panel();
            SuspendLayout();
            // 
            // navbarControl
            // 
            navbarControl.BackColor = Color.FromArgb(8, 18, 44);
            navbarControl.Dock = DockStyle.Top;
            navbarControl.IsAdmin = false;
            navbarControl.Location = new Point(0, 0);
            navbarControl.Name = "navbarControl";
            navbarControl.Size = new Size(1200, 80);
            navbarControl.TabIndex = 0;
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.FromArgb(240, 245, 255);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 80);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1200, 881);
            mainContentPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 961);
            Controls.Add(mainContentPanel);
            Controls.Add(navbarControl);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 1000);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RE7LA Flight Booking";
            ResumeLayout(false);
        }
    }
}