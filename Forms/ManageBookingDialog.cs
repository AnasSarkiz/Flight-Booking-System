using System;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FlightBookingSystem.Models;
using FlightBookingSystem.DAL;
using System.Net;

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

                DialogResult result = MessageBox.Show("PDF generated successfully! Would you like to preview it before saving?",
                                           "PDF Ready",
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PreviewPDF(tempFilePath);

                    DialogResult saveResult = MessageBox.Show("Would you like to save this PDF?",
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
                catch { }
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
                        File.Copy(sourceFilePath, saveFileDialog.FileName, true);
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
                Document document = new Document(PageSize.A4, 25, 25, 30, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                PdfPTable headerTable = new PdfPTable(3);
                headerTable.WidthPercentage = 100;
                headerTable.SetWidths(new float[] { 1, 3, 1 });

                string companyLogoPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\resources\img\plane.png"));
                if (File.Exists(companyLogoPath))
                {
                    iTextSharp.text.Image companyLogo = iTextSharp.text.Image.GetInstance(companyLogoPath);
                    companyLogo.ScaleToFit(60, 60);
                    PdfPCell logoCell = new PdfPCell(companyLogo);
                    logoCell.Border = PdfPCell.NO_BORDER;
                    logoCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    headerTable.AddCell(logoCell);
                }
                else
                {
                    headerTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });
                }
                PdfPTable titleTable = new PdfPTable(1);
                titleTable.WidthPercentage = 100;

                PdfPCell companyNameCell = new PdfPCell(new Phrase("RE7LA",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLUE)));
                companyNameCell.Border = PdfPCell.NO_BORDER;
                companyNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                titleTable.AddCell(companyNameCell);

                PdfPCell titleCell = new PdfPCell(new Phrase("FLIGHT BOOKING RECEIPT",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY)));
                titleCell.Border = PdfPCell.NO_BORDER;
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                titleTable.AddCell(titleCell);

                PdfPCell centerCell = new PdfPCell(titleTable);
                centerCell.Border = PdfPCell.NO_BORDER;
                headerTable.AddCell(centerCell);


              

                string airlineLogoUrl = $"https://content.airhex.com/content/logos/airlines_{_booking.Airline}_80_80_s.png";
                if (!string.IsNullOrEmpty(airlineLogoUrl))
                {
                    try
                    {
                        iTextSharp.text.Image airlineLogo = iTextSharp.text.Image.GetInstance(new Uri(airlineLogoUrl));
                        airlineLogo.ScaleToFit(80, 80);
                        airlineLogo.Alignment = Element.ALIGN_CENTER;

                        PdfPCell airlineCell = new PdfPCell();
                        airlineCell.Border = PdfPCell.NO_BORDER;
                        airlineCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        airlineCell.AddElement(airlineLogo);
                        headerTable.AddCell(airlineCell);
                    }
                    catch
                    {
                        headerTable.AddCell(new PdfPCell(new Phrase(_booking.Airline,
                            FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_RIGHT
                        });
                    }
                }
                else
                {
                    headerTable.AddCell(new PdfPCell(new Phrase(_booking.Airline,
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        Border = PdfPCell.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    });
                }

                document.Add(headerTable);
                document.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.5f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1))));
                document.Add(new Paragraph("\n"));

                PdfPTable mainTable = new PdfPTable(2);
                mainTable.WidthPercentage = 100;
                mainTable.SetWidths(new float[] { 1, 1 });

                PdfPCell leftCell = new PdfPCell();
                leftCell.Border = PdfPCell.NO_BORDER;
                leftCell.PaddingBottom = 10f;

                leftCell.AddElement(new Paragraph("BOOKING INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY)));
                leftCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.25f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_LEFT, -1))));
                leftCell.AddElement(CreateDetailRow("PNR:", _booking.PNR, true));
                leftCell.AddElement(CreateDetailRow("Booking Date:", _booking.BookingDate.ToString("MMM dd, yyyy HH:mm")));
                leftCell.AddElement(CreateDetailRow("Status:", _booking.Status,
                    fontColor: _booking.Status == "Confirmed" ? BaseColor.GREEN : BaseColor.RED));
                leftCell.AddElement(new Paragraph("\n\n\n"));

                leftCell.AddElement(new Paragraph("FLIGHT INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY)));
                leftCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.25f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_LEFT, -1))));
                leftCell.AddElement(CreateDetailRow("Airline:", $"{_booking.Airline} ({_booking.FlightNumber})"));
                leftCell.AddElement(CreateDetailRow("Route:", $"{_booking.Origin} → {_booking.Destination}"));
                leftCell.AddElement(CreateDetailRow("Departure:", _booking.DepartureTime.ToString("ddd, MMM dd yyyy HH:mm")));
                leftCell.AddElement(CreateDetailRow("Arrival:", _booking.ArrivalTime.ToString("ddd, MMM dd yyyy HH:mm")));
                leftCell.AddElement(CreateDetailRow("Duration:", FormatDuration(_booking.ArrivalTime - _booking.DepartureTime)));
                leftCell.AddElement(CreateDetailRow("Seat:", $"{_booking.SeatNumber} ({_booking.SeatClass})"));
                leftCell.AddElement(new Paragraph("\n"));

                leftCell.AddElement(new Paragraph("PAYMENT INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY)));
                leftCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.25f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_LEFT, -1))));
                leftCell.AddElement(CreateDetailRow("Base Fare:", $"${_booking.OriginalPrice:0.00}"));
                leftCell.AddElement(CreateDetailRow("Taxes & Fees:", "$0.00"));
                leftCell.AddElement(CreateDetailRow("Total Paid:", _booking.FormattedTotalPrice, true,
                    font: FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, new BaseColor(0, 100, 0))));

                PdfPCell rightCell = new PdfPCell();
                rightCell.Border = PdfPCell.NO_BORDER;
                rightCell.PaddingBottom = 10f;

                rightCell.AddElement(new Paragraph("PASSENGER INFORMATION",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY)));
                rightCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.25f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_LEFT, -1))));
                rightCell.AddElement(CreateDetailRow("Name:", $"{_booking.Passenger.FirstName} {_booking.Passenger.LastName}"));
                rightCell.AddElement(CreateDetailRow("Passport:", _booking.Passenger.PassportNumber));
                rightCell.AddElement(CreateDetailRow("Nationality:", _booking.Passenger.Nationality));
                rightCell.AddElement(CreateDetailRow("Email:", _booking.Passenger.Email ?? "N/A"));
                rightCell.AddElement(CreateDetailRow("Phone:", _booking.Passenger.Phone ?? "N/A"));
                rightCell.AddElement(new Paragraph("\n"));

                rightCell.AddElement(new Paragraph("TERMS & CONDITIONS",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.DARK_GRAY)));
                rightCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.25f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_LEFT, -1))));
                rightCell.AddElement(new Paragraph("• This is an electronic ticket"));
                rightCell.AddElement(new Paragraph("• Check-in opens 24 hours before departure"));
                rightCell.AddElement(new Paragraph("• Boarding closes 30 minutes before departure"));
                rightCell.AddElement(new Paragraph("• Cancellation policies apply based on fare rules"));
                rightCell.AddElement(new Paragraph("\n\n"));

                if (!string.IsNullOrEmpty(_booking.DestinationImageUrl) &&
                      Uri.IsWellFormedUriString(_booking.DestinationImageUrl, UriKind.Absolute))
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            byte[] imageData = client.DownloadData(_booking.DestinationImageUrl);
                            iTextSharp.text.Image destinationImage = iTextSharp.text.Image.GetInstance(imageData);
                            destinationImage.ScaleToFit(200, 150);
                            destinationImage.Alignment = Element.ALIGN_CENTER;
                            rightCell.AddElement(new Paragraph("   Your Destination Image:",
                                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                            rightCell.AddElement(new Paragraph("\n"));
                            rightCell.AddElement(destinationImage);
                        }
                    }
                    catch { rightCell.AddElement(new Paragraph("Faild to Load Destination Image")) ; }
                            
                }

                mainTable.AddCell(leftCell);
                mainTable.AddCell(rightCell);
                document.Add(mainTable);

                document.Add(new Paragraph("\n\n"));

                PdfPTable footerTable = new PdfPTable(1);
                footerTable.WidthPercentage = 50;
                footerTable.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell signatureCell = new PdfPCell();
                signatureCell.Border = PdfPCell.NO_BORDER;
                signatureCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                    0.5f, 150f, BaseColor.LIGHT_GRAY, Element.ALIGN_LEFT, -1))));
                signatureCell.AddElement(new Paragraph("Authorized Signature",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.GRAY)));

                footerTable.AddCell(signatureCell);
                document.Add(footerTable);

                Paragraph thankYou = new Paragraph("\n\nThank you for choosing our airline for your travel needs!\n" +
                                         "We wish you a pleasant journey.",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.DARK_GRAY));
                thankYou.Alignment = Element.ALIGN_CENTER;
                document.Add(thankYou);

                document.Add(new Paragraph("\n"));
                Paragraph pageNumber = new Paragraph($"Page 1 of 1",
                    FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY));
                pageNumber.Alignment = Element.ALIGN_CENTER;
                document.Add(pageNumber);

                document.Close();
            }
        }

        private PdfPTable CreateDetailRow(string label, string value, bool isBold = false,
            BaseColor fontColor = null, iTextSharp.text.Font font = null)
        {
            PdfPTable rowTable = new PdfPTable(2);
            rowTable.WidthPercentage = 100;
            rowTable.SetWidths(new float[] { 1, 2 });

            iTextSharp.text.Font labelFont = font ?? FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);
            iTextSharp.text.Font valueFont = font ?? (isBold ?
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, fontColor ?? BaseColor.BLACK) :
                FontFactory.GetFont(FontFactory.HELVETICA, 10, fontColor ?? BaseColor.BLACK));

            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.Border = PdfPCell.NO_BORDER;
            labelCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell valueCell = new PdfPCell(new Phrase(value, valueFont));
            valueCell.Border = PdfPCell.NO_BORDER;
            valueCell.HorizontalAlignment = Element.ALIGN_LEFT;

            rowTable.AddCell(labelCell);
            rowTable.AddCell(valueCell);
            return rowTable;
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
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?",
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