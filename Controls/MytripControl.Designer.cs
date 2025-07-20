namespace FlightBookingSystem.Controls
{
    partial class MyTripControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.FlowLayoutPanel bookingsPanel;
        private System.Windows.Forms.Button newBookingButton;
        private System.Windows.Forms.Panel loadingIndicator;

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
            this.newBookingButton = new System.Windows.Forms.Button();
            this.loadingIndicator = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // headerLabel
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(8,18,44);
            this.headerLabel.Location = new System.Drawing.Point(40, 40);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(250, 45);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "MY TRIPS";

            // bookingsPanel
            this.bookingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookingsPanel.AutoScroll = true;
            this.bookingsPanel.BackColor = System.Drawing.Color.FromArgb(240,245,255);
            this.bookingsPanel.Location = new System.Drawing.Point(40, 100);
            this.bookingsPanel.Name = "bookingsPanel";
            this.bookingsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.bookingsPanel.Size = new System.Drawing.Size(1120, 520);
            this.bookingsPanel.TabIndex = 1;

            // newBookingButton
            this.newBookingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newBookingButton.BackColor = System.Drawing.Color.FromArgb(0,168,255);
            this.newBookingButton.FlatAppearance.BorderSize = 0;
            this.newBookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newBookingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.newBookingButton.ForeColor = System.Drawing.Color.White;
            this.newBookingButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newBookingButton.Location = new System.Drawing.Point(900, 40);
            this.newBookingButton.Name = "newBookingButton";
            this.newBookingButton.Size = new System.Drawing.Size(200, 45);
            this.newBookingButton.TabIndex = 2;
            this.newBookingButton.Text = "New Booking";
            this.newBookingButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newBookingButton.UseVisualStyleBackColor = false;

            // loadingIndicator
            this.loadingIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingIndicator.BackColor = System.Drawing.Color.Transparent;
            this.loadingIndicator.Location = new System.Drawing.Point(500, 250);
            this.loadingIndicator.Name = "loadingIndicator";
            this.loadingIndicator.Size = new System.Drawing.Size(200, 100);
            this.loadingIndicator.TabIndex = 3;
            this.loadingIndicator.Visible = false;

            // MyTripControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingIndicator);
            this.Controls.Add(this.newBookingButton);
            this.Controls.Add(this.bookingsPanel);
            this.Controls.Add(this.headerLabel);
            this.Name = "MyTripControl";
            this.Size = new System.Drawing.Size(1200, 720);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}