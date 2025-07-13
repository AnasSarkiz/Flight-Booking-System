namespace FlightBookingSystem.Controls
{
    partial class HomeControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button exploreButton;
        private System.Windows.Forms.TableLayoutPanel destinationsPanel;
        private System.Windows.Forms.Label destinationsTitle;

        private System.Windows.Forms.Panel[] cityCards = new System.Windows.Forms.Panel[8];
        private System.Windows.Forms.PictureBox[] cityImages = new System.Windows.Forms.PictureBox[8];
        private System.Windows.Forms.Label[] cityLabels = new System.Windows.Forms.Label[8];
        private System.Windows.Forms.Button[] cityButtons = new System.Windows.Forms.Button[8];


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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.destinationsTitle = new System.Windows.Forms.Label();
            this.destinationsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.exploreButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Header Panel
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Size = new System.Drawing.Size(1200, 100);
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(8, 18, 44);

            // Destinations Title
            this.destinationsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.destinationsTitle.AutoSize = true;
            this.destinationsTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.destinationsTitle.ForeColor = System.Drawing.Color.FromArgb(8, 18, 44);
            this.destinationsTitle.Padding = new System.Windows.Forms.Padding(20, 20, 0, 10);
            this.destinationsTitle.Text = "Popular Destinations";

            // Destinations Panel (TableLayout)
            this.destinationsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.destinationsPanel.ColumnCount = 4;
            this.destinationsPanel.RowCount = 2;
            this.destinationsPanel.Height = 520;
            this.destinationsPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.destinationsPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;

            for (int i = 0; i < 4; i++)
            {
                this.destinationsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            for (int i = 0; i < 2; i++)
            {
                this.destinationsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            }

            for (int i = 0; i < cities.Length; i++)
            {
                cityCards[i] = new System.Windows.Forms.Panel();
                cityImages[i] = new System.Windows.Forms.PictureBox();
                cityLabels[i] = new System.Windows.Forms.Label();
                cityButtons[i] = new System.Windows.Forms.Button();

                cityCards[i].BackColor = System.Drawing.Color.White;
                cityCards[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cityCards[i].Margin = new System.Windows.Forms.Padding(10);
                cityCards[i].Size = new Size(250, 250); // Set explicit size instead of MaximumSize
                cityCards[i].MaximumSize = new Size(400, 400);

                cityImages[i].Dock = System.Windows.Forms.DockStyle.Top;
                cityImages[i].Height = 150;
                cityImages[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                cityLabels[i].Dock = System.Windows.Forms.DockStyle.Top;
                cityLabels[i].Height = 40;
                cityLabels[i].Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                cityLabels[i].ForeColor = System.Drawing.Color.FromArgb(8, 18, 44);
                cityLabels[i].Text = cities[i];
                cityLabels[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                cityButtons[i].Dock = System.Windows.Forms.DockStyle.Fill;
                cityButtons[i].Text = "Book Now";
                cityButtons[i].Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                cityButtons[i].BackColor = System.Drawing.Color.FromArgb(0, 168, 255);
                cityButtons[i].ForeColor = System.Drawing.Color.White;
                cityButtons[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                cityButtons[i].FlatAppearance.BorderSize = 0;

                cityCards[i].Controls.Add(cityButtons[i]);
                cityCards[i].Controls.Add(cityLabels[i]);
                cityCards[i].Controls.Add(cityImages[i]);

                int row = i / 4;
                int col = i % 4;
                destinationsPanel.Controls.Add(cityCards[i], col, row);
            }

            // Title Label
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(8, 18, 44);
            this.titleLabel.Padding = new System.Windows.Forms.Padding(20, 40, 20, 0);
            this.titleLabel.Text = "Your Journey Begins Here";

            // Subtitle Label
            this.subtitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(8, 18, 44);
            this.subtitleLabel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 40);
            this.subtitleLabel.Text = "Discover amazing destinations at unbeatable prices today!";

            // Explore Button
            this.exploreButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exploreButton.BackColor = System.Drawing.Color.FromArgb(0, 168, 255);
            this.exploreButton.FlatAppearance.BorderSize = 0;
            this.exploreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exploreButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.exploreButton.ForeColor = System.Drawing.Color.White;
            this.exploreButton.Size = new System.Drawing.Size(250, 60);
            this.exploreButton.Text = "Explore All Destinations";
            this.exploreButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exploreButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 40);

            // Add Controls
            this.Controls.Add(this.exploreButton);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.destinationsPanel);
            this.Controls.Add(this.destinationsTitle);
            this.Controls.Add(this.headerPanel);

            this.Size = new System.Drawing.Size(1200, 1000);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}