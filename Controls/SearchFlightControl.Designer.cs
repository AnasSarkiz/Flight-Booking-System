namespace FlightBookingSystem.Controls
{
    partial class SearchFlightsControl
    {
        private System.ComponentModel.IContainer components = null;
        private FlightBookingSystem.Controls.SearchBoxControl searchBoxControl;
        private FlightBookingSystem.Controls.FilterPanelControl filterPanelControl;
        private System.Windows.Forms.FlowLayoutPanel flightCardsPanel;

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
            this.searchBoxControl = new FlightBookingSystem.Controls.SearchBoxControl();
            this.filterPanelControl = new FlightBookingSystem.Controls.FilterPanelControl();
            this.flightCardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // searchBoxControl
            this.searchBoxControl.BackColor = Color.FromArgb(250, 252, 255);
            this.searchBoxControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBoxControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchBoxControl.Location = new System.Drawing.Point(0, 0);
            this.searchBoxControl.Name = "searchBoxControl";
            this.searchBoxControl.Size = new System.Drawing.Size(1200, 150);
            this.searchBoxControl.TabIndex = 0;
            searchBoxControl.BorderStyle = BorderStyle.FixedSingle;

            // filterPanelControl
            filterPanelControl.BackColor = Color.White;
            this.filterPanelControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.filterPanelControl.Location = new System.Drawing.Point(0, 150);
            this.filterPanelControl.Name = "filterPanelControl";
            this.filterPanelControl.SelectedSortOption = FlightBookingSystem.Controls.FilterPanelControl.SortOption.Price;
            this.filterPanelControl.Size = new System.Drawing.Size(250, 570);
            this.filterPanelControl.TabIndex = 1;
            //filterPanelControl.BorderStyle = BorderStyle.FixedSingle;

            // flightCardsPanel
            this.flightCardsPanel.AutoScroll = true;
            this.flightCardsPanel.BackColor = Color.FromArgb(245, 249, 255);
            this.flightCardsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flightCardsPanel.Location = new System.Drawing.Point(250, 150);
            this.flightCardsPanel.Name = "flightCardsPanel";
            this.flightCardsPanel.Padding = new System.Windows.Forms.Padding(20);
            this.flightCardsPanel.Size = new System.Drawing.Size(950, 570);
            this.flightCardsPanel.TabIndex = 2;
            this.BackColor = Color.FromArgb(245, 249, 255);

            // SearchFlightsControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.flightCardsPanel);
            this.Controls.Add(this.filterPanelControl);
            this.Controls.Add(this.searchBoxControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SearchFlightsControl";
            this.Size = new System.Drawing.Size(1200, 720);
            this.ResumeLayout(false);
        }
    }
}