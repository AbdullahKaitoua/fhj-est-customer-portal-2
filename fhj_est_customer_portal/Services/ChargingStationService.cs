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

        /*public async Task<List<ChargingStation>> GetChargingStationsByUserId(string userId)
        {
            return await _context.ChargingStations.Where(cs => cs.UserId == userId).ToListAsync();
        }*/

        public async Task<List<ChargingStation>> GetChargingStationsByUserId(string userId)
        {
            var locations = await _context.UserLocations
                .Where(ul => ul.UserId == userId)
                .Select(ul => ul.LocationId)
                .ToListAsync();

            return await _context.ChargingStations
                .Where(cs => locations.Contains(cs.LocationId))
                .Include(cs => cs.Location)
                .ToListAsync();
        }

        public async Task<ChargingStation> GetChargingStationById(string id)
        {
            return await _context.ChargingStations
                .Include(cs => cs.Location)
                .Include(cs => cs.ChargingPoints)
                .FirstOrDefaultAsync(cs => cs.Uuid == id);
        }
    }
}
