namespace FlightBookingSystem.Controls
{
    partial class SearchBoxControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label originLabel;
        private System.Windows.Forms.TextBox originTextBox;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.DateTimePicker departureDatePicker;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cabinClassComboBox;
        private System.Windows.Forms.Label cabinClassLabel;
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
            originLabel = new Label();
            originTextBox = new TextBox();
            destinationLabel = new Label();
            destinationTextBox = new TextBox();
            departureLabel = new Label();
            departureDatePicker = new DateTimePicker();
            searchButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            cabinClassLabel = new Label();
            cabinClassComboBox = new ComboBox();
            SuspendLayout();
            // 
            // originLabel
            // 
            originLabel.AutoSize = true;
            originLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            originLabel.Location = new Point(20, 20);
            originLabel.Name = "originLabel";
            originLabel.Size = new Size(48, 15);
            originLabel.TabIndex = 0;
            originLabel.Text = "ORIGIN";
            // 
            // originTextBox
            // 
            originTextBox.BackColor = Color.White;
            originTextBox.BorderStyle = BorderStyle.None;
            originTextBox.Font = new Font("Segoe UI", 11F);
            originTextBox.Location = new Point(20, 40);
            originTextBox.Name = "originTextBox";
            originTextBox.PlaceholderText = "City or Airport";
            originTextBox.Size = new Size(396, 20);
            originTextBox.TabIndex = 1;
            // 
            // destinationLabel
            // 
            destinationLabel.AutoSize = true;
            destinationLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            destinationLabel.Location = new Point(484, 20);
            destinationLabel.Name = "destinationLabel";
            destinationLabel.Size = new Size(85, 15);
            destinationLabel.TabIndex = 2;
            destinationLabel.Text = "DESTINATION";
            // 
            // destinationTextBox
            // 
            destinationTextBox.BackColor = Color.White;
            destinationTextBox.BorderStyle = BorderStyle.None;
            destinationTextBox.Font = new Font("Segoe UI", 11F);
            destinationTextBox.Location = new Point(484, 40);
            destinationTextBox.Name = "destinationTextBox";
            destinationTextBox.PlaceholderText = "City or Airport";
            destinationTextBox.Size = new Size(369, 20);
            destinationTextBox.TabIndex = 3;
            // 
            // departureLabel
            // 
            departureLabel.AutoSize = true;
            departureLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            departureLabel.Location = new Point(20, 80);
            departureLabel.Name = "departureLabel";
            departureLabel.Size = new Size(103, 15);
            departureLabel.TabIndex = 4;
            departureLabel.Text = "DEPARTURE DATE";
            // 
            // departureDatePicker
            // 
            departureDatePicker.CalendarFont = new Font("Segoe UI", 12F);
            departureDatePicker.CustomFormat = "ddd, MMM dd, yyyy";
            departureDatePicker.Font = new Font("Segoe UI", 11F);
            departureDatePicker.Format = DateTimePickerFormat.Custom;
            departureDatePicker.Location = new Point(20, 100);
            departureDatePicker.MinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0);
            departureDatePicker.Name = "departureDatePicker";
            departureDatePicker.Size = new Size(396, 27);
            departureDatePicker.TabIndex = 5;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.FromArgb(0, 168, 255);
            searchButton.Cursor = Cursors.Hand;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 140, 220);
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            searchButton.ForeColor = Color.White;
            searchButton.Location = new Point(963, 64);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(200, 40);
            searchButton.TabIndex = 10;
            searchButton.Text = "SEARCH FLIGHTS";
            searchButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 168, 255);
            panel1.Location = new Point(20, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(396, 1);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 168, 255);
            panel2.Location = new Point(484, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(369, 1);
            panel2.TabIndex = 10;
            // 
            // cabinClassLabel
            // 
            cabinClassLabel.Location = new Point(484, 100);
            cabinClassLabel.Name = "cabinClassLabel";
            cabinClassLabel.Size = new Size(134, 23);
            cabinClassLabel.TabIndex = 0;
            cabinClassLabel.Text = "Cabin Class";
            // 
            // cabinClassComboBox
            // 
            cabinClassComboBox.Items.AddRange(new object[] { "ECONOMY", "PREMIUM_ECONOMY", "BUSINESS","FIRST" });
            cabinClassComboBox.Location = new Point(639, 100);
            cabinClassComboBox.Name = "cabinClassComboBox";
            cabinClassComboBox.Size = new Size(194, 23);
            cabinClassComboBox.TabIndex = 1;
            cabinClassComboBox.SelectedIndex = 0;
            // 
            // SearchBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(cabinClassLabel);
            Controls.Add(cabinClassComboBox);
            Controls.Add(searchButton);
            Controls.Add(departureDatePicker);
            Controls.Add(departureLabel);
            Controls.Add(panel2);
            Controls.Add(destinationTextBox);
            Controls.Add(destinationLabel);
            Controls.Add(panel1);
            Controls.Add(originTextBox);
            Controls.Add(originLabel);
            Font = new Font("Segoe UI", 9F);
            Name = "SearchBoxControl";
            Size = new Size(1214, 150);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}