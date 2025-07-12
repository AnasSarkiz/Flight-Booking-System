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
        private System.Windows.Forms.Label returnLabel;
        private System.Windows.Forms.DateTimePicker returnDatePicker;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox returnCheckBox;

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
            returnLabel = new Label();
            returnDatePicker = new DateTimePicker();
            searchButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            returnCheckBox = new CheckBox();
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
            originTextBox.Size = new Size(396, 22);
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
            destinationTextBox.Size = new Size(369, 22);
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
            departureDatePicker.Size = new Size(396, 29);
            departureDatePicker.TabIndex = 5;
            // 
            // returnLabel
            // 
            returnLabel.AutoSize = true;
            returnLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            returnLabel.Location = new Point(484, 80);
            returnLabel.Name = "returnLabel";
            returnLabel.Size = new Size(83, 15);
            returnLabel.TabIndex = 6;
            returnLabel.Text = "RETURN DATE";
            // 
            // returnDatePicker
            // 
            returnDatePicker.CalendarFont = new Font("Segoe UI", 12F);
            returnDatePicker.CustomFormat = "ddd, MMM dd, yyyy";
            returnDatePicker.Font = new Font("Segoe UI", 11F);
            returnDatePicker.Format = DateTimePickerFormat.Custom;
            returnDatePicker.Location = new Point(484, 100);
            returnDatePicker.MinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0);
            returnDatePicker.Name = "returnDatePicker";
            returnDatePicker.Size = new Size(369, 29);
            returnDatePicker.TabIndex = 7;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.FromArgb(0, 168, 255);
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.ForeColor = Color.White;
            searchButton.Location = new Point(963, 64);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(200, 40);
            searchButton.TabIndex = 10;
            searchButton.Text = "SEARCH FLIGHTS";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 140, 220);
            searchButton.Cursor = Cursors.Hand;
            searchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // 
            // panel1
            // 
            panel1.Height = 2;
            panel1.BackColor = Color.FromArgb(0, 168, 255);
            panel1.Location = new Point(20, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(396, 1);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Height = 2;
            panel2.BackColor = Color.FromArgb(0, 168, 255);
            panel2.Location = new Point(484, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(369, 1);
            panel2.TabIndex = 10;
            // 
            // returnCheckBox
            // 
            returnCheckBox.AutoSize = true;
            returnCheckBox.Checked = true;
            returnCheckBox.CheckState = CheckState.Checked;
            returnCheckBox.ForeColor = Color.FromArgb(80, 80, 80);
            returnCheckBox.Font = new Font("Segoe UI", 9F);
            returnCheckBox.Location = new Point(574, 80);
            returnCheckBox.Name = "returnCheckBox";
            returnCheckBox.Size = new Size(82, 19);
            returnCheckBox.TabIndex = 11;
            returnCheckBox.Text = "Round trip";
            returnCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(returnCheckBox);
            Controls.Add(searchButton);
            Controls.Add(returnDatePicker);
            Controls.Add(returnLabel);
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