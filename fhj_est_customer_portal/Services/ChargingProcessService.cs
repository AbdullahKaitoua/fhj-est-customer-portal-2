using fhj_est_customer_portal.Data;
using fhj_est_customer_portal.Entities;
using Microsoft.EntityFrameworkCore;



namespace fhj_est_customer_portal.Services
{
    public class ChargingProcessService
    {
        private readonly ApplicationDbContext _context;

        public ChargingProcessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChargingProcess>> GetChargingProcessesByUserId(string userId)
        {
            var userProcesses = await _context.ChargingProcesses
                .Include(cp => cp.ChargingPoint)
                .ThenInclude(cp => cp.ChargingStation)
                .Include(cp => cp.ChargingCard)
                .ThenInclude(cc => cc.LocationChargingCards)
                .ThenInclude(lcc => lcc.Location)
                .ThenInclude(l => l.UserLocations)
                .Where(cp => cp.ChargingCard.LocationChargingCards
                .Any(lcc => lcc.Location.UserLocations
                .Any(ul => ul.UserId == userId)))
                .ToListAsync();
           return userProcesses;
        }
    }

}
