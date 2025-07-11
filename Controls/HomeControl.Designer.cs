namespace FlightBookingSystem.Controls
{
    partial class HomeControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox heroImage;
        private System.Windows.Forms.Button exploreButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;

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
            heroImage = new PictureBox();
            exploreButton = new Button();
            titleLabel = new Label();
            subtitleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)heroImage).BeginInit();
            SuspendLayout();
            // 
            // heroImage
            // 
            heroImage.Dock = DockStyle.Top;
            heroImage.Location = new Point(0, 0);
            heroImage.Margin = new Padding(2);
            heroImage.Name = "heroImage";
            heroImage.Size = new Size(933, 300);
            heroImage.SizeMode = PictureBoxSizeMode.StretchImage;
            heroImage.TabIndex = 0;
            heroImage.TabStop = false;
            // 
            // exploreButton
            // 
            exploreButton.Anchor = AnchorStyles.None;
            exploreButton.BackColor = Color.FromArgb(0, 168, 255);
            exploreButton.FlatAppearance.BorderSize = 0;
            exploreButton.FlatStyle = FlatStyle.Flat;
            exploreButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            exploreButton.ForeColor = Color.White;
            exploreButton.Location = new Point(389, 315);
            exploreButton.Margin = new Padding(2);
            exploreButton.Name = "exploreButton";
            exploreButton.Size = new Size(156, 38);
            exploreButton.TabIndex = 1;
            exploreButton.Text = "Explore Flights";
            exploreButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.None;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(8, 18, 44);
            titleLabel.Location = new Point(311, 240);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(341, 51);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Ready to Explore?";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            subtitleLabel.Anchor = AnchorStyles.None;
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 14F);
            subtitleLabel.ForeColor = Color.FromArgb(8, 18, 44);
            subtitleLabel.Location = new Point(233, 285);
            subtitleLabel.Margin = new Padding(2, 0, 2, 0);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(501, 25);
            subtitleLabel.TabIndex = 3;
            subtitleLabel.Text = "Discover amazing destinations at unbeatable prices today!";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 255);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            Controls.Add(exploreButton);
            Controls.Add(heroImage);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(2);
            Name = "HomeControl";
            Size = new Size(933, 540);
            ((System.ComponentModel.ISupportInitialize)heroImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}