using FlightBookingSystem.Models;
using System.Collections.Generic;

namespace FlightBookingSystem.DAL
{
    public interface IBookingDetailsRepository
    {
        BookingDetails GetById(int id);
        BookingDetails GetByPNR(string pnr);
        IEnumerable<BookingDetails> GetAll();
        IEnumerable<BookingDetails> GetByUserId(int userId);
        bool Add(BookingDetails booking);
        bool Update(BookingDetails booking);
        bool Delete(int id);
        bool CancelBooking(int bookingId);
    }
}