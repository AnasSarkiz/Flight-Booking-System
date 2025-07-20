// PassengerService.cs
using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.Services
{
    public class PassengerService
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public Passenger GetPassengerById(int id)
        {
            return _passengerRepository.GetById(id);
        }

        public IEnumerable<Passenger> GetPassengersByBooking(int bookingId)
        {
            return _passengerRepository.GetPassengersByBooking(bookingId);
        }

        public bool AddPassenger(Passenger passenger)
        {
            if (passenger == null)
                throw new ArgumentNullException(nameof(passenger));

            return _passengerRepository.Add(passenger);
        }

        public bool UpdatePassenger(Passenger passenger)
        {
            if (passenger == null)
                throw new ArgumentNullException(nameof(passenger));

            return _passengerRepository.Update(passenger);
        }

        public bool DeletePassenger(int id)
        {
            return _passengerRepository.Delete(id);
        }
    }
}