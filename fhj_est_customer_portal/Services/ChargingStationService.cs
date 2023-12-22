using fhj_est_customer_portal.Data;
using fhj_est_customer_portal.Entities;
using Microsoft.EntityFrameworkCore;

namespace fhj_est_customer_portal.Services
{
    public class ChargingStationService
    {
        private readonly ApplicationDbContext _context;

        public ChargingStationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChargingStation>> GetChargingStationsByUserId(string userId)
        {
            return await _context.ChargingStations.Where(cs => cs.UserId == userId).ToListAsync();
        }
        public async Task<List<Location>> GetLocationsByUserId(string userId)
        {
            return await _context.UserLocations
                .Where(ul => ul.UserId == userId)
                .Select(ul => ul.Location)
                .ToListAsync();
        }
    }
}
