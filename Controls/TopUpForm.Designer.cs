namespace FlightBookingSystem.Controls
{
    partial class TopUpForm
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
            lblCurrentBalance = new Label();
            label1 = new Label();
            txtAmount = new TextBox();
            label2 = new Label();
            lblNewBalance = new Label();
            btnTopUp = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(41, 19);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(86, 17);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // lblCurrentBalance
            // 
            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Location = new Point(41, 56);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new Size(94, 15);
            lblCurrentBalance.TabIndex = 1;
            lblCurrentBalance.Text = "Current Balance:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 94);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 2;
            label1.Text = "Top Up Amount:";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(179, 91);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(203, 23);
            txtAmount.TabIndex = 3;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 131);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "New Balance:";
            // 
            // lblNewBalance
            // 
            lblNewBalance.AutoSize = true;
            lblNewBalance.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewBalance.Location = new Point(145, 131);
            lblNewBalance.Name = "lblNewBalance";
            lblNewBalance.Size = new Size(0, 15);
            lblNewBalance.TabIndex = 5;
            // 
            // btnTopUp
            // 
            btnTopUp.Location = new Point(157, 176);
            btnTopUp.Name = "btnTopUp";
            btnTopUp.Size = new Size(110, 28);
            btnTopUp.TabIndex = 6;
            btnTopUp.Text = "Top Up";
            btnTopUp.UseVisualStyleBackColor = true;
            btnTopUp.Click += btnTopUp_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(294, 176);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 28);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // TopUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 216);
            Controls.Add(btnCancel);
            Controls.Add(btnTopUp);
            Controls.Add(lblNewBalance);
            Controls.Add(label2);
            Controls.Add(txtAmount);
            Controls.Add(label1);
            Controls.Add(lblCurrentBalance);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TopUpForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Top Up User Balance";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNewBalance;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.Button btnCancel;
    }
}