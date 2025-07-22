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
            lblFlightInfo = new Label();
            lblRoute = new Label();
            lblDuration = new Label();
            lblSeat = new Label();
            lblStatus = new Label();
            lblPNR = new Label();
            lblIssuedAt = new Label();
            lblPrice = new Label();
            btnCancelBooking = new Button();
            btnClose = new Button();
            label1 = new Label();
            label2 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            dtpDeparture = new DateTimePicker();
            dtpArrival = new DateTimePicker();
            btnSaveChanges = new Button();
            btnGeneratePDF = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblFlightInfo
            // 
            lblFlightInfo.AutoSize = true;
            lblFlightInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFlightInfo.Location = new Point(30, 30);
            lblFlightInfo.Name = "lblFlightInfo";
            lblFlightInfo.Size = new Size(0, 30);
            lblFlightInfo.TabIndex = 0;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Font = new Font("Segoe UI", 14F);
            lblRoute.Location = new Point(30, 70);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(0, 25);
            lblRoute.TabIndex = 1;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 10F);
            lblDuration.Location = new Point(30, 160);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(0, 19);
            lblDuration.TabIndex = 4;
            // 
            // lblSeat
            // 
            lblSeat.AutoSize = true;
            lblSeat.Font = new Font("Segoe UI", 10F);
            lblSeat.Location = new Point(30, 215);
            lblSeat.Name = "lblSeat";
            lblSeat.Size = new Size(0, 19);
            lblSeat.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(30, 240);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 19);
            lblStatus.TabIndex = 7;
            // 
            // lblPNR
            // 
            lblPNR.AutoSize = true;
            lblPNR.Font = new Font("Segoe UI", 10F);
            lblPNR.Location = new Point(30, 265);
            lblPNR.Name = "lblPNR";
            lblPNR.Size = new Size(0, 19);
            lblPNR.TabIndex = 8;
            // 
            // lblIssuedAt
            // 
            lblIssuedAt.AutoSize = true;
            lblIssuedAt.Font = new Font("Segoe UI", 10F);
            lblIssuedAt.Location = new Point(30, 290);
            lblIssuedAt.Name = "lblIssuedAt";
            lblIssuedAt.Size = new Size(0, 19);
            lblIssuedAt.TabIndex = 12;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrice.Location = new Point(30, 315);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(0, 19);
            lblPrice.TabIndex = 9;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.BackColor = Color.OrangeRed;
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.FlatStyle = FlatStyle.Flat;
            btnCancelBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelBooking.ForeColor = Color.White;
            btnCancelBooking.Location = new Point(30, 360);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(180, 40);
            btnCancelBooking.TabIndex = 10;
            btnCancelBooking.Text = "CANCEL BOOKING";
            btnCancelBooking.UseVisualStyleBackColor = false;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(240, 240, 245);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(273, 418);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(180, 40);
            btnClose.TabIndex = 11;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(30, 110);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 10;
            label1.Text = "Departure:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(30, 135);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 11;
            label2.Text = "Arrival:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(120, 190);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 23);
            txtFirstName.TabIndex = 12;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(290, 190);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 23);
            txtLastName.TabIndex = 13;
            // 
            // dtpDeparture
            // 
            dtpDeparture.CustomFormat = "ddd, MMM dd yyyy HH:mm";
            dtpDeparture.Format = DateTimePickerFormat.Custom;
            dtpDeparture.Location = new Point(120, 110);
            dtpDeparture.Name = "dtpDeparture";
            dtpDeparture.Size = new Size(200, 23);
            dtpDeparture.TabIndex = 14;
            // 
            // dtpArrival
            // 
            dtpArrival.CustomFormat = "ddd, MMM dd yyyy HH:mm";
            dtpArrival.Format = DateTimePickerFormat.Custom;
            dtpArrival.Location = new Point(120, 135);
            dtpArrival.Name = "dtpArrival";
            dtpArrival.Size = new Size(200, 23);
            dtpArrival.TabIndex = 15;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = Color.FromArgb(0, 115, 207);
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(273, 360);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(180, 40);
            btnSaveChanges.TabIndex = 16;
            btnSaveChanges.Text = "SAVE CHANGES";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnGeneratePDF
            // 
            btnGeneratePDF.BackColor = Color.FromArgb(240, 240, 245);
            btnGeneratePDF.FlatAppearance.BorderSize = 0;
            btnGeneratePDF.FlatStyle = FlatStyle.Flat;
            btnGeneratePDF.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGeneratePDF.Location = new Point(30, 418);
            btnGeneratePDF.Name = "btnGeneratePDF";
            btnGeneratePDF.Size = new Size(180, 40);
            btnGeneratePDF.TabIndex = 17;
            btnGeneratePDF.Text = "GENERATE PDF ";
            btnGeneratePDF.UseVisualStyleBackColor = false;
            btnGeneratePDF.Click += btnGeneratePDF_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(30, 190);
            label3.Name = "label3";
            label3.Size = new Size(82, 19);
            label3.TabIndex = 18;
            label3.Text = "Passenger:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(120, 215);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 19;
            // 
            // ManageBookingDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 470);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnGeneratePDF);
            Controls.Add(btnSaveChanges);
            Controls.Add(dtpArrival);
            Controls.Add(dtpDeparture);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnClose);
            Controls.Add(btnCancelBooking);
            Controls.Add(lblIssuedAt);
            Controls.Add(lblPrice);
            Controls.Add(lblPNR);
            Controls.Add(lblStatus);
            Controls.Add(lblSeat);
            Controls.Add(lblDuration);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblRoute);
            Controls.Add(lblFlightInfo);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageBookingDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Booking";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}