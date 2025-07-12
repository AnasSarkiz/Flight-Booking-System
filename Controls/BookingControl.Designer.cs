namespace FlightBookingSystem.Controls
{
    partial class BookingControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage passengerTab;
        private System.Windows.Forms.TabPage paymentTab;
        private System.Windows.Forms.TabPage seatTab;
        private SeatMapControl seatMapControl;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblFlightInfo;
        private System.Windows.Forms.Label lblSeatInfo;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.passengerTab = new System.Windows.Forms.TabPage();
            this.paymentTab = new System.Windows.Forms.TabPage();
            this.seatTab = new System.Windows.Forms.TabPage();
            this.seatMapControl = new FlightBookingSystem.Controls.SeatMapControl();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblFlightInfo = new System.Windows.Forms.Label();
            this.lblSeatInfo = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.seatTab.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.passengerTab);
            this.tabControl.Controls.Add(this.paymentTab);
            this.tabControl.Controls.Add(this.seatTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 40);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 500);
            this.tabControl.TabIndex = 0;

            // 
            // passengerTab
            // 
            this.passengerTab.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
            this.passengerTab.Location = new System.Drawing.Point(4, 24);
            this.passengerTab.Name = "passengerTab";
            this.passengerTab.Padding = new System.Windows.Forms.Padding(20);
            this.passengerTab.Size = new System.Drawing.Size(992, 472);
            this.passengerTab.TabIndex = 0;
            this.passengerTab.Text = "Passenger Information";

            // 
            // paymentTab
            // 
            this.paymentTab.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
            this.paymentTab.Location = new System.Drawing.Point(4, 24);
            this.paymentTab.Name = "paymentTab";
            this.paymentTab.Padding = new System.Windows.Forms.Padding(20);
            this.paymentTab.Size = new System.Drawing.Size(992, 472);
            this.paymentTab.TabIndex = 1;
            this.paymentTab.Text = "Payment Details";

            // 
            // seatTab
            // 
            this.seatTab.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
            this.seatTab.Controls.Add(this.seatMapControl);
            this.seatTab.Location = new System.Drawing.Point(4, 24);
            this.seatTab.Name = "seatTab";
            this.seatTab.Padding = new System.Windows.Forms.Padding(10);
            this.seatTab.Size = new System.Drawing.Size(992, 472);
            this.seatTab.TabIndex = 2;
            this.seatTab.Text = "Seat Selection";

            // 
            // seatMapControl
            // 
            this.seatMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seatMapControl.Location = new System.Drawing.Point(10, 10);
            this.seatMapControl.Name = "seatMapControl";
            this.seatMapControl.Size = new System.Drawing.Size(972, 452);
            this.seatMapControl.TabIndex = 0;

            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(0, 115, 207);
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(800, 560);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(180, 50);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "CONFIRM BOOKING";
            this.btnConfirm.UseVisualStyleBackColor = false;

            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(20, 560);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 50);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;

            // 
            // lblFlightInfo
            // 
            this.lblFlightInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFlightInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFlightInfo.ForeColor = System.Drawing.Color.FromArgb(0, 60, 120);
            this.lblFlightInfo.Location = new System.Drawing.Point(0, 0);
            this.lblFlightInfo.Name = "lblFlightInfo";
            this.lblFlightInfo.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.lblFlightInfo.Size = new System.Drawing.Size(1000, 40);
            this.lblFlightInfo.TabIndex = 3;
            this.lblFlightInfo.Text = "Flight: AA123 from New York (JFK) to London (LHR)";
            this.lblFlightInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblSeatInfo
            // 
            this.lblSeatInfo.AutoSize = true;
            this.lblSeatInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeatInfo.Location = new System.Drawing.Point(20, 520);
            this.lblSeatInfo.Name = "lblSeatInfo";
            this.lblSeatInfo.Size = new System.Drawing.Size(200, 15);
            this.lblSeatInfo.TabIndex = 10;
            this.lblSeatInfo.Text = "Selected Seat: None";

            // 
            // BookingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 249, 255);
            this.Controls.Add(this.lblSeatInfo);
            this.Controls.Add(this.lblFlightInfo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tabControl);
            this.Name = "BookingControl";
            this.Size = new System.Drawing.Size(1000, 630);
            this.tabControl.ResumeLayout(false);
            this.seatTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}