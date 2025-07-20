using FlightBookingSystem.Models;
using System.Collections.Generic;

namespace FlightBookingSystem.DAL
{
    public interface IPassengerRepository
    {
        Passenger GetById(int id);
        IEnumerable<Passenger> GetAll();
        bool Add(Passenger passenger);
        bool Update(Passenger passenger);
        bool Delete(int id);
        IEnumerable<Passenger> GetPassengersByBooking(int bookingId);
    }
}