using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.Services
{
    public class BookingService
    {
        private readonly IBookingDetailsRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;

        public BookingService(
            IBookingDetailsRepository bookingRepository,
            IFlightRepository flightRepository,
            IPassengerRepository passengerRepository)
        {
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
        }

        public BookingDetails CreateBooking(Flight apiFlight, Passenger passenger, User user, string seatClass)
        {
            if (apiFlight == null) throw new ArgumentNullException(nameof(apiFlight));
            if (passenger == null) throw new ArgumentNullException(nameof(passenger));
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (passenger.Id == 0)
            {
                if (!_passengerRepository.Add(passenger))
                    throw new Exception("Failed to save passenger information");
            }

            BookingDetails booking = new BookingDetails
            {

                FlightNumber = apiFlight.FlightNumber,
                Airline = apiFlight.Airline,
                Origin = apiFlight.Origin,
                Destination = apiFlight.Destination,
                DepartureTime = apiFlight.DepartureTime,
                ArrivalTime = apiFlight.ArrivalTime,
                OriginalPrice = apiFlight.Price,
                SeatClass = seatClass,

                // Passenger and user info
                Passenger = passenger, // Use the saved passenger ID
                BookedBuy = user,

                // Booking metadata
                SeatNumber = GenerateRandomSeat(),
                PNR = GeneratePNR(),
                TotalPrice = apiFlight.Price,
                BookingDate = DateTime.UtcNow,
                Status = "Confirmed"
            };

            if (!_bookingRepository.Add(booking))
                throw new Exception("Failed to create booking");

            return booking;
        }
        public bool CancelBooking(int bookingId)
        {
            BookingDetails booking = _bookingRepository.GetById(bookingId);
            if (booking == null || booking.Status == "Cancelled")
                return false;

            return _bookingRepository.CancelBooking(bookingId);
        }

        public BookingDetails GetBookingByPNR(string pnr)
        {
            if (string.IsNullOrWhiteSpace(pnr))
                throw new ArgumentException("PNR cannot be empty");

            return _bookingRepository.GetByPNR(pnr);
        }

        public IEnumerable<BookingDetails> GetUserBookings(int userId)
        {
            return _bookingRepository.GetByUserId(userId);
        }

        private string GeneratePNR()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomSeat()
        {
            Random random = new Random();
            int row = random.Next(1, 30);
            char seat = (char)('A' + random.Next(0, 6));
            return $"{row}{seat}";
        }
        public BookingDetails GetBookingById(int bookingId)
        {
            if (bookingId <= 0)
                throw new ArgumentException("Booking ID must be a positive number", nameof(bookingId));

            BookingDetails booking = _bookingRepository.GetById(bookingId);

            if (booking == null)
                throw new KeyNotFoundException($"Booking with ID {bookingId} not found");

            return booking;
        }
    }
}