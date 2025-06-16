using System.Drawing;
using System.Windows.Forms;

namespace FlightBooker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel navbarPanel;
        private Panel mainContentPanel;
        private Panel filterPanel;
        private FlowLayoutPanel flightCardsPanel;
        private Panel searchPanel;

        private Label navLogo;
        private Button homeBtn;
        private Button searchFlightsBtn;
    private Button bookingsBtn;
        private Button logoutBtn;

        private GroupBox filterBox;
        private GroupBox sortBox;
        private RadioButton priceL;
        private RadioButton durationRb;
        private Label filterLabel;

        private TextBox originTextBox;
        private TextBox destinationTextBox;
        private DateTimePicker departureDatePicker;
        private Button searchButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Panel navbarPanel;
            logoutBtn = new Button();
            bookingsBtn = new Button();
            searchFlightsBtn = new Button();
            homeBtn = new Button();
            navLogo = new Label();
            mainContentPanel = new Panel();
            flightCardsPanel = new FlowLayoutPanel();
            searchPanel = new Panel();
            numericUpDown1 = new NumericUpDown();
            noPassenger = new Label();
            label1 = new Label();
            flightDateLbl = new Label();
            originLbl = new Label();
            originTextBox = new TextBox();
            destinationTextBox = new TextBox();
            departureDatePicker = new DateTimePicker();
            searchButton = new Button();
            filterPanel = new Panel();
            sortBox = new GroupBox();
            priceL = new RadioButton();
            durationRb = new RadioButton();
            filterBox = new GroupBox();
            filterLabel = new Label();
            navbarPanel = new Panel();
            navbarPanel.SuspendLayout();
            mainContentPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            filterPanel.SuspendLayout();
            sortBox.SuspendLayout();
            SuspendLayout();
            // 
            // navbarPanel
            // 
            navbarPanel.BackColor = Color.White;
            navbarPanel.Controls.Add(logoutBtn);
            navbarPanel.Controls.Add(bookingsBtn);
            navbarPanel.Controls.Add(searchFlightsBtn);
            navbarPanel.Controls.Add(homeBtn);
            navbarPanel.Controls.Add(navLogo);
            navbarPanel.Dock = DockStyle.Top;
            navbarPanel.Location = new Point(0, 0);
            navbarPanel.Name = "navbarPanel";
            navbarPanel.Padding = new Padding(10, 0, 10, 0);
            navbarPanel.Size = new Size(1000, 60);
            navbarPanel.TabIndex = 1;
            // 
            // logoutBtn
            // 
            logoutBtn.AutoSize = true;
            logoutBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logoutBtn.Dock = DockStyle.Right;
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.FlatStyle = FlatStyle.Flat;
            logoutBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            logoutBtn.Location = new Point(650, 0);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(73, 60);
            logoutBtn.TabIndex = 0;
            logoutBtn.Text = "Logout";
            logoutBtn.Click += logoutBtn_Click;
            // 
            // bookingsBtn
            // 
            bookingsBtn.AutoSize = true;
            bookingsBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bookingsBtn.Dock = DockStyle.Right;
            bookingsBtn.FlatAppearance.BorderSize = 0;
            bookingsBtn.FlatStyle = FlatStyle.Flat;
            bookingsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            bookingsBtn.Location = new Point(723, 0);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Size = new Size(81, 60);
            bookingsBtn.TabIndex = 1;
            bookingsBtn.Text = "Booking";
            bookingsBtn.Click += bookingsBtn_Click;
            // 
            // searchFlightsBtn
            // 
            searchFlightsBtn.AutoSize = true;
            searchFlightsBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchFlightsBtn.Dock = DockStyle.Right;
            searchFlightsBtn.FlatAppearance.BorderSize = 0;
            searchFlightsBtn.FlatStyle = FlatStyle.Flat;
            searchFlightsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            searchFlightsBtn.Location = new Point(804, 0);
            searchFlightsBtn.Name = "searchFlightsBtn";
            searchFlightsBtn.Size = new Size(121, 60);
            searchFlightsBtn.TabIndex = 2;
            searchFlightsBtn.Text = "Search Flights";
            searchFlightsBtn.Click += searchButton_Click;
            // 
            // homeBtn
            // 
            homeBtn.AutoSize = true;
            homeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            homeBtn.Dock = DockStyle.Right;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatStyle = FlatStyle.Flat;
            homeBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            homeBtn.Location = new Point(925, 0);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(65, 60);
            homeBtn.TabIndex = 3;
            homeBtn.Text = "Home";
            homeBtn.Click += homeBtn_Click;
            // 
            // navLogo
            // 
            navLogo.AutoSize = true;
            navLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            navLogo.Location = new Point(10, 17);
            navLogo.Name = "navLogo";
            navLogo.Size = new Size(154, 25);
            navLogo.TabIndex = 4;
            navLogo.Text = "✈ FlightBooker";
            // 
            // mainContentPanel
            // 
            mainContentPanel.BackColor = Color.White;
            mainContentPanel.Controls.Add(flightCardsPanel);
            mainContentPanel.Controls.Add(searchPanel);
            mainContentPanel.Controls.Add(filterPanel);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 60);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1000, 540);
            mainContentPanel.TabIndex = 0;
            // 
            // flightCardsPanel
            // 
            flightCardsPanel.AutoScroll = true;
            flightCardsPanel.Dock = DockStyle.Fill;
            flightCardsPanel.Location = new Point(200, 150);
            flightCardsPanel.Name = "flightCardsPanel";
            flightCardsPanel.Padding = new Padding(40, 150, 10, 10);
            flightCardsPanel.Size = new Size(800, 390);
            flightCardsPanel.TabIndex = 0;
            // 
            // searchPanel
            // 
            searchPanel.BackColor = SystemColors.MenuBar;
            searchPanel.Controls.Add(numericUpDown1);
            searchPanel.Controls.Add(noPassenger);
            searchPanel.Controls.Add(label1);
            searchPanel.Controls.Add(flightDateLbl);
            searchPanel.Controls.Add(originLbl);
            searchPanel.Controls.Add(originTextBox);
            searchPanel.Controls.Add(destinationTextBox);
            searchPanel.Controls.Add(departureDatePicker);
            searchPanel.Controls.Add(searchButton);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(200, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(20);
            searchPanel.Size = new Size(800, 150);
            searchPanel.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown1.Location = new Point(487, 62);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(250, 23);
            numericUpDown1.TabIndex = 9;
            // 
            // noPassenger
            // 
            noPassenger.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            noPassenger.AutoSize = true;
            noPassenger.Location = new Point(399, 70);
            noPassenger.Name = "noPassenger";
            noPassenger.Size = new Size(82, 15);
            noPassenger.TabIndex = 8;
            noPassenger.Text = "No Passenger:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(411, 30);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 7;
            label1.Text = "Destination:";
            // 
            // flightDateLbl
            // 
            flightDateLbl.AutoSize = true;
            flightDateLbl.Location = new Point(38, 70);
            flightDateLbl.Name = "flightDateLbl";
            flightDateLbl.Size = new Size(34, 15);
            flightDateLbl.TabIndex = 6;
            flightDateLbl.Text = "Date:";
            // 
            // originLbl
            // 
            originLbl.AutoSize = true;
            originLbl.Location = new Point(38, 27);
            originLbl.Name = "originLbl";
            originLbl.Size = new Size(43, 15);
            originLbl.TabIndex = 5;
            originLbl.Text = "Origin:";
            // 
            // originTextBox
            // 
            originTextBox.Font = new Font("Segoe UI", 10F);
            originTextBox.Location = new Point(119, 22);
            originTextBox.Name = "originTextBox";
            originTextBox.PlaceholderText = "Origin";
            originTextBox.Size = new Size(250, 25);
            originTextBox.TabIndex = 0;
            // 
            // destinationTextBox
            // 
            destinationTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            destinationTextBox.Font = new Font("Segoe UI", 10F);
            destinationTextBox.Location = new Point(487, 23);
            destinationTextBox.Name = "destinationTextBox";
            destinationTextBox.PlaceholderText = "Destination";
            destinationTextBox.Size = new Size(250, 25);
            destinationTextBox.TabIndex = 1;
            // 
            // departureDatePicker
            // 
            departureDatePicker.CustomFormat = "yyyy-MM-dd";
            departureDatePicker.Font = new Font("Segoe UI", 10F);
            departureDatePicker.Format = DateTimePickerFormat.Custom;
            departureDatePicker.Location = new Point(119, 62);
            departureDatePicker.Name = "departureDatePicker";
            departureDatePicker.Size = new Size(250, 25);
            departureDatePicker.TabIndex = 2;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Bottom;
            searchButton.BackColor = Color.LightSteelBlue;
            searchButton.FlatStyle = FlatStyle.Popup;
            searchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            searchButton.Location = new Point(38, 103);
            searchButton.Margin = new Padding(0);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(724, 42);
            searchButton.TabIndex = 4;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.LightSteelBlue;
            filterPanel.Controls.Add(sortBox);
            filterPanel.Controls.Add(filterBox);
            filterPanel.Controls.Add(filterLabel);
            filterPanel.Dock = DockStyle.Left;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(200, 540);
            filterPanel.TabIndex = 2;
            // 
            // sortBox
            // 
            sortBox.AutoSize = true;
            sortBox.Controls.Add(priceL);
            sortBox.Controls.Add(durationRb);
            sortBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            sortBox.Location = new Point(10, 170);
            sortBox.Name = "sortBox";
            sortBox.Size = new Size(180, 111);
            sortBox.TabIndex = 0;
            sortBox.TabStop = false;
            sortBox.Text = "Sort by";
            // 
            // priceL
            // 
            priceL.AutoSize = true;
            priceL.Font = new Font("Segoe UI", 10F);
            priceL.Location = new Point(10, 30);
            priceL.Name = "priceL";
            priceL.Size = new Size(56, 23);
            priceL.TabIndex = 0;
            priceL.Text = "Price";
            // 
            // durationRb
            // 
            durationRb.AutoSize = true;
            durationRb.Font = new Font("Segoe UI", 10F);
            durationRb.Location = new Point(10, 60);
            durationRb.Name = "durationRb";
            durationRb.Size = new Size(81, 23);
            durationRb.TabIndex = 1;
            durationRb.Text = "Duration";
            // 
            // filterBox
            // 
            filterBox.AutoSize = true;
            filterBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            filterBox.Location = new Point(10, 50);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(180, 100);
            filterBox.TabIndex = 1;
            filterBox.TabStop = false;
            filterBox.Text = "Airlines";
            // 
            // filterLabel
            // 
            filterLabel.Dock = DockStyle.Top;
            filterLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            filterLabel.Location = new Point(0, 0);
            filterLabel.Name = "filterLabel";
            filterLabel.Padding = new Padding(10, 10, 0, 10);
            filterLabel.Size = new Size(200, 23);
            filterLabel.TabIndex = 2;
            filterLabel.Text = "Filter & Sort";
            // 
            // Form1
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(mainContentPanel);
            Controls.Add(navbarPanel);
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            Text = "FlightBooker";
            navbarPanel.ResumeLayout(false);
            navbarPanel.PerformLayout();
            mainContentPanel.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            sortBox.ResumeLayout(false);
            sortBox.PerformLayout();
            ResumeLayout(false);
        }

        private Label flightDateLbl;
        private Label originLbl;
        private Label noPassenger;
        private Label label1;
        private NumericUpDown numericUpDown1;
    }
}