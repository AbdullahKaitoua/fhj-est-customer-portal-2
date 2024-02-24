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

        public async Task<List<ChargingStation>> GetChargingStationsByUserIdAndLocation(string userId, string locationName)
        {
            var userLocationIds = _context.UserLocations
                .Where(ul => ul.UserId == userId)
                .Select(ul => ul.LocationId);

            IQueryable<ChargingStation> query = _context.ChargingStations
                .Where(cs => userLocationIds.Contains(cs.LocationId))
                .Include(cs => cs.Location);

            if (!string.IsNullOrEmpty(locationName))
            {
                query = query.Where(cs => cs.Location.Name == locationName);
            }

            return await query.ToListAsync();
        }




        public async Task<ChargingStation> GetChargingStationById(string id)
        {
            return await _context.ChargingStations
                .Include(cs => cs.Location)
                .FirstOrDefaultAsync(cs => cs.Uuid == id);
        }



        public async Task<List<string>> GetLocationNamesByUserId(string userId)
        {
            var locationNames = await _context.Locations
                .Where(l => l.UserLocations.Any(ul => ul.UserId == userId))
                .Select(l => l.Name)
                .ToListAsync();

            return locationNames;
        }






    }
}
