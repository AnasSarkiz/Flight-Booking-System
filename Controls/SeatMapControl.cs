using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class SeatMapControl : UserControl
    {
        public event EventHandler<string> SeatSelected;

        private string _selectedSeat = "";
        private readonly string[] _occupiedSeats = { "1A", "3C", "5F", "12D" }; // Sample occupied seats
        private readonly string[] _extraLegroomSeats = { "7A", "7F", "8A", "8F", "12A", "12F", "24A", "24F" };

        public SeatMapControl()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw aircraft outline
            g.FillRectangle(Brushes.LightGray, 40, 40, 600, 300);
            g.DrawRectangle(Pens.DarkGray, 40, 40, 600, 300);

            // Draw aisle
            g.FillRectangle(Brushes.White, 300, 40, 80, 300);
            g.DrawLine(Pens.DarkGray, 300, 40, 300, 340);
            g.DrawLine(Pens.DarkGray, 380, 40, 380, 340);

            // Draw seats (6 columns, 20 rows)
            for (int row = 1; row <= 20; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    char seatLetter = (char)('A' + col);
                    string seat = $"{row}{seatLetter}";

                    bool isOccupied = Array.Exists(_occupiedSeats, s => s == seat);
                    bool isExtraLegroom = Array.Exists(_extraLegroomSeats, s => s == seat);

                    var brush = isOccupied ? Brushes.LightCoral :
                                seat == _selectedSeat ? Brushes.Gold :
                                isExtraLegroom ? Brushes.Cyan : Brushes.LightGreen;

                    int x = col switch
                    {
                        0 => 150, // A
                        1 => 200, // B
                        2 => 400, // C
                        3 => 450, // D
                        4 => 500, // E
                        5 => 550, // F
                        _ => 0
                    };

                    int y = 40 + row * 15;

                    g.FillRectangle(brush, x, y, 30, 30);
                    g.DrawRectangle(Pens.Black, x, y, 30, 30);
                    g.DrawString(seat, this.Font, Brushes.Black, x + 5, y + 8);
                }
            }

            // Draw legend
            DrawLegend(g, 40, 360);
        }

        private void DrawLegend(Graphics g, int x, int y)
        {
            void DrawItem(string text, Brush brush)
            {
                g.FillRectangle(brush, x, y, 15, 15);
                g.DrawRectangle(Pens.Black, x, y, 15, 15);
                g.DrawString(text, this.Font, Brushes.Black, x + 20, y);
                x += 120;
            }

            DrawItem("Available", Brushes.LightGreen);
            DrawItem("Selected", Brushes.Gold);
            DrawItem("Occupied", Brushes.LightCoral);
            DrawItem("Extra Legroom", Brushes.Cyan);
        }
        private void seatMapControl1_SeatSelected(object sender, string seat)
        {
            _selectedSeat = seat;
            lblSeatInfo.Text = $"Selected Seat: {seat}";
            lblSeatInfo.ForeColor = Color.DarkGreen;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSeat))
            {
                lblSeatInfo.ForeColor = Color.Red;
                lblSeatInfo.Text = "Please select a seat first!";
                return;
            }

            // ... rest of confirmation logic ...
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            for (int row = 1; row <= 20; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    int x = col switch
                    {
                        0 => 150,
                        1 => 200,
                        2 => 400,
                        3 => 450,
                        4 => 500,
                        5 => 550,
                        _ => 0
                    };

                    int y = 40 + row * 15;

                    if (e.X >= x && e.X <= x + 30 && e.Y >= y && e.Y <= y + 30)
                    {
                        char seatLetter = (char)('A' + col);
                        string seat = $"{row}{seatLetter}";

                        if (Array.Exists(_occupiedSeats, s => s == seat))
                        {
                            MessageBox.Show("This seat is already occupied", "Seat Occupied",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        _selectedSeat = seat;
                        SeatSelected?.Invoke(this, seat);
                        Invalidate();
                        return;
                    }
                }
            }
        }
    }
}