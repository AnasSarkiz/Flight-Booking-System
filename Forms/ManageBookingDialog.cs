using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FlightBookingSystem.Controls
{
    public partial class ManageBookingDialog : Form
    {
        private readonly BookingDetails _booking;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IBookingDetailsRepository _bookingRepository;

        public event EventHandler<(int BookingId, Passenger UpdatedPassenger, DateTime? NewDepartureDate)> BookingUpdated;
        public event EventHandler<int> BookingCancelled;

        public ManageBookingDialog(BookingDetails booking,
                                 IPassengerRepository passengerRepository,
                                 IBookingDetailsRepository bookingRepository)
        {
            _booking = booking;
            _passengerRepository = passengerRepository;
            _bookingRepository = bookingRepository;
            InitializeComponent();
            InitializeBookingDetails();
            this.Text = $"Manage Booking - {_booking.PNR}";
        }

        private void InitializeBookingDetails()
        {
            txtFirstName.Text = _booking.Passenger.FirstName;
            txtLastName.Text = _booking.Passenger.LastName;

            string originCity = GetCityName(_booking.Origin);
            string originCode = GetAirportCode(_booking.Origin);
            string destCity = GetCityName(_booking.Destination);
            string destCode = GetAirportCode(_booking.Destination);

            lblFlightInfo.Text = $"{_booking.Airline} {_booking.FlightNumber}";
            lblRoute.Text = $"{originCity} ({originCode}) → {destCity} ({destCode})";

            dtpDeparture.Value = _booking.DepartureTime;
            dtpArrival.Value = _booking.ArrivalTime;

            lblDuration.Text = $"Duration: {FormatDuration(_booking.ArrivalTime - _booking.DepartureTime)}";
            lblSeat.Text = $"Seat: {_booking.SeatNumber} ({_booking.SeatClass})";
            lblStatus.Text = $"Status: {_booking.Status}";
            lblStatus.ForeColor = _booking.Status == "Confirmed" ? Color.Green : Color.OrangeRed;
            lblPNR.Text = $"PNR: {_booking.PNR}";
            lblIssuedAt.Text = $"Issued at: {_booking.BookingDate:MMM dd, yyyy hh:mm tt}";
            lblPrice.Text = $"Total Paid: {_booking.FormattedTotalPrice}";

            bool canModify = _booking.Status == "Confirmed";
            txtFirstName.Enabled = canModify;
            txtLastName.Enabled = canModify;
            dtpDeparture.Enabled = canModify;
            dtpArrival.Enabled = canModify;
            btnSaveChanges.Enabled = canModify;
            btnCancelBooking.Enabled = canModify;
            btnGeneratePDF.Enabled = true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    _booking.Passenger.FirstName = txtFirstName.Text;
                    _booking.Passenger.LastName = txtLastName.Text;
                    _passengerRepository.Update(_booking.Passenger);

                    DateTime? newDepartureDate = null;
                    if (dtpDeparture.Value.Date != _booking.DepartureTime.Date)
                    {
                        newDepartureDate = dtpDeparture.Value;
                    }

                    BookingUpdated?.Invoke(this, (_booking.Id, _booking.Passenger, newDepartureDate));
                    MessageBox.Show("Booking updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDeparture.Value >= dtpArrival.Value)
            {
                MessageBox.Show("Departure time must be before arrival time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"FlightDetails_{_booking.PNR}_{Guid.NewGuid()}.pdf");

                GenerateFlightDetailsPDF(tempFilePath);

                var result = MessageBox.Show("PDF generated successfully! Would you like to preview it before saving?",
                                           "PDF Ready",
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PreviewPDF(tempFilePath);

                    var saveResult = MessageBox.Show("Would you like to save this PDF?",
                                                   "Save PDF",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                    if (saveResult == DialogResult.Yes)
                    {
                        SavePDFWithDialog(tempFilePath);
                    }
                }
                else if (result == DialogResult.No)
                {
                    SavePDFWithDialog(tempFilePath);
                }

                try
                {
                    if (File.Exists(tempFilePath))
                        File.Delete(tempFilePath);
                }
                catch {}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviewPDF(string filePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to preview PDF: {ex.Message}\n\nMake sure you have a PDF reader installed.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePDFWithDialog(string sourceFilePath)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"FlightDetails_{_booking.PNR}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(sourceFilePath, saveFileDialog.FileName, overwrite: true);
                        MessageBox.Show($"PDF saved successfully to:\n{saveFileDialog.FileName}",
                                      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GenerateFlightDetailsPDF(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                var document = new Document(PageSize.A4, 36, 36, 36, 36);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string logoRelativePath = Path.Combine(baseDirectory, @"..\..\..\resources\img\plane.png");
                string logoPath = Path.GetFullPath(logoRelativePath);
                if (File.Exists(logoPath))
                {
                    var logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(60, 60);
                    logo.Alignment = Element.ALIGN_LEFT;
                    document.Add(logo);
                }

                Paragraph header = new("Re7la - Flight Booking",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, new BaseColor(0, 0, 139)));
                header.Alignment = Element.ALIGN_CENTER;
                document.Add(header);

                Paragraph lineSeparator = new(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.5f, 100f, new BaseColor(200, 200, 200), Element.ALIGN_CENTER, 1)));
                document.Add(lineSeparator);
                document.Add(new Paragraph("\n"));

                Paragraph title = new("FLIGHT BOOKING DETAILS",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, new BaseColor(0, 0, 139)));
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                PdfPTable mainTable = new PdfPTable(2);
                mainTable.WidthPercentage = 100;
                mainTable.SetWidths(new float[] { 1, 1 });

                PdfPCell leftCell = new PdfPCell();
                leftCell.Border = PdfPCell.NO_BORDER;
                leftCell.PaddingBottom = 10f;

                Paragraph bookingHeader = new("BOOKING INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.DARK_GRAY));
                leftCell.AddElement(bookingHeader);
                leftCell.AddElement(new Paragraph($"PNR: {_booking.PNR}"));
                leftCell.AddElement(new Paragraph($"Booking Date: {_booking.BookingDate:MMM dd, yyyy}"));
                leftCell.AddElement(new Paragraph($"Status: {_booking.Status}",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12,
                    _booking.Status == "Confirmed" ? BaseColor.GREEN : BaseColor.RED)));
                leftCell.AddElement(new Paragraph("\n"));

                Paragraph flightHeader = new("FLIGHT INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.DARK_GRAY));
                leftCell.AddElement(flightHeader);
                leftCell.AddElement(new Paragraph($"{_booking.Airline} - Flight {_booking.FlightNumber}"));
                leftCell.AddElement(new Paragraph($"From: {_booking.Origin}"));
                leftCell.AddElement(new Paragraph($"To: {_booking.Destination}"));
                leftCell.AddElement(new Paragraph($"Departure: {_booking.DepartureTime:ddd, MMM dd yyyy HH:mm}"));
                leftCell.AddElement(new Paragraph($"Arrival: {_booking.ArrivalTime:ddd, MMM dd yyyy HH:mm}"));
                leftCell.AddElement(new Paragraph($"Duration: {FormatDuration(_booking.ArrivalTime - _booking.DepartureTime)}"));
                leftCell.AddElement(new Paragraph($"Seat: {_booking.SeatNumber} ({_booking.SeatClass})"));
                leftCell.AddElement(new Paragraph("\n"));

                Paragraph paymentHeader = new("PAYMENT INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.DARK_GRAY));
                leftCell.AddElement(paymentHeader);
                leftCell.AddElement(new Paragraph($"Total Paid: {_booking.FormattedTotalPrice}",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, new BaseColor(0, 100, 0))));

                PdfPCell rightCell = new PdfPCell();
                rightCell.Border = PdfPCell.NO_BORDER;
                rightCell.PaddingBottom = 10f;

                Paragraph passengerHeader = new Paragraph("PASSENGER INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.DARK_GRAY));
                rightCell.AddElement(passengerHeader);
                rightCell.AddElement(new Paragraph($"Name: {_booking.Passenger.FirstName} {_booking.Passenger.LastName}"));
                rightCell.AddElement(new Paragraph($"Passport: {_booking.Passenger.PassportNumber}"));
                rightCell.AddElement(new Paragraph($"Nationality: {_booking.Passenger.Nationality}"));
                rightCell.AddElement(new Paragraph("\n"));

                if (!string.IsNullOrEmpty(_booking.DestinationImageUrl) && Uri.IsWellFormedUriString(_booking.DestinationImageUrl, UriKind.Absolute))
                {
                    try
                    {
                        var destinationImage = iTextSharp.text.Image.GetInstance(new Uri(_booking.DestinationImageUrl));
                        destinationImage.ScaleToFit(200, 150);
                        destinationImage.Alignment = Element.ALIGN_CENTER;
                        rightCell.AddElement(new Paragraph("Destination:",
                            FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                        rightCell.AddElement(destinationImage);
                    }
                    catch
                    {
                        // If image loading fails, just continue without it
                    }
                }

                mainTable.AddCell(leftCell);
                mainTable.AddCell(rightCell);
                document.Add(mainTable);

                document.Add(new Paragraph("\n\n\n\n"));
                Paragraph signatureLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.5f, 200f, new BaseColor(200, 200, 200), Element.ALIGN_LEFT, 1)));
                document.Add(signatureLine);
                Paragraph signatureText = new Paragraph("Authorized Signature",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.GRAY));
                signatureText.Alignment = Element.ALIGN_LEFT;
                document.Add(signatureText);

                document.Add(new Paragraph("\n\n"));
                Paragraph footer = new Paragraph("Thank you for choosing Re7la for your travel needs!",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.DARK_GRAY));
                footer.Alignment = Element.ALIGN_CENTER;
                document.Add(footer);

                document.Close();
            }
        }

        private string GetCityName(string airportInfo)
        {
            int parenIndex = airportInfo.IndexOf('(');
            return parenIndex > 0 ? airportInfo.Substring(0, parenIndex).Trim() : airportInfo;
        }

        private string GetAirportCode(string airportInfo)
        {
            int parenIndex = airportInfo.IndexOf('(');
            if (parenIndex > 0 && airportInfo.EndsWith(")"))
            {
                return airportInfo.Substring(parenIndex + 1, airportInfo.Length - parenIndex - 2);
            }
            return airportInfo;
        }

        private string FormatDuration(TimeSpan duration)
        {
            return $"{duration.Hours}h {duration.Minutes}m";
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this booking?",
                                      "Confirm Cancellation",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BookingCancelled?.Invoke(this, _booking.Id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}