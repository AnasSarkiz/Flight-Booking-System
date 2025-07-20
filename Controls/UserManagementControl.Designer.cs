namespace FlightBookingSystem.Controls
{
    partial class UserManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            usersGrid = new DataGridView();
            panel1 = new Panel();
            lblBalance = new Label();
            lblMemberSince = new Label();
            lblUsername = new Label();
            lblName = new Label();
            panel2 = new Panel();
            refreshButton = new Button();
            roleChangeButton = new Button();
            topUpButton = new Button();
            lockUnlockButton = new Button();
            deleteButton = new Button();
            editButton = new Button();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)usersGrid).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // usersGrid
            // 
            usersGrid.AllowUserToAddRows = false;
            usersGrid.AllowUserToDeleteRows = false;
            usersGrid.BackgroundColor = Color.AliceBlue;
            usersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGrid.Dock = DockStyle.Fill;
            usersGrid.Location = new Point(0, 173);
            usersGrid.Margin = new Padding(4, 3, 4, 3);
            usersGrid.Name = "usersGrid";
            usersGrid.ReadOnly = true;
            usersGrid.RowHeadersVisible = false;
            usersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGrid.Size = new Size(933, 519);
            usersGrid.TabIndex = 0;
            usersGrid.CellDoubleClick += usersGrid_CellDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBalance);
            panel1.Controls.Add(lblMemberSince);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(lblName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(933, 115);
            panel1.TabIndex = 1;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalance.ForeColor = Color.Green;
            lblBalance.Location = new Point(350, 12);
            lblBalance.Margin = new Padding(4, 0, 4, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(52, 17);
            lblBalance.TabIndex = 3;
            lblBalance.Text = "label4";
            // 
            // lblMemberSince
            // 
            lblMemberSince.AutoSize = true;
            lblMemberSince.Location = new Point(12, 69);
            lblMemberSince.Margin = new Padding(4, 0, 4, 0);
            lblMemberSince.Name = "lblMemberSince";
            lblMemberSince.Size = new Size(38, 15);
            lblMemberSince.TabIndex = 2;
            lblMemberSince.Text = "label3";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 40);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(38, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "label2";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(12, 12);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 20);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // panel2
            // 
            panel2.Controls.Add(refreshButton);
            panel2.Controls.Add(roleChangeButton);
            panel2.Controls.Add(topUpButton);
            panel2.Controls.Add(lockUnlockButton);
            panel2.Controls.Add(deleteButton);
            panel2.Controls.Add(editButton);
            panel2.Controls.Add(addButton);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 115);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(933, 58);
            panel2.TabIndex = 2;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(688, 12);
            refreshButton.Margin = new Padding(4, 3, 4, 3);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(93, 35);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // roleChangeButton
            // 
            roleChangeButton.Location = new Point(560, 12);
            roleChangeButton.Margin = new Padding(4, 3, 4, 3);
            roleChangeButton.Name = "roleChangeButton";
            roleChangeButton.Size = new Size(117, 35);
            roleChangeButton.TabIndex = 5;
            roleChangeButton.Text = "Change Role";
            roleChangeButton.UseVisualStyleBackColor = true;
            roleChangeButton.Click += roleChangeButton_Click;
            // 
            // topUpButton
            // 
            topUpButton.Location = new Point(455, 12);
            topUpButton.Margin = new Padding(4, 3, 4, 3);
            topUpButton.Name = "topUpButton";
            topUpButton.Size = new Size(93, 35);
            topUpButton.TabIndex = 4;
            topUpButton.Text = "Top Up";
            topUpButton.UseVisualStyleBackColor = true;
            topUpButton.Click += topUpButton_Click;
            // 
            // lockUnlockButton
            // 
            lockUnlockButton.Location = new Point(327, 12);
            lockUnlockButton.Margin = new Padding(4, 3, 4, 3);
            lockUnlockButton.Name = "lockUnlockButton";
            lockUnlockButton.Size = new Size(117, 35);
            lockUnlockButton.TabIndex = 3;
            lockUnlockButton.Text = "Lock/Unlock";
            lockUnlockButton.UseVisualStyleBackColor = true;
            lockUnlockButton.Click += lockUnlockButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(222, 12);
            deleteButton.Margin = new Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(93, 35);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(117, 12);
            editButton.Margin = new Padding(4, 3, 4, 3);
            editButton.Name = "editButton";
            editButton.Size = new Size(93, 35);
            editButton.TabIndex = 1;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 12);
            addButton.Margin = new Padding(4, 3, 4, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(93, 35);
            addButton.TabIndex = 0;
            addButton.Text = "Add User";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // UserManagementControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(usersGrid);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserManagementControl";
            Size = new Size(933, 692);
            ((System.ComponentModel.ISupportInitialize)usersGrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblMemberSince;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button roleChangeButton;
        private System.Windows.Forms.Button topUpButton;
        private System.Windows.Forms.Button lockUnlockButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
    }
}