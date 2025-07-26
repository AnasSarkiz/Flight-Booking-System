namespace FlightBookingSystem
{
    partial class MainForm()
    {
        private System.ComponentModel.IContainer components = null;
        private FlightBookingSystem.Controls.NavbarControl navbarControl;
        private System.Windows.Forms.Panel mainContentPanel;

        private void InitializeComponent()
        {
            mainContentPanel = new Panel();
            SuspendLayout();
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.FromArgb(240, 245, 255);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 0);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1200, 961);
            mainContentPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 961);
            Controls.Add(mainContentPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 1000);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RE7LA Flight Booking";
            ResumeLayout(false);
        }
    }
}