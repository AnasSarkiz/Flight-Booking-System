namespace FlightBookingSystem.Controls
{
    partial class SeatMapControl
    {
        private System.ComponentModel.IContainer components = null;

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
            this.cabinPanel = new System.Windows.Forms.Panel();
            this.filtersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblClass = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.chkWindow = new System.Windows.Forms.CheckBox();
            this.chkAisle = new System.Windows.Forms.CheckBox();
            this.chkExtraLegroom = new System.Windows.Forms.CheckBox();
            this.chkQuietZone = new System.Windows.Forms.CheckBox();
            this.seatInfoPanel = new System.Windows.Forms.Panel();
            this.lblSeatInfo = new System.Windows.Forms.Label();
            this.btnSelectSeat = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // cabinPanel
            this.cabinPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cabinPanel.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.cabinPanel.Location = new System.Drawing.Point(10, 40);
            this.cabinPanel.Name = "cabinPanel";
            this.cabinPanel.Size = new System.Drawing.Size(700, 390);
            this.cabinPanel.TabIndex = 0;

            // filtersPanel
            this.filtersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersPanel.BackColor = System.Drawing.Color.White;
            this.filtersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filtersPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.filtersPanel.Location = new System.Drawing.Point(720, 40);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Padding = new System.Windows.Forms.Padding(10);
            this.filtersPanel.Size = new System.Drawing.Size(230, 200);
            this.filtersPanel.TabIndex = 1;

            // lblClass
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClass.Location = new System.Drawing.Point(10, 10);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(70, 15);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Seat Class:";

            // cbClass
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Items.AddRange(new object[] {
            "Economy",
            "Premium Economy",
            "Business",
            "First Class"});
            this.cbClass.Location = new System.Drawing.Point(90, 7);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(150, 23);
            this.cbClass.TabIndex = 3;

            // lblFilter
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(720, 10);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(82, 15);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "Seat Filters:";

            // chkWindow
            this.chkWindow.AutoSize = true;
            this.chkWindow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkWindow.Location = new System.Drawing.Point(10, 10);
            this.chkWindow.Name = "chkWindow";
            this.chkWindow.Size = new System.Drawing.Size(70, 19);
            this.chkWindow.TabIndex = 0;
            this.chkWindow.Text = "Window";
            this.chkWindow.UseVisualStyleBackColor = true;

            // chkAisle
            this.chkAisle.AutoSize = true;
            this.chkAisle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAisle.Location = new System.Drawing.Point(10, 40);
            this.chkAisle.Name = "chkAisle";
            this.chkAisle.Size = new System.Drawing.Size(51, 19);
            this.chkAisle.TabIndex = 1;
            this.chkAisle.Text = "Aisle";
            this.chkAisle.UseVisualStyleBackColor = true;

            // chkExtraLegroom
            this.chkExtraLegroom.AutoSize = true;
            this.chkExtraLegroom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkExtraLegroom.Location = new System.Drawing.Point(10, 70);
            this.chkExtraLegroom.Name = "chkExtraLegroom";
            this.chkExtraLegroom.Size = new System.Drawing.Size(107, 19);
            this.chkExtraLegroom.TabIndex = 2;
            this.chkExtraLegroom.Text = "Extra Legroom";
            this.chkExtraLegroom.UseVisualStyleBackColor = true;

            // chkQuietZone
            this.chkQuietZone.AutoSize = true;
            this.chkQuietZone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkQuietZone.Location = new System.Drawing.Point(10, 100);
            this.chkQuietZone.Name = "chkQuietZone";
            this.chkQuietZone.Size = new System.Drawing.Size(84, 19);
            this.chkQuietZone.TabIndex = 3;
            this.chkQuietZone.Text = "Quiet Zone";
            this.chkQuietZone.UseVisualStyleBackColor = true;

            // seatInfoPanel
            this.seatInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.seatInfoPanel.BackColor = System.Drawing.Color.White;
            this.seatInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seatInfoPanel.Location = new System.Drawing.Point(720, 250);
            this.seatInfoPanel.Name = "seatInfoPanel";
            this.seatInfoPanel.Padding = new System.Windows.Forms.Padding(10);
            this.seatInfoPanel.Size = new System.Drawing.Size(230, 180);
            this.seatInfoPanel.TabIndex = 5;

            // lblSeatInfo
            this.lblSeatInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeatInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeatInfo.Location = new System.Drawing.Point(10, 10);
            this.lblSeatInfo.Name = "lblSeatInfo";
            this.lblSeatInfo.Size = new System.Drawing.Size(210, 30);
            this.lblSeatInfo.TabIndex = 0;
            this.lblSeatInfo.Text = "Selected Seat: None";
            this.lblSeatInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnSelectSeat
            this.btnSelectSeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSeat.BackColor = System.Drawing.Color.FromArgb(0, 115, 207);
            this.btnSelectSeat.FlatAppearance.BorderSize = 0;
            this.btnSelectSeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectSeat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectSeat.ForeColor = System.Drawing.Color.White;
            this.btnSelectSeat.Location = new System.Drawing.Point(720, 440);
            this.btnSelectSeat.Name = "btnSelectSeat";
            this.btnSelectSeat.Size = new System.Drawing.Size(230, 30);
            this.btnSelectSeat.TabIndex = 6;
            this.btnSelectSeat.Text = "SELECT THIS SEAT";
            this.btnSelectSeat.UseVisualStyleBackColor = false;

            // Add controls to panels
            this.filtersPanel.Controls.Add(this.chkWindow);
            this.filtersPanel.Controls.Add(this.chkAisle);
            this.filtersPanel.Controls.Add(this.chkExtraLegroom);
            this.filtersPanel.Controls.Add(this.chkQuietZone);

            this.seatInfoPanel.Controls.Add(this.lblSeatInfo);

            // SeatMapControl
            this.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.filtersPanel);
            this.Controls.Add(this.seatInfoPanel);
            this.Controls.Add(this.btnSelectSeat);
            this.Controls.Add(this.cabinPanel);
            this.Name = "SeatMapControl";
            this.Size = new System.Drawing.Size(960, 440);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel cabinPanel;
        private System.Windows.Forms.FlowLayoutPanel filtersPanel;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox chkWindow;
        private System.Windows.Forms.CheckBox chkAisle;
        private System.Windows.Forms.CheckBox chkExtraLegroom;
        private System.Windows.Forms.CheckBox chkQuietZone;
        private System.Windows.Forms.Panel seatInfoPanel;
        private System.Windows.Forms.Label lblSeatInfo;
        private System.Windows.Forms.Button btnSelectSeat;
    }
}