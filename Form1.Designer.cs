namespace FlightBookingSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private FlightBookingSystem.Controls.NavbarControl navbarControl;
        private System.Windows.Forms.Panel mainContentPanel;

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
            this.navbarControl = new FlightBookingSystem.Controls.NavbarControl();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // navbarControl
            this.navbarControl.BackColor = System.Drawing.Color.FromArgb(8, 18, 44);
            this.navbarControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbarControl.Location = new System.Drawing.Point(0, 0);
            this.navbarControl.Name = "navbarControl";
            this.navbarControl.Size = new System.Drawing.Size(1200, 80);
            this.navbarControl.TabIndex = 0;

            // mainContentPanel
            this.mainContentPanel.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(0, 80);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1200, 720);
            this.mainContentPanel.TabIndex = 1;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.navbarControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nebula Flight Booking";
            this.ResumeLayout(false);
        }
    }
}