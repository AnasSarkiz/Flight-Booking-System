namespace FlightBookingSystem.Controls
{
    partial class ActivityLogControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.DataGridView logGrid;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker datePicker;

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
            titleLabel = new Label();
            contentPanel = new Panel();
            logGrid = new DataGridView();
            filterPanel = new Panel();
            datePicker = new DateTimePicker();
            dateLabel = new Label();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logGrid).BeginInit();
            filterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(8, 18, 44);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(800, 60);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Activity Log";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(logGrid);
            contentPanel.Controls.Add(filterPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(800, 540);
            contentPanel.TabIndex = 1;
            // 
            // logGrid
            // 
            logGrid.AllowUserToAddRows = false;
            logGrid.AllowUserToDeleteRows = false;
            logGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            logGrid.BackgroundColor = Color.White;
            logGrid.BorderStyle = BorderStyle.None;
            logGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            logGrid.Dock = DockStyle.Fill;
            logGrid.Location = new Point(20, 70);
            logGrid.Name = "logGrid";
            logGrid.ReadOnly = true;
            logGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            logGrid.Size = new Size(760, 450);
            logGrid.TabIndex = 1;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.FromArgb(240, 245, 255);
            filterPanel.Controls.Add(datePicker);
            filterPanel.Controls.Add(dateLabel);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(20, 20);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(760, 50);
            filterPanel.TabIndex = 0;
            // 
            // datePicker
            // 
            datePicker.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datePicker.Location = new Point(170, 9);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(418, 25);
            datePicker.TabIndex = 1;
            datePicker.ValueChanged += datePicker_ValueChanged;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateLabel.Location = new Point(20, 15);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(94, 19);
            dateLabel.TabIndex = 0;
            dateLabel.Text = "Filter by Date:";
            // 
            // ActivityLogControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentPanel);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ActivityLogControl";
            Size = new Size(800, 600);
            contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logGrid).EndInit();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}