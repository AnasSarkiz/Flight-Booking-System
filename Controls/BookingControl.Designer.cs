namespace FlightBookingSystem.Controls
{
    partial class BookingControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            btnConfirm = new Button();
            btnBack = new Button();
            lblSeatInfo = new Label();
            lblFlightInfo = new Label();
            tabControl = new TabControl();
            passengerTab = new TabPage();
            dtpDob = new DateTimePicker();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            cmbNationality = new ComboBox();
            txtPassport = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            paymentTab = new TabPage();
            lblTotalPrice = new Label();
            txtCVV = new MaskedTextBox();
            txtExpiry = new MaskedTextBox();
            txtCardNumber = new MaskedTextBox();
            txtCardName = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            tabControl.SuspendLayout();
            passengerTab.SuspendLayout();
            paymentTab.SuspendLayout();
            SuspendLayout();
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
            btnBack.BackColor = Color.FromArgb(240, 240, 245);
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
            lblSeatInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSeatInfo.AutoSize = true;
            lblSeatInfo.Font = new Font("Segoe UI", 10F);
            lblSeatInfo.ForeColor = Color.FromArgb(70, 70, 80);
            lblSeatInfo.Location = new Point(20, 525);
            lblSeatInfo.Name = "lblSeatInfo";
            lblSeatInfo.Size = new Size(126, 19);
            lblSeatInfo.TabIndex = 10;
            lblSeatInfo.Text = "Assigned Seat: 12A";
            // 
            // lblFlightInfo
            // 
            lblFlightInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFlightInfo.BackColor = Color.White;
            lblFlightInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFlightInfo.ForeColor = Color.FromArgb(0, 60, 120);
            lblFlightInfo.Location = new Point(0, 470);
            lblFlightInfo.Name = "lblFlightInfo";
            lblFlightInfo.Padding = new Padding(20, 15, 20, 15);
            lblFlightInfo.Size = new Size(1000, 70);
            lblFlightInfo.TabIndex = 11;
            lblFlightInfo.Text = "Flight Info";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(passengerTab);
            tabControl.Controls.Add(paymentTab);
            tabControl.Dock = DockStyle.Top;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.ItemSize = new Size(180, 25);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 500);
            tabControl.TabIndex = 0;
            // 
            // passengerTab
            // 
            passengerTab.BackColor = Color.White;
            passengerTab.Controls.Add(dtpDob);
            passengerTab.Controls.Add(txtPhone);
            passengerTab.Controls.Add(txtEmail);
            passengerTab.Controls.Add(cmbNationality);
            passengerTab.Controls.Add(txtPassport);
            passengerTab.Controls.Add(txtLastName);
            passengerTab.Controls.Add(txtFirstName);
            passengerTab.Controls.Add(label7);
            passengerTab.Controls.Add(label6);
            passengerTab.Controls.Add(label5);
            passengerTab.Controls.Add(label4);
            passengerTab.Controls.Add(label3);
            passengerTab.Controls.Add(label2);
            passengerTab.Controls.Add(label1);
            passengerTab.Location = new Point(4, 29);
            passengerTab.Name = "passengerTab";
            passengerTab.Padding = new Padding(20);
            passengerTab.Size = new Size(992, 467);
            passengerTab.TabIndex = 0;
            passengerTab.Text = "Passenger Information";
            // 
            // dtpDob
            // 
            dtpDob.Font = new Font("Segoe UI", 10F);
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(180, 343);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(631, 25);
            dtpDob.TabIndex = 13;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(180, 293);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(631, 25);
            txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(180, 243);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(631, 25);
            txtEmail.TabIndex = 11;
            // 
            // cmbNationality
            // 
            cmbNationality.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNationality.Font = new Font("Segoe UI", 10F);
            cmbNationality.FormattingEnabled = true;
            cmbNationality.Items.AddRange(new object[] { "US", "UK", "CA", "AU", "JP", "DE", "FR" });
            cmbNationality.Location = new Point(180, 193);
            cmbNationality.Name = "cmbNationality";
            cmbNationality.Size = new Size(631, 25);
            cmbNationality.TabIndex = 10;
            // 
            // txtPassport
            // 
            txtPassport.Font = new Font("Segoe UI", 10F);
            txtPassport.Location = new Point(180, 143);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(631, 25);
            txtPassport.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(180, 93);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(631, 25);
            txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(180, 43);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(631, 25);
            txtFirstName.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(50, 343);
            label7.Name = "label7";
            label7.Size = new Size(90, 19);
            label7.TabIndex = 6;
            label7.Text = "Date of Birth:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(50, 293);
            label6.Name = "label6";
            label6.Size = new Size(51, 19);
            label6.TabIndex = 5;
            label6.Text = "Phone:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(50, 243);
            label5.Name = "label5";
            label5.Size = new Size(44, 19);
            label5.TabIndex = 4;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(50, 193);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 3;
            label4.Text = "Nationality:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(50, 143);
            label3.Name = "label3";
            label3.Size = new Size(119, 19);
            label3.TabIndex = 2;
            label3.Text = "Passport Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(50, 93);
            label2.Name = "label2";
            label2.Size = new Size(77, 19);
            label2.TabIndex = 1;
            label2.Text = "Last Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(50, 43);
            label1.Name = "label1";
            label1.Size = new Size(78, 19);
            label1.TabIndex = 0;
            label1.Text = "First Name:";
            // 
            // paymentTab
            // 
            paymentTab.BackColor = Color.White;
            paymentTab.Controls.Add(lblTotalPrice);
            paymentTab.Controls.Add(txtCVV);
            paymentTab.Controls.Add(txtExpiry);
            paymentTab.Controls.Add(txtCardNumber);
            paymentTab.Controls.Add(txtCardName);
            paymentTab.Controls.Add(label11);
            paymentTab.Controls.Add(label10);
            paymentTab.Controls.Add(label9);
            paymentTab.Controls.Add(label8);
            paymentTab.Location = new Point(4, 29);
            paymentTab.Name = "paymentTab";
            paymentTab.Padding = new Padding(20);
            paymentTab.Size = new Size(992, 467);
            paymentTab.TabIndex = 1;
            paymentTab.Text = "Payment Details";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPrice.ForeColor = Color.FromArgb(0, 115, 207);
            lblTotalPrice.Location = new Point(25, 251);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(56, 21);
            lblTotalPrice.TabIndex = 8;
            lblTotalPrice.Text = "Total: ";
            // 
            // txtCVV
            // 
            txtCVV.Font = new Font("Segoe UI", 10F);
            txtCVV.Location = new Point(155, 201);
            txtCVV.Mask = "###";
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(106, 25);
            txtCVV.TabIndex = 7;
            // 
            // txtExpiry
            // 
            txtExpiry.Font = new Font("Segoe UI", 10F);
            txtExpiry.Location = new Point(155, 151);
            txtExpiry.Mask = "##/##";
            txtExpiry.Name = "txtExpiry";
            txtExpiry.Size = new Size(106, 25);
            txtExpiry.TabIndex = 6;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Font = new Font("Segoe UI", 10F);
            txtCardNumber.Location = new Point(155, 101);
            txtCardNumber.Mask = "####-####-####-####";
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(441, 25);
            txtCardNumber.TabIndex = 5;
            // 
            // txtCardName
            // 
            txtCardName.Font = new Font("Segoe UI", 10F);
            txtCardName.Location = new Point(155, 51);
            txtCardName.Name = "txtCardName";
            txtCardName.Size = new Size(441, 25);
            txtCardName.TabIndex = 4;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(25, 201);
            label11.Name = "label11";
            label11.Size = new Size(39, 19);
            label11.TabIndex = 3;
            label11.Text = "CVV:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.Location = new Point(25, 151);
            label10.Name = "label10";
            label10.Size = new Size(81, 19);
            label10.TabIndex = 2;
            label10.Text = "Expiry Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(25, 101);
            label9.Name = "label9";
            label9.Size = new Size(95, 19);
            label9.TabIndex = 1;
            label9.Text = "Card Number:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(25, 51);
            label8.Name = "label8";
            label8.Size = new Size(120, 19);
            label8.TabIndex = 0;
            label8.Text = "Cardholder Name:";
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblFlightInfo);
            Controls.Add(lblSeatInfo);
            Controls.Add(btnBack);
            Controls.Add(btnConfirm);
            Controls.Add(tabControl);
            Name = "BookingControl";
            Size = new Size(1000, 630);
            tabControl.ResumeLayout(false);
            passengerTab.ResumeLayout(false);
            passengerTab.PerformLayout();
            paymentTab.ResumeLayout(false);
            paymentTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblSeatInfo;
        private System.Windows.Forms.Label lblFlightInfo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage passengerTab;
        private System.Windows.Forms.TabPage paymentTab;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.MaskedTextBox txtCVV;
        private System.Windows.Forms.MaskedTextBox txtExpiry;
        private System.Windows.Forms.MaskedTextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}