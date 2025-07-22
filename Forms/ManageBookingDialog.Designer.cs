namespace FlightBookingSystem.Controls
{
    partial class ManageBookingDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFlightInfo;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPNR;
        private System.Windows.Forms.Label lblIssuedAt;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.DateTimePicker dtpDeparture;
        private System.Windows.Forms.DateTimePicker dtpArrival;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnGeneratePDF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

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
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPNR = new System.Windows.Forms.Label();
            this.lblIssuedAt = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.dtpDeparture = new System.Windows.Forms.DateTimePicker();
            this.dtpArrival = new System.Windows.Forms.DateTimePicker();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnGeneratePDF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDuration.Location = new System.Drawing.Point(30, 160);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(0, 19);
            this.lblDuration.TabIndex = 4;

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
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
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

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Departure:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Arrival:";

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(120, 190);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 23);
            this.txtFirstName.TabIndex = 12;

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(290, 190);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 23);
            this.txtLastName.TabIndex = 13;

            // dtpDeparture
            this.dtpDeparture.CustomFormat = "ddd, MMM dd yyyy HH:mm";
            this.dtpDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeparture.Location = new System.Drawing.Point(120, 110);
            this.dtpDeparture.Name = "dtpDeparture";
            this.dtpDeparture.Size = new System.Drawing.Size(200, 23);
            this.dtpDeparture.TabIndex = 14;

            // dtpArrival
            this.dtpArrival.CustomFormat = "ddd, MMM dd yyyy HH:mm";
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrival.Location = new System.Drawing.Point(120, 135);
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.Size = new System.Drawing.Size(200, 23);
            this.dtpArrival.TabIndex = 15;

            // btnSaveChanges
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(0, 115, 207);
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(30, 410);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(180, 40);
            this.btnSaveChanges.TabIndex = 16;
            this.btnSaveChanges.Text = "SAVE CHANGES";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);

            // btnGeneratePDF
            this.btnGeneratePDF.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.btnGeneratePDF.FlatAppearance.BorderSize = 0;
            this.btnGeneratePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePDF.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGeneratePDF.Location = new System.Drawing.Point(230, 410);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(120, 40);
            this.btnGeneratePDF.TabIndex = 17;
            this.btnGeneratePDF.Text = "GENERATE PDF";
            this.btnGeneratePDF.UseVisualStyleBackColor = false;
            this.btnGeneratePDF.Click += new System.EventHandler(this.btnGeneratePDF_Click);

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(30, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Passenger:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 19;

            // ManageBookingDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 470);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGeneratePDF);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.dtpArrival);
            this.Controls.Add(this.dtpDeparture);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.lblIssuedAt);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPNR);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label2);
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