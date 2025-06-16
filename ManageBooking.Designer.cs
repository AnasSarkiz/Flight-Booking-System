namespace Flight_Booking_System
{
    partial class ManageBooking
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            fromToHeaderLbl = new Label();
            PNR = new Label();
            fightNoLbl = new Label();
            PNRHeaderLbl = new Label();
            fightNoHeaderLbl = new Label();
            dateLbl = new Label();
            dateHeaderLbl = new Label();
            nameLbl = new Label();
            nameHeaderlbl = new Label();
            mgBookingBtn = new Button();
            pictureBox1 = new PictureBox();
            headerLbl = new Label();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();

            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = Color.LightSteelBlue;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.ForeColor = SystemColors.ControlDark;
            flowLayoutPanel1.Location = new Point(14, 82);
            flowLayoutPanel1.Margin = new Padding(10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(974, 449);
            flowLayoutPanel1.TabIndex = 0;

            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(fromToHeaderLbl);
            panel1.Controls.Add(PNR);
            panel1.Controls.Add(fightNoLbl);
            panel1.Controls.Add(PNRHeaderLbl);
            panel1.Controls.Add(fightNoHeaderLbl);
            panel1.Controls.Add(dateLbl);
            panel1.Controls.Add(dateHeaderLbl);
            panel1.Controls.Add(nameLbl);
            panel1.Controls.Add(nameHeaderlbl);
            panel1.Controls.Add(mgBookingBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(10, 10);
            panel1.Margin = new Padding(10, 10, 3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(952, 113);
            panel1.TabIndex = 0;

            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(178, 81);
            label2.Name = "label2";
            label2.Size = new Size(156, 15);
            label2.TabIndex = 3;
            label2.Text = "Paris To San farnsisco";

            fromToHeaderLbl.AutoSize = true;
            fromToHeaderLbl.Location = new Point(178, 66);
            fromToHeaderLbl.Name = "fromToHeaderLbl";
            fromToHeaderLbl.Size = new Size(65, 15);
            fromToHeaderLbl.TabIndex = 2;
            fromToHeaderLbl.Text = "From-->To";

            PNR.AutoSize = true;
            PNR.BackColor = Color.Transparent;
            PNR.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            PNR.ForeColor = SystemColors.ActiveCaptionText;
            PNR.Location = new Point(594, 56);
            PNR.Name = "PNR";
            PNR.Size = new Size(60, 15);
            PNR.TabIndex = 3;
            PNR.Text = "DS7F88";

            fightNoLbl.AutoSize = true;
            fightNoLbl.BackColor = Color.Transparent;
            fightNoLbl.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            fightNoLbl.ForeColor = SystemColors.ActiveCaptionText;
            fightNoLbl.Location = new Point(389, 81);
            fightNoLbl.Name = "fightNoLbl";
            fightNoLbl.Size = new Size(50, 15);
            fightNoLbl.TabIndex = 3;
            fightNoLbl.Text = "FR114";

            PNRHeaderLbl.AutoSize = true;
            PNRHeaderLbl.Location = new Point(594, 40);
            PNRHeaderLbl.Name = "PNRHeaderLbl";
            PNRHeaderLbl.Size = new Size(33, 15);
            PNRHeaderLbl.TabIndex = 2;
            PNRHeaderLbl.Text = "PNR:";

            fightNoHeaderLbl.AutoSize = true;
            fightNoHeaderLbl.Location = new Point(389, 65);
            fightNoHeaderLbl.Name = "fightNoHeaderLbl";
            fightNoHeaderLbl.Size = new Size(87, 15);
            fightNoHeaderLbl.TabIndex = 2;
            fightNoHeaderLbl.Text = "Flight Number:";

            dateLbl.AutoSize = true;
            dateLbl.BackColor = Color.Transparent;
            dateLbl.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            dateLbl.ForeColor = SystemColors.ActiveCaptionText;
            dateLbl.Location = new Point(389, 28);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(92, 15);
            dateLbl.TabIndex = 3;
            dateLbl.Text = "01/JUL/2025";

            dateHeaderLbl.AutoSize = true;
            dateHeaderLbl.Location = new Point(389, 12);
            dateHeaderLbl.Name = "dateHeaderLbl";
            dateHeaderLbl.Size = new Size(34, 15);
            dateHeaderLbl.TabIndex = 2;
            dateHeaderLbl.Text = "Date:";

            nameLbl.AutoSize = true;
            nameLbl.BackColor = Color.Transparent;
            nameLbl.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            nameLbl.ForeColor = SystemColors.ActiveCaptionText;
            nameLbl.Location = new Point(178, 28);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(86, 15);
            nameLbl.TabIndex = 3;
            nameLbl.Text = "Anas Sarkiz";

            nameHeaderlbl.AutoSize = true;
            nameHeaderlbl.Location = new Point(178, 12);
            nameHeaderlbl.Name = "nameHeaderlbl";
            nameHeaderlbl.Size = new Size(42, 15);
            nameHeaderlbl.TabIndex = 2;
            nameHeaderlbl.Text = "Name:";

            mgBookingBtn.BackColor = Color.SteelBlue;
            mgBookingBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            mgBookingBtn.FlatAppearance.BorderSize = 0;
            mgBookingBtn.Font = new Font("Sitka Heading Semibold", 12F, FontStyle.Bold);
            mgBookingBtn.ForeColor = SystemColors.Control;
            mgBookingBtn.Location = new Point(753, 28);
            mgBookingBtn.Name = "mgBookingBtn";
            mgBookingBtn.Size = new Size(175, 53);
            mgBookingBtn.TabIndex = 1;
            mgBookingBtn.Text = "Manage Booking";
            mgBookingBtn.UseVisualStyleBackColor = false;

            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.ImageLocation = "https://cdn.britannica.com/13/77413-050-95217C0B/Golden-Gate-Bridge-San-Francisco.jpg";
            pictureBox1.Location = new Point(14, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;

            headerLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            headerLbl.AutoSize = true;
            headerLbl.Font = new Font("Segoe Print", 18F, FontStyle.Bold);
            headerLbl.Location = new Point(391, 25);
            headerLbl.Name = "headerLbl";
            headerLbl.Size = new Size(188, 43);
            headerLbl.TabIndex = 1;
            headerLbl.Text = "MY BOOKING";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(headerLbl);
            Controls.Add(flowLayoutPanel1);
            Name = "ManageBooking";
            Size = new Size(1000, 541);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label headerLbl;
        private Button mgBookingBtn;
        private Label nameHeaderlbl;
        private Label nameLbl;
        private Label label2;
        private Label fromToHeaderLbl;
        private Label fightNoLbl;
        private Label fightNoHeaderLbl;
        private Label dateHeaderLbl;
        private Label PNR;
        private Label PNRHeaderLbl;
        private Label dateLbl;
    }
}

   