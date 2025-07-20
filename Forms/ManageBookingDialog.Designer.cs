namespace FlightBookingSystem.Controls
{
    partial class ManageBookingDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFlightInfo;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblDepartureInfo;
        private System.Windows.Forms.Label lblArrivalInfo;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblPassenger;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPNR;
        private System.Windows.Forms.Label lblIssuedAt;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

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
            this.lblFlightInfo = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblDepartureInfo = new System.Windows.Forms.Label();
            this.lblArrivalInfo = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPassenger = new System.Windows.Forms.Label();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPNR = new System.Windows.Forms.Label();
            this.lblIssuedAt = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblFlightInfo
            this.lblFlightInfo.AutoSize = true;
            this.lblFlightInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFlightInfo.Location = new System.Drawing.Point(30, 30);
            this.lblFlightInfo.Name = "lblFlightInfo";
            this.lblFlightInfo.Size = new System.Drawing.Size(0, 30);
            this.lblFlightInfo.TabIndex = 0;

            // lblRoute
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblRoute.Location = new System.Drawing.Point(30, 70);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(0, 25);
            this.lblRoute.TabIndex = 1;

            // label1 (Departure:)
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Departure:";

            // lblDepartureInfo
            this.lblDepartureInfo.AutoSize = true;
            this.lblDepartureInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDepartureInfo.Location = new System.Drawing.Point(120, 110);
            this.lblDepartureInfo.Name = "lblDepartureInfo";
            this.lblDepartureInfo.Size = new System.Drawing.Size(0, 19);
            this.lblDepartureInfo.TabIndex = 2;

            // label2 (Arrival:)
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Arrival:";

            // lblArrivalInfo
            this.lblArrivalInfo.AutoSize = true;
            this.lblArrivalInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArrivalInfo.Location = new System.Drawing.Point(120, 135);
            this.lblArrivalInfo.Name = "lblArrivalInfo";
            this.lblArrivalInfo.Size = new System.Drawing.Size(0, 19);
            this.lblArrivalInfo.TabIndex = 3;

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDuration.Location = new System.Drawing.Point(30, 160);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(0, 19);
            this.lblDuration.TabIndex = 4;

            // lblPassenger
            this.lblPassenger.AutoSize = true;
            this.lblPassenger.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassenger.Location = new System.Drawing.Point(30, 190);
            this.lblPassenger.Name = "lblPassenger";
            this.lblPassenger.Size = new System.Drawing.Size(0, 19);
            this.lblPassenger.TabIndex = 5;

            // lblSeat
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSeat.Location = new System.Drawing.Point(30, 215);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(0, 19);
            this.lblSeat.TabIndex = 6;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(30, 240);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 19);
            this.lblStatus.TabIndex = 7;

            // lblPNR
            this.lblPNR.AutoSize = true;
            this.lblPNR.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPNR.Location = new System.Drawing.Point(30, 265);
            this.lblPNR.Name = "lblPNR";
            this.lblPNR.Size = new System.Drawing.Size(0, 19);
            this.lblPNR.TabIndex = 8;

            // lblIssuedAt
            this.lblIssuedAt.AutoSize = true;
            this.lblIssuedAt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIssuedAt.Location = new System.Drawing.Point(30, 290);
            this.lblIssuedAt.Name = "lblIssuedAt";
            this.lblIssuedAt.Size = new System.Drawing.Size(0, 19);
            this.lblIssuedAt.TabIndex = 12;

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(30, 315);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 19);
            this.lblPrice.TabIndex = 9;

            // btnCancelBooking
            this.btnCancelBooking.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancelBooking.FlatAppearance.BorderSize = 0;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelBooking.ForeColor = System.Drawing.Color.White;
            this.btnCancelBooking.Location = new System.Drawing.Point(30, 360);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(180, 40);
            this.btnCancelBooking.TabIndex = 10;
            this.btnCancelBooking.Text = "CANCEL BOOKING";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.Location = new System.Drawing.Point(230, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // panel1
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 10);
            this.panel1.TabIndex = 12;

            // ManageBookingDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.lblIssuedAt);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPNR);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.lblPassenger);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblArrivalInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDepartureInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.lblFlightInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageBookingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Booking";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}