namespace FlightBookingSystem.Controls
{
    partial class UserManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button topUpButton;
        private System.Windows.Forms.Button lockUnlockButton;
        private System.Windows.Forms.Button roleChangeButton;
        private System.Windows.Forms.Button refreshButton;

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
            this.usersGrid = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.topUpButton = new System.Windows.Forms.Button();
            this.lockUnlockButton = new System.Windows.Forms.Button();
            this.roleChangeButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // usersGrid
            // 
            this.usersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGrid.Location = new System.Drawing.Point(18, 19);
            this.usersGrid.Name = "usersGrid";
            this.usersGrid.RowHeadersWidth = 51;
            this.usersGrid.RowTemplate.Height = 24;
            this.usersGrid.Size = new System.Drawing.Size(836, 375);
            this.usersGrid.TabIndex = 0;
            this.usersGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersGrid_CellDoubleClick);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(18, 412);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(88, 38);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.Location = new System.Drawing.Point(126, 412);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(88, 38);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(232, 412);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(88, 38);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // topUpButton
            // 
            this.topUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.topUpButton.Location = new System.Drawing.Point(336, 412);
            this.topUpButton.Name = "topUpButton";
            this.topUpButton.Size = new System.Drawing.Size(105, 38);
            this.topUpButton.TabIndex = 4;
            this.topUpButton.Text = "Top Up Balance";
            this.topUpButton.UseVisualStyleBackColor = true;
            this.topUpButton.Click += new System.EventHandler(this.topUpButton_Click);
            // 
            // lockUnlockButton
            // 
            this.lockUnlockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lockUnlockButton.Location = new System.Drawing.Point(461, 412);
            this.lockUnlockButton.Name = "lockUnlockButton";
            this.lockUnlockButton.Size = new System.Drawing.Size(105, 38);
            this.lockUnlockButton.TabIndex = 5;
            this.lockUnlockButton.Text = "Lock/Unlock";
            this.lockUnlockButton.UseVisualStyleBackColor = true;
            this.lockUnlockButton.Click += new System.EventHandler(this.lockUnlockButton_Click);
            // 
            // roleChangeButton
            // 
            this.roleChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.roleChangeButton.Location = new System.Drawing.Point(591, 412);
            this.roleChangeButton.Name = "roleChangeButton";
            this.roleChangeButton.Size = new System.Drawing.Size(105, 38);
            this.roleChangeButton.TabIndex = 6;
            this.roleChangeButton.Text = "Change Role";
            this.roleChangeButton.UseVisualStyleBackColor = true;
            this.roleChangeButton.Click += new System.EventHandler(this.roleChangeButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(766, 412);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(88, 38);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // UserManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.roleChangeButton);
            this.Controls.Add(this.lockUnlockButton);
            this.Controls.Add(this.topUpButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.usersGrid);
            this.Name = "UserManagementControl";
            this.Size = new System.Drawing.Size(871, 469);
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}