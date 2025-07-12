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
            tabControl = new TabControl();
            passengerTab = new TabPage();
            paymentTab = new TabPage();
            seatTab = new TabPage();
            seatMapControl = new SeatMapControl();
            btnConfirm = new Button();
            btnBack = new Button();
            lblSeatInfo = new Label();
            lblFlightInfo = new Label();
            tabControl.SuspendLayout();
            seatTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(passengerTab);
            tabControl.Controls.Add(paymentTab);
            tabControl.Controls.Add(seatTab);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 30, 3, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 500);
            tabControl.TabIndex = 0;
            // 
            // passengerTab
            // 
            passengerTab.BackColor = Color.FromArgb(245, 249, 255);
            passengerTab.Location = new Point(4, 24);
            passengerTab.Name = "passengerTab";
            passengerTab.Padding = new Padding(20);
            passengerTab.Size = new Size(992, 472);
            passengerTab.TabIndex = 0;
            passengerTab.Text = "Passenger Information";
            // 
            // paymentTab
            // 
            paymentTab.BackColor = Color.FromArgb(245, 249, 255);
            paymentTab.Location = new Point(4, 24);
            paymentTab.Name = "paymentTab";
            paymentTab.Padding = new Padding(20);
            paymentTab.Size = new Size(992, 472);
            paymentTab.TabIndex = 1;
            paymentTab.Text = "Payment Details";
            // 
            // seatTab
            // 
            seatTab.BackColor = Color.FromArgb(245, 249, 255);
            seatTab.Controls.Add(seatMapControl);
            seatTab.Location = new Point(4, 24);
            seatTab.Name = "seatTab";
            seatTab.Padding = new Padding(10);
            seatTab.Size = new Size(992, 472);
            seatTab.TabIndex = 2;
            seatTab.Text = "Seat Selection";
            // 
            // seatMapControl
            // 
            seatMapControl.BackColor = Color.FromArgb(245, 249, 255);
            seatMapControl.Dock = DockStyle.Fill;
            seatMapControl.Location = new Point(10, 10);
            seatMapControl.Name = "seatMapControl";
            seatMapControl.Size = new Size(972, 452);
            seatMapControl.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirm.BackColor = Color.FromArgb(0, 115, 207);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(800, 560);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(180, 50);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "CONFIRM BOOKING";
            btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.BackColor = Color.FromArgb(220, 220, 230);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.Location = new Point(20, 560);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(120, 50);
            btnBack.TabIndex = 2;
            btnBack.Text = "BACK";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // lblSeatInfo
            // 
            lblSeatInfo.AutoSize = true;
            lblSeatInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSeatInfo.Location = new Point(511, 525);
            lblSeatInfo.Name = "lblSeatInfo";
            lblSeatInfo.Size = new Size(120, 15);
            lblSeatInfo.TabIndex = 10;
            lblSeatInfo.Text = "Selected Seat: None";
            // 
            // lblFlightInfo
            // 
            lblFlightInfo.Dock = DockStyle.Top;
            lblFlightInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFlightInfo.ForeColor = Color.FromArgb(0, 60, 120);
            lblFlightInfo.Location = new Point(0, 500);
            lblFlightInfo.Name = "lblFlightInfo";
            lblFlightInfo.Padding = new Padding(20, 10, 20, 10);
            lblFlightInfo.Size = new Size(1000, 66);
            lblFlightInfo.TabIndex = 11;
            lblFlightInfo.Text = "Flight: AA123 from New York (JFK) to London (LHR)";
            lblFlightInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 249, 255);
            Controls.Add(lblFlightInfo);
            Controls.Add(lblSeatInfo);
            Controls.Add(btnBack);
            Controls.Add(btnConfirm);
            Controls.Add(tabControl);
            Name = "BookingControl";
            Size = new Size(1000, 630);
            tabControl.ResumeLayout(false);
            seatTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblFlightInfo;
    }
}