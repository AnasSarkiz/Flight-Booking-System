namespace FlightBookingSystem.Controls
{
    partial class UserManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.Panel toolbar;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;

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
            usersGrid = new DataGridView();
            toolbar = new Panel();
            deleteButton = new Button();
            editButton = new Button();
            addButton = new Button();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersGrid).BeginInit();
            toolbar.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.BackColor = SystemColors.Control;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(8, 18, 44);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(800, 60);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "User Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(usersGrid);
            contentPanel.Controls.Add(toolbar);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(800, 540);
            contentPanel.TabIndex = 1;
            // 
            // usersGrid
            // 
            usersGrid.AllowUserToAddRows = false;
            usersGrid.AllowUserToDeleteRows = false;
            usersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGrid.BackgroundColor = Color.White;
            usersGrid.BorderStyle = BorderStyle.None;
            usersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGrid.Dock = DockStyle.Fill;
            usersGrid.Location = new Point(20, 70);
            usersGrid.Name = "usersGrid";
            usersGrid.ReadOnly = true;
            usersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGrid.Size = new Size(760, 450);
            usersGrid.TabIndex = 1;
            // 
            // toolbar
            // 
            toolbar.BackColor = Color.FromArgb(240, 245, 255);
            toolbar.Controls.Add(deleteButton);
            toolbar.Controls.Add(editButton);
            toolbar.Controls.Add(addButton);
            toolbar.Dock = DockStyle.Top;
            toolbar.Location = new Point(20, 20);
            toolbar.Name = "toolbar";
            toolbar.Size = new Size(760, 50);
            toolbar.TabIndex = 0;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.FromArgb(255, 80, 80);
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteButton.ForeColor = Color.White;
            deleteButton.Location = new Point(550, 14);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(100, 30);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // editButton
            // 
            editButton.BackColor = Color.FromArgb(0, 168, 255);
            editButton.FlatAppearance.BorderSize = 0;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editButton.ForeColor = Color.White;
            editButton.Location = new Point(343, 14);
            editButton.Name = "editButton";
            editButton.Size = new Size(100, 30);
            editButton.TabIndex = 1;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = false;
            editButton.Click += editButton_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(0, 168, 255);
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.ForeColor = Color.White;
            addButton.Location = new Point(138, 14);
            addButton.Name = "addButton";
            addButton.Size = new Size(100, 30);
            addButton.TabIndex = 0;
            addButton.Text = "Add User";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // UserManagementControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentPanel);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UserManagementControl";
            Size = new Size(800, 600);
            contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)usersGrid).EndInit();
            toolbar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}