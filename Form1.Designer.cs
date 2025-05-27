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


        private Label navLogo;
        private Button bookingsBtn;
        private Button logoutBtn;
        private Label filterLabel;
        private Panel searchPanel;
        private TextBox originTextBox;
        private TextBox destinationTextBox;
        private DateTimePicker departureDatePicker;
        private Button searchButton;

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            navbarPanel = new Panel();
            homeBtn = new Button();
            bookingsBtn = new Button();
            navLogo = new Label();
            logoutBtn = new Button();
            mainContentPanel = new Panel();
            flightCardsPanel = new FlowLayoutPanel();
            searchPanel = new Panel();
            originTextBox = new TextBox();
            destinationTextBox = new TextBox();
            departureDatePicker = new DateTimePicker();
            searchButton = new Button();
            filterPanel = new Panel();
            sortbox = new GroupBox();
            priceH = new RadioButton();
            priceL = new RadioButton();
            filterBox = new GroupBox();
            filterLabel = new Label();
            navbarPanel.SuspendLayout();
            mainContentPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            sortbox.SuspendLayout();
            SuspendLayout();
            // 
            // navbarPanel
            // 
            navbarPanel.BackColor = Color.WhiteSmoke;
            navbarPanel.Controls.Add(homeBtn);
            navbarPanel.Controls.Add(bookingsBtn);
            navbarPanel.Controls.Add(navLogo);
            navbarPanel.Controls.Add(logoutBtn);
            navbarPanel.Dock = DockStyle.Top;
            navbarPanel.Location = new Point(0, 0);
            navbarPanel.Name = "navbarPanel";
            navbarPanel.Padding = new Padding(1);
            navbarPanel.Size = new Size(1000, 60);
            navbarPanel.TabIndex = 1;
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.White;
            homeBtn.Dock = DockStyle.Right;
            homeBtn.FlatAppearance.BorderColor = Color.Linen;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            homeBtn.Location = new Point(699, 1);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(100, 58);
            homeBtn.TabIndex = 4;
            homeBtn.Text = "Home";
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += homeBtn_Click;
            // 
            // bookingsBtn
            // 
            bookingsBtn.BackColor = Color.White;
            bookingsBtn.Dock = DockStyle.Right;
            bookingsBtn.FlatAppearance.BorderColor = Color.Linen;
            bookingsBtn.FlatAppearance.BorderSize = 0;
            bookingsBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bookingsBtn.Location = new Point(799, 1);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Size = new Size(100, 58);
            bookingsBtn.TabIndex = 0;
            bookingsBtn.Text = "Bookings";
            bookingsBtn.UseVisualStyleBackColor = false;
            bookingsBtn.Click += bookingsBtn_Click;
            // 
            // navLogo
            // 
            navLogo.Dock = DockStyle.Left;
            navLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            navLogo.Location = new Point(1, 1);
            navLogo.Name = "navLogo";
            navLogo.Size = new Size(168, 58);
            navLogo.TabIndex = 2;
            navLogo.Text = "✈ FlightBooker";
            navLogo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.White;
            logoutBtn.Dock = DockStyle.Right;
            logoutBtn.FlatAppearance.BorderColor = Color.Linen;
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            logoutBtn.Location = new Point(899, 1);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(100, 58);
            logoutBtn.TabIndex = 3;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
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
            flightCardsPanel.BackColor = Color.WhiteSmoke;
            flightCardsPanel.Dock = DockStyle.Fill;
            flightCardsPanel.Location = new Point(200, 50);
            flightCardsPanel.Name = "flightCardsPanel";
            flightCardsPanel.Padding = new Padding(20, 70, 10, 10);
            flightCardsPanel.Size = new Size(800, 490);
            flightCardsPanel.TabIndex = 0;
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.LightSteelBlue;
            searchPanel.Controls.Add(originTextBox);
            searchPanel.Controls.Add(destinationTextBox);
            searchPanel.Controls.Add(departureDatePicker);
            searchPanel.Controls.Add(searchButton);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(200, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(10);
            searchPanel.Size = new Size(800, 50);
            searchPanel.TabIndex = 2;
            // 
            // originTextBox
            // 
            originTextBox.Location = new Point(15, 12);
            originTextBox.Margin = new Padding(5);
            originTextBox.Name = "originTextBox";
            originTextBox.PlaceholderText = "From";
            originTextBox.Size = new Size(149, 23);
            originTextBox.TabIndex = 0;
            // 
            // destinationTextBox
            // 
            destinationTextBox.Location = new Point(183, 12);
            destinationTextBox.Margin = new Padding(5);
            destinationTextBox.Name = "destinationTextBox";
            destinationTextBox.PlaceholderText = "To";
            destinationTextBox.Size = new Size(160, 23);
            destinationTextBox.TabIndex = 1;
            // 
            // departureDatePicker
            // 
            departureDatePicker.Format = DateTimePickerFormat.Short;
            departureDatePicker.Location = new Point(366, 12);
            departureDatePicker.Margin = new Padding(5);
            departureDatePicker.Name = "departureDatePicker";
            departureDatePicker.Size = new Size(150, 23);
            departureDatePicker.TabIndex = 2;
            // 
            // searchButton
            // 
            searchButton.BackColor = SystemColors.ControlLightLight;
            searchButton.Dock = DockStyle.Right;
            searchButton.FlatStyle = FlatStyle.Popup;
            searchButton.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchButton.ForeColor = Color.Black;
            searchButton.Location = new Point(690, 10);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(100, 30);
            searchButton.TabIndex = 3;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.LightSteelBlue;
            filterPanel.Controls.Add(sortbox);
            filterPanel.Controls.Add(filterBox);
            filterPanel.Controls.Add(filterLabel);
            filterPanel.Dock = DockStyle.Left;
            filterPanel.Location = new Point(0, 0);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(200, 540);
            filterPanel.TabIndex = 1;
            // 
            // sortbox
            // 
            sortbox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            sortbox.Controls.Add(priceH);
            sortbox.Controls.Add(priceL);
            sortbox.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            sortbox.Location = new Point(19, 147);
            sortbox.Name = "sortbox";
            sortbox.Size = new Size(150, 200);
            sortbox.TabIndex = 2;
            sortbox.TabStop = false;
            sortbox.Text = "Sort";
            // 
            // priceH
            // 
            priceH.AutoSize = true;
            priceH.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceH.Location = new Point(6, 57);
            priceH.Name = "priceH";
            priceH.Size = new Size(126, 19);
            priceH.TabIndex = 1;
            priceH.TabStop = true;
            priceH.Text = "Price Highest First";
            priceH.UseVisualStyleBackColor = true;
            // 
            // priceL
            // 
            priceL.AutoSize = true;
            priceL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceL.Location = new Point(6, 32);
            priceL.Name = "priceL";
            priceL.Size = new Size(123, 19);
            priceL.TabIndex = 0;
            priceL.TabStop = true;
            priceL.Text = "Price Lowest First";
            priceL.UseVisualStyleBackColor = true;
            // 
            // filterBox
            // 
            filterBox.AutoSize = true;
            filterBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            filterBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            filterBox.Location = new Point(19, 24);
            filterBox.MinimumSize = new Size(150, 70);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(150, 70);
            filterBox.TabIndex = 1;
            filterBox.TabStop = false;
            filterBox.Text = "Filter";
            // 
            // filterLabel
            // 
            filterLabel.Dock = DockStyle.Top;
            filterLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            filterLabel.Location = new Point(0, 0);
            filterLabel.Name = "filterLabel";
            filterLabel.Padding = new Padding(10);
            filterLabel.Size = new Size(200, 23);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "Filters";
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
            mainContentPanel.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            sortbox.ResumeLayout(false);
            sortbox.PerformLayout();
            ResumeLayout(false);
        }

        private Button homeBtn;
        private GroupBox filterBox;
        private GroupBox sortbox;
        private RadioButton priceH;
        private RadioButton priceL;
    }
}
