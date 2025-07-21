namespace FlightBookingSystem.Controls
{
    partial class MessagesControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView messagesListView;
        private System.Windows.Forms.ColumnHeader idColumn;
        private System.Windows.Forms.ColumnHeader usernameColumn;
        private System.Windows.Forms.ColumnHeader messageColumn;
        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;

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
            messagesListView = new ListView();
            idColumn = new ColumnHeader();
            usernameColumn = new ColumnHeader();
            messageColumn = new ColumnHeader();
            dateColumn = new ColumnHeader();
            titleLabel = new Label();
            refreshButton = new Button();
            loadingLabel = new Label();
            statusLabel = new Label();
            SuspendLayout();

            // messagesListView
            messagesListView.Columns.AddRange(new ColumnHeader[] { idColumn, usernameColumn, messageColumn, dateColumn });
            messagesListView.Dock = DockStyle.Fill;
            messagesListView.FullRowSelect = true;
            messagesListView.GridLines = true;
            messagesListView.Location = new Point(0, 60);
            messagesListView.Name = "messagesListView";
            messagesListView.Size = new Size(800, 504);
            messagesListView.TabIndex = 0;
            messagesListView.UseCompatibleStateImageBehavior = false;
            messagesListView.View = View.Details;
             // flowLayoutPanel
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.Location = new Point(0, 60);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(800, 504);
            flowLayoutPanel.TabIndex = 4;
            // Columns
            idColumn.Text = "ID";
            idColumn.Width = 50;
            usernameColumn.Text = "Username";
            usernameColumn.Width = 120;
            messageColumn.Text = "Message";
            messageColumn.Width = 400;
            dateColumn.Text = "Date Sent";
            dateColumn.Width = 150;

            // titleLabel
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(0, 168, 255);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(800, 60);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Messages";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;

            // refreshButton
            refreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshButton.BackColor = Color.FromArgb(0, 168, 255);
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            refreshButton.ForeColor = Color.White;
            refreshButton.Location = new Point(700, 10);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(80, 30);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;

            // loadingLabel
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font("Segoe UI", 12F);
            loadingLabel.Location = new Point(350, 300);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(75, 21);
            loadingLabel.TabIndex = 3;
            loadingLabel.Text = "Loading...";
            loadingLabel.Visible = false;

            // statusLabel
            statusLabel.Dock = DockStyle.Bottom;
            statusLabel.ForeColor = Color.FromArgb(5, 15, 40); 
            statusLabel.Location = new Point(0, 580);
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(0, 0, 10, 0);
            statusLabel.Size = new Size(800, 20);
            statusLabel.TabIndex = 0;
            statusLabel.TextAlign = ContentAlignment.MiddleRight;

            // MessagesControl
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusLabel);
            Controls.Add(loadingLabel);
            Controls.Add(refreshButton);
            Controls.Add(messagesListView);
            Controls.Add(titleLabel);
            Controls.Add(flowLayoutPanel);
            Controls.SetChildIndex(flowLayoutPanel, 0);

            // Adjust loading label
            loadingLabel.Anchor = AnchorStyles.None;
            loadingLabel.BringToFront();
            Name = "MessagesControl";
            Size = new Size(800, 600);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}