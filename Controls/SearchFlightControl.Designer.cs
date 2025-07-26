namespace FlightBookingSystem.Controls
{
    partial class SearchFlightsControl
    {
        private System.ComponentModel.IContainer components = null;
        private FlightBookingSystem.Controls.SearchBoxControl searchBoxControl;
        private FlightBookingSystem.Controls.FilterPanelControl filterPanelControl;
        private System.Windows.Forms.FlowLayoutPanel flightCardsPanel;
        private System.Windows.Forms.Label loadingLabel;
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
            searchBoxControl = new SearchBoxControl();
            filterPanelControl = new FilterPanelControl();
            flightCardsPanel = new FlowLayoutPanel();
            loadingLabel = new Label();
            SuspendLayout();
            // 
            // searchBoxControl
            // 
            searchBoxControl.BackColor = Color.FromArgb(250, 252, 255);
            searchBoxControl.BorderStyle = BorderStyle.FixedSingle;
            searchBoxControl.Dock = DockStyle.Top;
            searchBoxControl.Font = new Font("Segoe UI", 9F);
            searchBoxControl.Location = new Point(0, 0);
            searchBoxControl.Name = "searchBoxControl";
            searchBoxControl.Size = new Size(1200, 150);
            searchBoxControl.TabIndex = 0;
            // 
            // filterPanelControl
            // 
            filterPanelControl.AutoScroll = true;
            filterPanelControl.BackColor = Color.White;
            filterPanelControl.Dock = DockStyle.Left;
            filterPanelControl.Location = new Point(0, 150);
            filterPanelControl.Name = "filterPanelControl";
            filterPanelControl.SelectedSortOption = FilterPanelControl.SortOption.Price;
            filterPanelControl.Size = new Size(250, 570);
            filterPanelControl.TabIndex = 1;
            // 
            // flightCardsPanel
            // 
            flightCardsPanel.AutoScroll = true;
            flightCardsPanel.BackColor = Color.FromArgb(245, 249, 255);
            flightCardsPanel.Dock = DockStyle.Fill;
            flightCardsPanel.Location = new Point(250, 150);
            flightCardsPanel.Name = "flightCardsPanel";
            flightCardsPanel.Padding = new Padding(20);
            flightCardsPanel.Size = new Size(950, 570);
            flightCardsPanel.TabIndex = 2;
            // 
            // loadingLabel
            // 
            loadingLabel.Dock = DockStyle.Fill;
            loadingLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            loadingLabel.ForeColor = Color.FromArgb(80, 80, 100);
            loadingLabel.Location = new Point(250, 150);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(950, 570);
            loadingLabel.TabIndex = 0;
            loadingLabel.Text = "✈️ Searching for flights...";
            loadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            loadingLabel.Visible = false;
            // 
            // SearchFlightsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 255);
            Controls.Add(loadingLabel);
            Controls.Add(flightCardsPanel);
            Controls.Add(filterPanelControl);
            Controls.Add(searchBoxControl);
            Font = new Font("Segoe UI", 9F);
            Name = "SearchFlightsControl";
            Size = new Size(1200, 720);
            ResumeLayout(false);
        }
    }
}