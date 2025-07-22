namespace FlightBookingSystem.Controls
{
    partial class AboutUsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label aboutTextLabel;

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
            aboutTextLabel = new Label();
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
            titleLabel.Text = "About Us";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(aboutTextLabel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(40);
            contentPanel.Size = new Size(800, 540);
            contentPanel.TabIndex = 1;
            // 
            // aboutTextLabel
            // 
            aboutTextLabel.AutoSize = true;
            aboutTextLabel.Dock = DockStyle.Fill;
            aboutTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aboutTextLabel.Location = new Point(40, 40);
            aboutTextLabel.MaximumSize = new Size(700, 0);
            aboutTextLabel.Name = "aboutTextLabel";
            aboutTextLabel.Size = new Size(0, 21);
            aboutTextLabel.TabIndex = 0;
            // 
            // AboutUsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentPanel);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "AboutUsControl";
            Size = new Size(800, 600);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}