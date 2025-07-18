namespace FlightBookingSystem.Controls
{
    partial class AddEditUserForm
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

        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblBalance = new Label();
            txtBalance = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(27, 48);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(106, 45);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(27, 86);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(106, 83);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(27, 123);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(33, 15);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Administrator", "Customer" });
            cmbRole.Location = new Point(106, 120);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(243, 23);
            cmbRole.TabIndex = 5;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(27, 161);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(51, 15);
            lblBalance.TabIndex = 6;
            lblBalance.Text = "Balance:";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(106, 158);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(199, 23);
            txtBalance.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(165, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 28);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(299, 259);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 28);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddEditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 317);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtBalance);
            Controls.Add(lblBalance);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit User";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}