namespace FlightBookingSystem.Controls
{
    partial class AllBookingsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.FlowLayoutPanel bookingsPanel;
        private System.Windows.Forms.Panel loadingIndicator;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;

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
            this.headerLabel = new System.Windows.Forms.Label();
            this.bookingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.loadingIndicator = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // headerLabel
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(8, 18, 44);
            this.headerLabel.Location = new System.Drawing.Point(40, 40);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(250, 45);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "ALL BOOKINGS";

            // bookingsPanel
            this.bookingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookingsPanel.AutoScroll = true;
            this.bookingsPanel.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.bookingsPanel.Location = new System.Drawing.Point(40, 100);
            this.bookingsPanel.Name = "bookingsPanel";
            this.bookingsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.bookingsPanel.Size = new System.Drawing.Size(1120, 520);
            this.bookingsPanel.TabIndex = 1;

            // loadingIndicator
            this.loadingIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingIndicator.BackColor = System.Drawing.Color.Transparent;
            this.loadingIndicator.Location = new System.Drawing.Point(500, 250);
            this.loadingIndicator.Name = "loadingIndicator";
            this.loadingIndicator.Size = new System.Drawing.Size(200, 100);
            this.loadingIndicator.TabIndex = 3;
            this.loadingIndicator.Visible = false;

            // searchTextBox
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(800, 55);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 23);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.PlaceholderText = "Search by PNR...";

            // searchButton
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(0, 115, 207);
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(1010, 55);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;

            // AllBookingsControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.loadingIndicator);
            this.Controls.Add(this.bookingsPanel);
            this.Controls.Add(this.headerLabel);
            this.Name = "AllBookingsControl";
            this.Size = new System.Drawing.Size(1200, 720);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}