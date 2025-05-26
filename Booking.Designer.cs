namespace Flight_Booking_System
{
    partial class Booking
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dobPicker;
        private System.Windows.Forms.ComboBox seatCombo;
        private System.Windows.Forms.RadioButton economyRadio;
        private System.Windows.Forms.RadioButton businessRadio;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Label labelPassengerName;
        private System.Windows.Forms.Label labelPassengerID;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelFlightDate;
        private System.Windows.Forms.Label labelFlightClass;
        private System.Windows.Forms.Label labelSeatNumber;
        private System.Windows.Forms.Label labelPrice;


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
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPassport = new TextBox();
            txtNationality = new TextBox();
            txtEmail = new TextBox();
            dobPicker = new DateTimePicker();
            seatCombo = new ComboBox();
            economyRadio = new RadioButton();
            businessRadio = new RadioButton();
            txtCardNumber = new TextBox();
            txtExpiry = new TextBox();
            txtCVV = new TextBox();
            confirmBtn = new Button();
            labelPassengerName = new Label();
            labelPassengerID = new Label();
            lblNationality = new Label();
            labelEmail = new Label();
            labelFlightDate = new Label();
            labelFlightClass = new Label();
            labelSeatNumber = new Label();
            labelPrice = new Label();
            personalInfo = new GroupBox();
            flightDetiles = new GroupBox();
            payment = new GroupBox();
            cardNamelbl = new Label();
            label1 = new Label();
            cardNameTxt = new TextBox();
            lblExpiry = new Label();
            lblCVV = new Label();
            personalInfo.SuspendLayout();
            flightDetiles.SuspendLayout();
            payment.SuspendLayout();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(137, 32);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 11;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(264, 32);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 12;
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(137, 84);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(100, 23);
            txtPassport.TabIndex = 13;
            // 
            // txtNationality
            // 
            txtNationality.Location = new Point(137, 146);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(100, 23);
            txtNationality.TabIndex = 14;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(137, 204);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 15;
            // 
            // dobPicker
            // 
            dobPicker.Location = new Point(166, 18);
            dobPicker.Name = "dobPicker";
            dobPicker.Size = new Size(200, 23);
            dobPicker.TabIndex = 16;
            // 
            // seatCombo
            // 
            seatCombo.Location = new Point(166, 79);
            seatCombo.Name = "seatCombo";
            seatCombo.Size = new Size(121, 23);
            seatCombo.TabIndex = 17;
            // 
            // economyRadio
            // 
            economyRadio.Location = new Point(293, 140);
            economyRadio.Name = "economyRadio";
            economyRadio.Size = new Size(104, 24);
            economyRadio.TabIndex = 18;
            // 
            // businessRadio
            // 
            businessRadio.Location = new Point(166, 140);
            businessRadio.Name = "businessRadio";
            businessRadio.Size = new Size(104, 24);
            businessRadio.TabIndex = 19;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(171, 118);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(448, 23);
            txtCardNumber.TabIndex = 20;
            // 
            // txtExpiry
            // 
            txtExpiry.Location = new Point(132, 216);
            txtExpiry.Name = "txtExpiry";
            txtExpiry.Size = new Size(212, 23);
            txtExpiry.TabIndex = 21;
            // 
            // txtCVV
            // 
            txtCVV.Location = new Point(415, 216);
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(204, 23);
            txtCVV.TabIndex = 22;
            // 
            // confirmBtn
            // 
            confirmBtn.Location = new Point(267, 603);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(250, 23);
            confirmBtn.TabIndex = 23;
            confirmBtn.Text = "Confirm";
            // 
            // labelPassengerName
            // 
            labelPassengerName.AutoSize = true;
            labelPassengerName.Location = new Point(8, 35);
            labelPassengerName.Name = "labelPassengerName";
            labelPassengerName.Size = new Size(98, 15);
            labelPassengerName.TabIndex = 0;
            labelPassengerName.Text = "Passenger Name:";
            // 
            // labelPassengerID
            // 
            labelPassengerID.AutoSize = true;
            labelPassengerID.Location = new Point(8, 87);
            labelPassengerID.Name = "labelPassengerID";
            labelPassengerID.Size = new Size(77, 15);
            labelPassengerID.TabIndex = 1;
            labelPassengerID.Text = "Passenger ID:";
            // 
            // lblNationality
            // 
            lblNationality.AutoSize = true;
            lblNationality.Location = new Point(8, 149);
            lblNationality.Name = "lblNationality";
            lblNationality.Size = new Size(68, 15);
            lblNationality.TabIndex = 2;
            lblNationality.Text = "Nationality:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(8, 212);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email:";
            // 
            // labelFlightDate
            // 
            labelFlightDate.AutoSize = true;
            labelFlightDate.Location = new Point(37, 26);
            labelFlightDate.Name = "labelFlightDate";
            labelFlightDate.Size = new Size(67, 15);
            labelFlightDate.TabIndex = 5;
            labelFlightDate.Text = "Flight Date:";
            // 
            // labelFlightClass
            // 
            labelFlightClass.AutoSize = true;
            labelFlightClass.Location = new Point(37, 145);
            labelFlightClass.Name = "labelFlightClass";
            labelFlightClass.Size = new Size(70, 15);
            labelFlightClass.TabIndex = 7;
            labelFlightClass.Text = "Flight Class:";
            // 
            // labelSeatNumber
            // 
            labelSeatNumber.AutoSize = true;
            labelSeatNumber.Location = new Point(37, 82);
            labelSeatNumber.Name = "labelSeatNumber";
            labelSeatNumber.Size = new Size(79, 15);
            labelSeatNumber.TabIndex = 8;
            labelSeatNumber.Text = "Seat Number:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(38, 203);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(36, 15);
            labelPrice.TabIndex = 9;
            labelPrice.Text = "Price:";
            // 
            // personalInfo
            // 
            personalInfo.Controls.Add(labelPassengerName);
            personalInfo.Controls.Add(labelPassengerID);
            personalInfo.Controls.Add(lblNationality);
            personalInfo.Controls.Add(labelEmail);
            personalInfo.Controls.Add(txtFirstName);
            personalInfo.Controls.Add(txtLastName);
            personalInfo.Controls.Add(txtPassport);
            personalInfo.Controls.Add(txtNationality);
            personalInfo.Controls.Add(txtEmail);
            personalInfo.Location = new Point(3, 3);
            personalInfo.Name = "personalInfo";
            personalInfo.Size = new Size(392, 249);
            personalInfo.TabIndex = 24;
            personalInfo.TabStop = false;
            personalInfo.Text = "Personal Info";
            // 
            // flightDetiles
            // 
            flightDetiles.Controls.Add(labelSeatNumber);
            flightDetiles.Controls.Add(labelFlightDate);
            flightDetiles.Controls.Add(seatCombo);
            flightDetiles.Controls.Add(labelFlightClass);
            flightDetiles.Controls.Add(labelPrice);
            flightDetiles.Controls.Add(dobPicker);
            flightDetiles.Controls.Add(economyRadio);
            flightDetiles.Controls.Add(businessRadio);
            flightDetiles.Location = new Point(432, 3);
            flightDetiles.Name = "flightDetiles";
            flightDetiles.Size = new Size(407, 249);
            flightDetiles.TabIndex = 25;
            flightDetiles.TabStop = false;
            flightDetiles.Text = "Flight detiles";
            // 
            // payment
            // 
            payment.Controls.Add(lblCVV);
            payment.Controls.Add(lblExpiry);
            payment.Controls.Add(cardNameTxt);
            payment.Controls.Add(label1);
            payment.Controls.Add(cardNamelbl);
            payment.Controls.Add(txtCardNumber);
            payment.Controls.Add(txtExpiry);
            payment.Controls.Add(txtCVV);
            payment.Location = new Point(3, 280);
            payment.Name = "payment";
            payment.Size = new Size(836, 282);
            payment.TabIndex = 26;
            payment.TabStop = false;
            payment.Text = "Payment";
            // 
            // cardNamelbl
            // 
            cardNamelbl.AutoSize = true;
            cardNamelbl.Location = new Point(39, 53);
            cardNamelbl.Name = "cardNamelbl";
            cardNamelbl.Size = new Size(109, 15);
            cardNamelbl.TabIndex = 23;
            cardNamelbl.Text = "Card Holder Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 121);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 24;
            label1.Text = "Card Holder Name:";
            // 
            // cardNameTxt
            // 
            cardNameTxt.Location = new Point(171, 53);
            cardNameTxt.Name = "cardNameTxt";
            cardNameTxt.Size = new Size(448, 23);
            cardNameTxt.TabIndex = 25;
            // 
            // lblExpiry
            // 
            lblExpiry.AutoSize = true;
            lblExpiry.Location = new Point(171, 183);
            lblExpiry.Name = "lblExpiry";
            lblExpiry.Size = new Size(134, 15);
            lblExpiry.TabIndex = 26;
            lblExpiry.Text = "Expiration Date: MM/YY";
            // 
            // lblCVV
            // 
            lblCVV.AutoSize = true;
            lblCVV.Location = new Point(508, 183);
            lblCVV.Name = "lblCVV";
            lblCVV.Size = new Size(29, 15);
            lblCVV.TabIndex = 27;
            lblCVV.Text = "CVV";
            // 
            // Booking
            // 
            Controls.Add(payment);
            Controls.Add(flightDetiles);
            Controls.Add(personalInfo);
            Controls.Add(confirmBtn);
            Location = new Point(0, 60);
            Name = "Booking";
            Size = new Size(1187, 687);
            personalInfo.ResumeLayout(false);
            personalInfo.PerformLayout();
            flightDetiles.ResumeLayout(false);
            flightDetiles.PerformLayout();
            payment.ResumeLayout(false);
            payment.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox personalInfo;
        private GroupBox flightDetiles;
        private GroupBox payment;
        private TextBox cardNameTxt;
        private Label label1;
        private Label cardNamelbl;
        private Label lblCVV;
        private Label lblExpiry;
    }
}