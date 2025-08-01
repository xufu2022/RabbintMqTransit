using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using AirlineBookingSystem.Flights.Infrastructure.Data;

namespace AirlineBookingSystem.Flights.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IFlightContext _context;

        public FlightRepository(IFlightContext context)
        {
            _context = context;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _context.Flights.InsertOneAsync(flight);
        }

        public async Task DeleteFlightAsync(Guid id)
        {
            await _context.Flights.DeleteOneAsync(f => f.Id ==id);
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _context.Flights.Find(f => true).ToListAsync();
        }
    }
}
