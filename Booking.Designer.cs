namespace Flight_Booking_System
{
    partial class Booking
    {
        private System.ComponentModel.IContainer components = null;

        // ────────────────────────────────────────────────────────────────────
        // Personal Info Controls
        // ────────────────────────────────────────────────────────────────────
        private System.Windows.Forms.GroupBox personalInfoGroup;
        private System.Windows.Forms.TableLayoutPanel personalInfoTable;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelPassport;
        private System.Windows.Forms.Label labelNationality;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.TextBox txtEmail;

        // ────────────────────────────────────────────────────────────────────
        // Flight Details Controls
        // ────────────────────────────────────────────────────────────────────
        private System.Windows.Forms.GroupBox flightDetailsGroup;
        private System.Windows.Forms.TableLayoutPanel flightDetailsTable;
        private System.Windows.Forms.Label labelFlightDate;
        private System.Windows.Forms.Label labelSeatNumber;
        private System.Windows.Forms.Panel seatScrollContainer;
        private System.Windows.Forms.TableLayoutPanel seatPanel;
        private System.Windows.Forms.Label labelFlightClass;
        private System.Windows.Forms.RadioButton businessRadio;
        private System.Windows.Forms.RadioButton economyRadio;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox txtPrice;

        // ────────────────────────────────────────────────────────────────────
        // Root Layout & Confirm Button
        // ────────────────────────────────────────────────────────────────────
        private System.Windows.Forms.TableLayoutPanel rootTable;
        private System.Windows.Forms.TableLayoutPanel rightSideTable;
        private System.Windows.Forms.Button confirmBtn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            personalInfoGroup = new GroupBox();
            personalInfoTable = new TableLayoutPanel();
            dateTimePicker1 = new DateTimePicker();
            phoneLbl = new Label();
            textBox2 = new TextBox();
            dobDate = new Label();
            labelFirstName = new Label();
            txtFirstName = new TextBox();
            labelLastName = new Label();
            txtLastName = new TextBox();
            labelPassport = new Label();
            txtPassport = new TextBox();
            labelNationality = new Label();
            txtNationality = new TextBox();
            labelEmail = new Label();
            txtEmail = new TextBox();
            flightDetailsGroup = new GroupBox();
            flightDetailsTable = new TableLayoutPanel();
            labelFlightDate = new Label();
            dobPicker = new DateTimePicker();
            labelSeatNumber = new Label();
            seatScrollContainer = new Panel();
            seatPanel = new TableLayoutPanel();
            labelFlightClass = new Label();
            classFlow = new FlowLayoutPanel();
            businessRadio = new RadioButton();
            economyRadio = new RadioButton();
            labelPrice = new Label();
            txtPrice = new TextBox();
            rootTable = new TableLayoutPanel();
            rightSideTable = new TableLayoutPanel();
            paymentGroup = new GroupBox();
            paymentTable = new TableLayoutPanel();
            labelCardName = new Label();
            txtCardName = new TextBox();
            labelCardNumber = new Label();
            txtCardNumber = new TextBox();
            labelExpiry = new Label();
            txtExpiry = new TextBox();
            labelCVV = new Label();
            txtCVV = new TextBox();
            confirmBtn = new Button();
            personalInfoGroup.SuspendLayout();
            personalInfoTable.SuspendLayout();
            flightDetailsGroup.SuspendLayout();
            flightDetailsTable.SuspendLayout();
            seatScrollContainer.SuspendLayout();
            classFlow.SuspendLayout();
            rootTable.SuspendLayout();
            rightSideTable.SuspendLayout();
            paymentGroup.SuspendLayout();
            paymentTable.SuspendLayout();
            SuspendLayout();
            // 
            // personalInfoGroup
            // 
            personalInfoGroup.Controls.Add(personalInfoTable);
            personalInfoGroup.Dock = DockStyle.Fill;
            personalInfoGroup.Location = new Point(3, 3);
            personalInfoGroup.Name = "personalInfoGroup";
            personalInfoGroup.Size = new Size(394, 629);
            personalInfoGroup.TabIndex = 0;
            personalInfoGroup.TabStop = false;
            personalInfoGroup.Text = "Personal Info";
            // 
            // personalInfoTable
            // 
            personalInfoTable.ColumnCount = 2;
            personalInfoTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            personalInfoTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            personalInfoTable.Controls.Add(dateTimePicker1, 1, 5);
            personalInfoTable.Controls.Add(phoneLbl, 0, 6);
            personalInfoTable.Controls.Add(textBox2, 1, 6);
            personalInfoTable.Controls.Add(dobDate, 0, 5);
            personalInfoTable.Controls.Add(labelFirstName, 0, 0);
            personalInfoTable.Controls.Add(txtFirstName, 1, 0);
            personalInfoTable.Controls.Add(labelLastName, 0, 1);
            personalInfoTable.Controls.Add(txtLastName, 1, 1);
            personalInfoTable.Controls.Add(labelPassport, 0, 2);
            personalInfoTable.Controls.Add(txtPassport, 1, 2);
            personalInfoTable.Controls.Add(labelNationality, 0, 3);
            personalInfoTable.Controls.Add(txtNationality, 1, 3);
            personalInfoTable.Controls.Add(labelEmail, 0, 4);
            personalInfoTable.Controls.Add(txtEmail, 1, 4);
            personalInfoTable.Dock = DockStyle.Fill;
            personalInfoTable.Location = new Point(3, 19);
            personalInfoTable.Name = "personalInfoTable";
            personalInfoTable.RowCount = 8;
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            personalInfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            personalInfoTable.Size = new Size(388, 607);
            personalInfoTable.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Left;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(138, 176);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(120, 23);
            dateTimePicker1.TabIndex = 14;
            // 
            // phoneLbl
            // 
            phoneLbl.Anchor = AnchorStyles.Right;
            phoneLbl.AutoSize = true;
            phoneLbl.Location = new Point(88, 208);
            phoneLbl.Name = "phoneLbl";
            phoneLbl.Size = new Size(44, 15);
            phoneLbl.TabIndex = 12;
            phoneLbl.Text = "Phone:";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Left;
            textBox2.Location = new Point(138, 204);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 23);
            textBox2.TabIndex = 13;
            // 
            // dobDate
            // 
            dobDate.Anchor = AnchorStyles.Right;
            dobDate.AutoSize = true;
            dobDate.Location = new Point(54, 179);
            dobDate.Name = "dobDate";
            dobDate.Size = new Size(78, 15);
            dobDate.TabIndex = 10;
            dobDate.Text = "Date Of Birth:";
            // 
            // labelFirstName
            // 
            labelFirstName.Anchor = AnchorStyles.Right;
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(65, 11);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(67, 15);
            labelFirstName.TabIndex = 0;
            labelFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left;
            txtFirstName.Location = new Point(138, 7);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 1;
            // 
            // labelLastName
            // 
            labelLastName.Anchor = AnchorStyles.Right;
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(66, 49);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(66, 15);
            labelLastName.TabIndex = 2;
            labelLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Left;
            txtLastName.Location = new Point(138, 45);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 3;
            // 
            // labelPassport
            // 
            labelPassport.Anchor = AnchorStyles.Right;
            labelPassport.AutoSize = true;
            labelPassport.Location = new Point(55, 87);
            labelPassport.Name = "labelPassport";
            labelPassport.Size = new Size(77, 15);
            labelPassport.TabIndex = 4;
            labelPassport.Text = "Passport No.:";
            // 
            // txtPassport
            // 
            txtPassport.Anchor = AnchorStyles.Left;
            txtPassport.Location = new Point(138, 83);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(200, 23);
            txtPassport.TabIndex = 5;
            // 
            // labelNationality
            // 
            labelNationality.Anchor = AnchorStyles.Right;
            labelNationality.AutoSize = true;
            labelNationality.Location = new Point(64, 122);
            labelNationality.Name = "labelNationality";
            labelNationality.Size = new Size(68, 15);
            labelNationality.TabIndex = 6;
            labelNationality.Text = "Nationality:";
            // 
            // txtNationality
            // 
            txtNationality.Anchor = AnchorStyles.Left;
            txtNationality.Location = new Point(138, 118);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(200, 23);
            txtNationality.TabIndex = 7;
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Right;
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(93, 151);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 8;
            labelEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left;
            txtEmail.Location = new Point(138, 148);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 9;
            // 
            // flightDetailsGroup
            // 
            flightDetailsGroup.Controls.Add(flightDetailsTable);
            flightDetailsGroup.Dock = DockStyle.Fill;
            flightDetailsGroup.Location = new Point(3, 3);
            flightDetailsGroup.Name = "flightDetailsGroup";
            flightDetailsGroup.Size = new Size(588, 453);
            flightDetailsGroup.TabIndex = 1;
            flightDetailsGroup.TabStop = false;
            flightDetailsGroup.Text = "Flight Details";
            // 
            // flightDetailsTable
            // 
            flightDetailsTable.ColumnCount = 2;
            flightDetailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            flightDetailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            flightDetailsTable.Controls.Add(labelFlightDate, 0, 0);
            flightDetailsTable.Controls.Add(dobPicker, 1, 0);
            flightDetailsTable.Controls.Add(labelSeatNumber, 0, 1);
            flightDetailsTable.Controls.Add(seatScrollContainer, 1, 1);
            flightDetailsTable.Controls.Add(labelFlightClass, 0, 2);
            flightDetailsTable.Controls.Add(classFlow, 1, 2);
            flightDetailsTable.Controls.Add(labelPrice, 0, 3);
            flightDetailsTable.Controls.Add(txtPrice, 1, 3);
            flightDetailsTable.Dock = DockStyle.Fill;
            flightDetailsTable.Location = new Point(3, 19);
            flightDetailsTable.Name = "flightDetailsTable";
            flightDetailsTable.RowCount = 4;
            flightDetailsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            flightDetailsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            flightDetailsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            flightDetailsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            flightDetailsTable.Size = new Size(582, 431);
            flightDetailsTable.TabIndex = 0;
            // 
            // labelFlightDate
            // 
            labelFlightDate.Anchor = AnchorStyles.Right;
            labelFlightDate.AutoSize = true;
            labelFlightDate.Location = new Point(162, 11);
            labelFlightDate.Name = "labelFlightDate";
            labelFlightDate.Size = new Size(67, 15);
            labelFlightDate.TabIndex = 0;
            labelFlightDate.Text = "Flight Date:";
            // 
            // dobPicker
            // 
            dobPicker.Anchor = AnchorStyles.Left;
            dobPicker.Format = DateTimePickerFormat.Short;
            dobPicker.Location = new Point(235, 7);
            dobPicker.Name = "dobPicker";
            dobPicker.Size = new Size(120, 23);
            dobPicker.TabIndex = 1;
            // 
            // labelSeatNumber
            // 
            labelSeatNumber.Anchor = AnchorStyles.Right;
            labelSeatNumber.AutoSize = true;
            labelSeatNumber.Location = new Point(146, 189);
            labelSeatNumber.Name = "labelSeatNumber";
            labelSeatNumber.Size = new Size(83, 15);
            labelSeatNumber.TabIndex = 2;
            labelSeatNumber.Text = "Seat Selection:";
            // 
            // seatScrollContainer
            // 
            seatScrollContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            seatScrollContainer.AutoScroll = true;
            seatScrollContainer.Controls.Add(seatPanel);
            seatScrollContainer.Location = new Point(235, 41);
            seatScrollContainer.Name = "seatScrollContainer";
            seatScrollContainer.Size = new Size(344, 311);
            seatScrollContainer.TabIndex = 3;
            // 
            // seatPanel
            // 
            seatPanel.AutoSize = true;
            seatPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            seatPanel.ColumnCount = 7;
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 53F));
            seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 31F));
            seatPanel.Dock = DockStyle.Fill;
            seatPanel.Location = new Point(0, 0);
            seatPanel.Name = "seatPanel";
            seatPanel.RowCount = 30;
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            seatPanel.Size = new Size(344, 311);
            seatPanel.TabIndex = 0;
            // 
            // labelFlightClass
            // 
            labelFlightClass.Anchor = AnchorStyles.Right;
            labelFlightClass.AutoSize = true;
            labelFlightClass.Location = new Point(192, 366);
            labelFlightClass.Name = "labelFlightClass";
            labelFlightClass.Size = new Size(37, 15);
            labelFlightClass.TabIndex = 3;
            labelFlightClass.Text = "Class:";
            // 
            // classFlow
            // 
            classFlow.Anchor = AnchorStyles.Left;
            classFlow.AutoSize = true;
            classFlow.Controls.Add(businessRadio);
            classFlow.Controls.Add(economyRadio);
            classFlow.Location = new Point(235, 361);
            classFlow.Name = "classFlow";
            classFlow.Size = new Size(157, 25);
            classFlow.TabIndex = 4;
            // 
            // businessRadio
            // 
            businessRadio.AutoSize = true;
            businessRadio.Location = new Point(3, 3);
            businessRadio.Name = "businessRadio";
            businessRadio.Size = new Size(70, 19);
            businessRadio.TabIndex = 4;
            businessRadio.Text = "Business";
            // 
            // economyRadio
            // 
            economyRadio.AutoSize = true;
            economyRadio.Location = new Point(79, 3);
            economyRadio.Name = "economyRadio";
            economyRadio.Size = new Size(75, 19);
            economyRadio.TabIndex = 5;
            economyRadio.Text = "Economy";
            // 
            // labelPrice
            // 
            labelPrice.Anchor = AnchorStyles.Right;
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(193, 404);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(36, 15);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Left;
            txtPrice.Location = new Point(235, 400);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 7;
            // 
            // rootTable
            // 
            rootTable.ColumnCount = 2;
            rootTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            rootTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            rootTable.Controls.Add(personalInfoGroup, 0, 0);
            rootTable.Controls.Add(rightSideTable, 1, 0);
            rootTable.Controls.Add(confirmBtn, 0, 1);
            rootTable.Dock = DockStyle.Fill;
            rootTable.Location = new Point(0, 0);
            rootTable.Name = "rootTable";
            rootTable.RowCount = 2;
            rootTable.RowStyles.Add(new RowStyle(SizeType.Percent, 90.85714F));
            rootTable.RowStyles.Add(new RowStyle(SizeType.Percent, 9.142858F));
            rootTable.Size = new Size(1000, 700);
            rootTable.TabIndex = 0;
            // 
            // rightSideTable
            // 
            rightSideTable.ColumnCount = 1;
            rightSideTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightSideTable.Controls.Add(paymentGroup, 0, 1);
            rightSideTable.Controls.Add(flightDetailsGroup, 0, 0);
            rightSideTable.Dock = DockStyle.Fill;
            rightSideTable.Location = new Point(403, 3);
            rightSideTable.Name = "rightSideTable";
            rightSideTable.RowCount = 2;
            rightSideTable.RowStyles.Add(new RowStyle(SizeType.Percent, 73F));
            rightSideTable.RowStyles.Add(new RowStyle(SizeType.Percent, 27F));
            rightSideTable.Size = new Size(594, 629);
            rightSideTable.TabIndex = 1;
            // 
            // paymentGroup
            // 
            paymentGroup.Controls.Add(paymentTable);
            paymentGroup.Dock = DockStyle.Fill;
            paymentGroup.Location = new Point(3, 462);
            paymentGroup.Name = "paymentGroup";
            paymentGroup.Size = new Size(588, 164);
            paymentGroup.TabIndex = 3;
            paymentGroup.TabStop = false;
            paymentGroup.Text = "Payment Info";
            // 
            // paymentTable
            // 
            paymentTable.ColumnCount = 2;
            paymentTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            paymentTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            paymentTable.Controls.Add(labelCardName, 0, 0);
            paymentTable.Controls.Add(txtCardName, 1, 0);
            paymentTable.Controls.Add(labelCardNumber, 0, 1);
            paymentTable.Controls.Add(txtCardNumber, 1, 1);
            paymentTable.Controls.Add(labelExpiry, 0, 2);
            paymentTable.Controls.Add(txtExpiry, 1, 2);
            paymentTable.Controls.Add(labelCVV, 0, 3);
            paymentTable.Controls.Add(txtCVV, 1, 3);
            paymentTable.Dock = DockStyle.Fill;
            paymentTable.Location = new Point(3, 19);
            paymentTable.Name = "paymentTable";
            paymentTable.RowCount = 4;
            paymentTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            paymentTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            paymentTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            paymentTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            paymentTable.Size = new Size(582, 142);
            paymentTable.TabIndex = 0;
            // 
            // labelCardName
            // 
            labelCardName.Anchor = AnchorStyles.Right;
            labelCardName.AutoSize = true;
            labelCardName.Location = new Point(91, 11);
            labelCardName.Name = "labelCardName";
            labelCardName.Size = new Size(109, 15);
            labelCardName.TabIndex = 0;
            labelCardName.Text = "Card Holder Name:";
            // 
            // txtCardName
            // 
            txtCardName.Anchor = AnchorStyles.Left;
            txtCardName.Location = new Point(206, 7);
            txtCardName.Name = "txtCardName";
            txtCardName.Size = new Size(200, 23);
            txtCardName.TabIndex = 1;
            // 
            // labelCardNumber
            // 
            labelCardNumber.Anchor = AnchorStyles.Right;
            labelCardNumber.AutoSize = true;
            labelCardNumber.Location = new Point(118, 49);
            labelCardNumber.Name = "labelCardNumber";
            labelCardNumber.Size = new Size(82, 15);
            labelCardNumber.TabIndex = 2;
            labelCardNumber.Text = "Card Number:";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Anchor = AnchorStyles.Left;
            txtCardNumber.Location = new Point(206, 45);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(200, 23);
            txtCardNumber.TabIndex = 3;
            // 
            // labelExpiry
            // 
            labelExpiry.Anchor = AnchorStyles.Right;
            labelExpiry.AutoSize = true;
            labelExpiry.Location = new Point(106, 87);
            labelExpiry.Name = "labelExpiry";
            labelExpiry.Size = new Size(94, 15);
            labelExpiry.TabIndex = 4;
            labelExpiry.Text = "Expiry (MM/YY):";
            // 
            // txtExpiry
            // 
            txtExpiry.Anchor = AnchorStyles.Left;
            txtExpiry.Location = new Point(206, 83);
            txtExpiry.Name = "txtExpiry";
            txtExpiry.Size = new Size(100, 23);
            txtExpiry.TabIndex = 5;
            // 
            // labelCVV
            // 
            labelCVV.Anchor = AnchorStyles.Right;
            labelCVV.AutoSize = true;
            labelCVV.Location = new Point(168, 125);
            labelCVV.Name = "labelCVV";
            labelCVV.Size = new Size(32, 15);
            labelCVV.TabIndex = 6;
            labelCVV.Text = "CVV:";
            // 
            // txtCVV
            // 
            txtCVV.Anchor = AnchorStyles.Left;
            txtCVV.Location = new Point(206, 121);
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(80, 23);
            txtCVV.TabIndex = 7;
            // 
            // confirmBtn
            // 
            confirmBtn.Anchor = AnchorStyles.None;
            confirmBtn.AutoSize = true;
            rootTable.SetColumnSpan(confirmBtn, 2);
            confirmBtn.Location = new Point(430, 652);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(140, 30);
            confirmBtn.TabIndex = 1;
            confirmBtn.Text = "Confirm Booking";
            // 
            // Booking
            // 
            Controls.Add(rootTable);
            Name = "Booking";
            Size = new Size(1000, 700);
            personalInfoGroup.ResumeLayout(false);
            personalInfoTable.ResumeLayout(false);
            personalInfoTable.PerformLayout();
            flightDetailsGroup.ResumeLayout(false);
            flightDetailsTable.ResumeLayout(false);
            flightDetailsTable.PerformLayout();
            seatScrollContainer.ResumeLayout(false);
            seatScrollContainer.PerformLayout();
            classFlow.ResumeLayout(false);
            classFlow.PerformLayout();
            rootTable.ResumeLayout(false);
            rootTable.PerformLayout();
            rightSideTable.ResumeLayout(false);
            paymentGroup.ResumeLayout(false);
            paymentTable.ResumeLayout(false);
            paymentTable.PerformLayout();
            ResumeLayout(false);
        }

        private FlowLayoutPanel classFlow;
        private DateTimePicker dateTimePicker1;
        private Label phoneLbl;
        private TextBox textBox2;
        private Label dobDate;
        private DateTimePicker dobPicker;
        private GroupBox paymentGroup;
        private TableLayoutPanel paymentTable;
        private Label labelCardName;
        private TextBox txtCardName;
        private Label labelCardNumber;
        private TextBox txtCardNumber;
        private Label labelExpiry;
        private TextBox txtExpiry;
        private Label labelCVV;
        private TextBox txtCVV;
    }
}
