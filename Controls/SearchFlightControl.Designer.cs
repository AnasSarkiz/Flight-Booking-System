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
            searchBoxControl = new SearchBoxControl();
            filterPanelControl = new FilterPanelControl();
            flightCardsPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // searchBoxControl
            // 
            searchBoxControl.BackColor = Color.White;
            searchBoxControl.Dock = DockStyle.Top;
            searchBoxControl.Font = new Font("Segoe UI", 9F);
            searchBoxControl.Location = new Point(0, 0);
            searchBoxControl.Name = "searchBoxControl";
            searchBoxControl.Size = new Size(1200, 150);
            searchBoxControl.TabIndex = 0;
            // 
            // filterPanelControl
            // 
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
            flightCardsPanel.BackColor = Color.FromArgb(240, 245, 255);
            flightCardsPanel.Dock = DockStyle.Fill;
            flightCardsPanel.Location = new Point(250, 150);
            flightCardsPanel.Name = "flightCardsPanel";
            flightCardsPanel.Padding = new Padding(20);
            flightCardsPanel.Size = new Size(950, 570);
            flightCardsPanel.TabIndex = 2;
            // 
            // SearchFlightsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 255);
            Controls.Add(flightCardsPanel);
            Controls.Add(filterPanelControl);
            Controls.Add(searchBoxControl);
            Name = "SearchFlightsControl";
            Size = new Size(1200, 720);
            ResumeLayout(false);
        }
    }
}