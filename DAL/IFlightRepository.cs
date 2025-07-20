using FlightBookingSystem.Models;
using System;
using System.Collections.Generic;

namespace FlightBookingSystem.DAL
{
    public interface IFlightRepository
    {
        Flight GetById(int id);
        IEnumerable<Flight> GetAll();
        bool Add(Flight flight);
        bool Update(Flight flight);
        bool Delete(int id);
        IEnumerable<Flight> SearchFlights(string origin, string destination, DateTime departureDate);
        IEnumerable<Flight> GetFlightsByAirline(string airline);
    }
}