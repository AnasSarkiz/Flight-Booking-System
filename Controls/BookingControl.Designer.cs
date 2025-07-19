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
            lblBalance = new Label();
            lblTotalPrice = new Label();
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
            tabControl = new TabControl();
            passengerTab.SuspendLayout();
            tabControl.SuspendLayout();
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
            // lblBalance
            // 
            lblBalance.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBalance.Location = new Point(650, 525);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(130, 19);
            lblBalance.TabIndex = 12;
            lblBalance.Text = "Available Balance:";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPrice.Location = new Point(800, 525);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(83, 19);
            lblTotalPrice.TabIndex = 13;
            lblTotalPrice.Text = "Total Price:";
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
            // tabControl
            // 
            tabControl.Controls.Add(passengerTab);
            tabControl.Dock = DockStyle.Top;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.ItemSize = new Size(180, 25);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 500);
            tabControl.TabIndex = 0;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTotalPrice);
            Controls.Add(lblBalance);
            Controls.Add(lblFlightInfo);
            Controls.Add(lblSeatInfo);
            Controls.Add(btnBack);
            Controls.Add(btnConfirm);
            Controls.Add(tabControl);
            Name = "BookingControl";
            Size = new Size(1000, 630);
            passengerTab.ResumeLayout(false);
            passengerTab.PerformLayout();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private Button btnBack;
        private Label lblSeatInfo;
        private Label lblFlightInfo;
        private Label lblBalance;
        private Label lblTotalPrice;
        private TabControl tabControl;
        private TabPage passengerTab;
        private DateTimePicker dtpDob;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private ComboBox cmbNationality;
        private TextBox txtPassport;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}