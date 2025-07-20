// FlightService.cs
using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.Services
{
    public class FlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.GetAll();
        }

        public Flight GetFlightById(int id)
        {
            return _flightRepository.GetById(id);
        }

        public IEnumerable<Flight> SearchFlights(string origin, string destination, DateTime departureDate)
        {
            if (string.IsNullOrWhiteSpace(origin) || string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Origin and destination must be specified");

            return _flightRepository.SearchFlights(origin, destination, departureDate);
        }

        public IEnumerable<Flight> GetFlightsByAirline(string airline)
        {
            if (string.IsNullOrWhiteSpace(airline))
                throw new ArgumentException("Airline must be specified");

            return _flightRepository.GetFlightsByAirline(airline);
        }

        public bool AddFlight(Flight flight)
        {
            if (flight == null)
                throw new ArgumentNullException(nameof(flight));

            return _flightRepository.Add(flight);
        }

        public bool UpdateFlight(Flight flight)
        {
            if (flight == null)
                throw new ArgumentNullException(nameof(flight));

            return _flightRepository.Update(flight);
        }

        public bool DeleteFlight(int id)
        {
            return _flightRepository.Delete(id);
        }
    }
}