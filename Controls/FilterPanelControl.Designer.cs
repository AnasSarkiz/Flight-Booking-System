namespace FlightBookingSystem.Controls
{
    partial class FilterPanelControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.GroupBox airlinesGroupBox;
        private System.Windows.Forms.CheckBox airlineCheckBox1;
        private System.Windows.Forms.CheckBox airlineCheckBox2;
        private System.Windows.Forms.CheckBox airlineCheckBox3;
        private System.Windows.Forms.GroupBox priceGroupBox;
        private System.Windows.Forms.TrackBar priceTrackBar;
        private System.Windows.Forms.Label minPriceLabel;
        private System.Windows.Forms.Label maxPriceLabel;
        private System.Windows.Forms.GroupBox stopsGroupBox;
        private System.Windows.Forms.RadioButton nonStopRadio;
        private System.Windows.Forms.RadioButton oneStopRadio;
        private System.Windows.Forms.RadioButton anyStopsRadio;
        private System.Windows.Forms.Button applyFiltersButton;

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
            filterLabel = new Label();
            airlinesGroupBox = new GroupBox();
            airlineCheckBox3 = new CheckBox();
            airlineCheckBox2 = new CheckBox();
            airlineCheckBox1 = new CheckBox();
            priceGroupBox = new GroupBox();
            maxPriceLabel = new Label();
            minPriceLabel = new Label();
            priceTrackBar = new TrackBar();
            stopsGroupBox = new GroupBox();
            anyStopsRadio = new RadioButton();
            oneStopRadio = new RadioButton();
            nonStopRadio = new RadioButton();
            applyFiltersButton = new Button();
            airlinesGroupBox.SuspendLayout();
            priceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priceTrackBar).BeginInit();
            stopsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Dock = DockStyle.Top;
            filterLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            filterLabel.ForeColor = Color.FromArgb(0, 100, 200);
            filterLabel.Location = new Point(0, 0);
            filterLabel.Name = "filterLabel";
            filterLabel.Padding = new Padding(20, 20, 0, 10);
            filterLabel.Size = new Size(101, 55);
            filterLabel.TabIndex = 0;
            filterLabel.Text = "FILTERS";
            // 
            // airlinesGroupBox
            // 
            airlinesGroupBox.Controls.Add(airlineCheckBox3);
            airlinesGroupBox.Controls.Add(airlineCheckBox2);
            airlinesGroupBox.Controls.Add(airlineCheckBox1);
            airlinesGroupBox.Dock = DockStyle.Top;
            airlinesGroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            airlinesGroupBox.ForeColor = Color.FromArgb(8, 18, 44);
            airlinesGroupBox.Location = new Point(0, 55);
            airlinesGroupBox.Name = "airlinesGroupBox";
            airlinesGroupBox.Padding = new Padding(20, 10, 20, 10);
            airlinesGroupBox.Size = new Size(250, 150);
            airlinesGroupBox.TabIndex = 1;
            airlinesGroupBox.TabStop = false;
            airlinesGroupBox.Text = "Airlines";
            // 
            // airlineCheckBox3
            // 
            airlineCheckBox3.AutoSize = true;
            airlineCheckBox3.Font = new Font("Segoe UI", 9F);
            airlineCheckBox3.Location = new Point(20, 100);
            airlineCheckBox3.Name = "airlineCheckBox3";
            airlineCheckBox3.Size = new Size(87, 19);
            airlineCheckBox3.TabIndex = 2;
            airlineCheckBox3.Text = "Oceanic Air";
            airlineCheckBox3.UseVisualStyleBackColor = true;
            // 
            // airlineCheckBox2
            // 
            airlineCheckBox2.AutoSize = true;
            airlineCheckBox2.Font = new Font("Segoe UI", 9F);
            airlineCheckBox2.Location = new Point(20, 70);
            airlineCheckBox2.Name = "airlineCheckBox2";
            airlineCheckBox2.Size = new Size(104, 19);
            airlineCheckBox2.TabIndex = 1;
            airlineCheckBox2.Text = "Global Airways";
            airlineCheckBox2.UseVisualStyleBackColor = true;
            // 
            // airlineCheckBox1
            // 
            airlineCheckBox1.AutoSize = true;
            airlineCheckBox1.Font = new Font("Segoe UI", 9F);
            airlineCheckBox1.Location = new Point(20, 40);
            airlineCheckBox1.Name = "airlineCheckBox1";
            airlineCheckBox1.Size = new Size(119, 19);
            airlineCheckBox1.TabIndex = 0;
            airlineCheckBox1.Text = "SkyWings Airlines";
            airlineCheckBox1.UseVisualStyleBackColor = true;
            // 
            // priceGroupBox
            // 
            priceGroupBox.Controls.Add(maxPriceLabel);
            priceGroupBox.Controls.Add(minPriceLabel);
            priceGroupBox.Controls.Add(priceTrackBar);
            priceGroupBox.Dock = DockStyle.Top;
            priceGroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            priceGroupBox.ForeColor = Color.FromArgb(8, 18, 44);
            priceGroupBox.Location = new Point(0, 205);
            priceGroupBox.Name = "priceGroupBox";
            priceGroupBox.Padding = new Padding(20, 10, 20, 10);
            priceGroupBox.Size = new Size(250, 150);
            priceGroupBox.TabIndex = 2;
            priceGroupBox.TabStop = false;
            priceGroupBox.Text = "Price Range";
            // 
            // maxPriceLabel
            // 
            maxPriceLabel.AutoSize = true;
            maxPriceLabel.Font = new Font("Segoe UI", 8F);
            maxPriceLabel.Location = new Point(190, 90);
            maxPriceLabel.Name = "maxPriceLabel";
            maxPriceLabel.Size = new Size(37, 13);
            maxPriceLabel.TabIndex = 2;
            maxPriceLabel.Text = "$1000";
            // 
            // minPriceLabel
            // 
            minPriceLabel.AutoSize = true;
            minPriceLabel.Font = new Font("Segoe UI", 8F);
            minPriceLabel.Location = new Point(20, 90);
            minPriceLabel.Name = "minPriceLabel";
            minPriceLabel.Size = new Size(31, 13);
            minPriceLabel.TabIndex = 1;
            minPriceLabel.Text = "$100";
            // 
            // priceTrackBar
            // 
            priceTrackBar.Location = new Point(20, 40);
            priceTrackBar.Maximum = 1000;
            priceTrackBar.Minimum = 100;
            priceTrackBar.Name = "priceTrackBar";
            priceTrackBar.Size = new Size(210, 45);
            priceTrackBar.TabIndex = 0;
            priceTrackBar.TickFrequency = 100;
            priceTrackBar.Value = 500;
            priceTrackBar.TickStyle = TickStyle.None;
            priceTrackBar.BackColor = Color.FromArgb(230, 240, 255);
            // 
            // stopsGroupBox
            // 
            stopsGroupBox.Controls.Add(anyStopsRadio);
            stopsGroupBox.Controls.Add(oneStopRadio);
            stopsGroupBox.Controls.Add(nonStopRadio);
            stopsGroupBox.Dock = DockStyle.Top;
            stopsGroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            stopsGroupBox.ForeColor = Color.FromArgb(8, 18, 44);
            stopsGroupBox.Location = new Point(0, 355);
            stopsGroupBox.Name = "stopsGroupBox";
            stopsGroupBox.Padding = new Padding(20, 10, 20, 10);
            stopsGroupBox.Size = new Size(250, 150);
            stopsGroupBox.TabIndex = 3;
            stopsGroupBox.TabStop = false;
            stopsGroupBox.Text = "Stops";
            // 
            // anyStopsRadio
            // 
            anyStopsRadio.AutoSize = true;
            anyStopsRadio.Font = new Font("Segoe UI", 9F);
            anyStopsRadio.Location = new Point(20, 100);
            anyStopsRadio.Name = "anyStopsRadio";
            anyStopsRadio.Size = new Size(77, 19);
            anyStopsRadio.TabIndex = 2;
            anyStopsRadio.Text = "Any stops";
            anyStopsRadio.UseVisualStyleBackColor = true;
            // 
            // oneStopRadio
            // 
            oneStopRadio.AutoSize = true;
            oneStopRadio.Font = new Font("Segoe UI", 9F);
            oneStopRadio.Location = new Point(20, 70);
            oneStopRadio.Name = "oneStopRadio";
            oneStopRadio.Size = new Size(58, 19);
            oneStopRadio.TabIndex = 1;
            oneStopRadio.Text = "1 Stop";
            oneStopRadio.UseVisualStyleBackColor = true;
            // 
            // nonStopRadio
            // 
            nonStopRadio.AutoSize = true;
            nonStopRadio.Checked = true;
            nonStopRadio.Font = new Font("Segoe UI", 9F);
            nonStopRadio.Location = new Point(20, 40);
            nonStopRadio.Name = "nonStopRadio";
            nonStopRadio.Size = new Size(76, 19);
            nonStopRadio.TabIndex = 0;
            nonStopRadio.TabStop = true;
            nonStopRadio.Text = "Non-stop";
            nonStopRadio.UseVisualStyleBackColor = true;
            // 
            // applyFiltersButton
            // 
            applyFiltersButton.BackColor = Color.FromArgb(0, 168, 255);
            applyFiltersButton.Dock = DockStyle.Bottom;
            applyFiltersButton.FlatAppearance.BorderSize = 0;
            applyFiltersButton.FlatStyle = FlatStyle.Flat;
            applyFiltersButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            applyFiltersButton.ForeColor = Color.White;
            applyFiltersButton.Location = new Point(0, 690);
            applyFiltersButton.Name = "applyFiltersButton";
            applyFiltersButton.Size = new Size(250, 30);
            applyFiltersButton.TabIndex = 4;
            applyFiltersButton.Text = "APPLY FILTERS";
            applyFiltersButton.UseVisualStyleBackColor = false;
            applyFiltersButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 140, 220);
            applyFiltersButton.Cursor = Cursors.Hand;
            // GroupBox styling
            var groupBoxes = new[] { airlinesGroupBox, priceGroupBox, stopsGroupBox };
            foreach (var gb in groupBoxes)
            {
                gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                gb.ForeColor = Color.FromArgb(0, 100, 200);
            }
            // 
            // FilterPanelControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(applyFiltersButton);
            Controls.Add(stopsGroupBox);
            Controls.Add(priceGroupBox);
            Controls.Add(airlinesGroupBox);
            Controls.Add(filterLabel);
            Name = "FilterPanelControl";
            Size = new Size(250, 720);
            airlinesGroupBox.ResumeLayout(false);
            airlinesGroupBox.PerformLayout();
            priceGroupBox.ResumeLayout(false);
            priceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)priceTrackBar).EndInit();
            stopsGroupBox.ResumeLayout(false);
            stopsGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}