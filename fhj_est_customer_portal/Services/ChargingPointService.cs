using fhj_est_customer_portal.Data;
using fhj_est_customer_portal.Entities;
using Microsoft.EntityFrameworkCore;

namespace fhj_est_customer_portal.Services
{
    public class ChargingPointService
    {
        private readonly ApplicationDbContext _context;

        public ChargingPointService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChargingPoint>> GetChargingPointsByStationIdAndAvailability(string stationId, bool? isPublic)
        {
            var query = _context.ChargingPoints.AsQueryable();

            if (isPublic.HasValue)
            {
                query = query.Where(cp => cp.ChargingStationId == stationId && cp.IsPublic == isPublic);
            }
            else
            {
                query = query.Where(cp => cp.ChargingStationId == stationId);
            }

            return await query.ToListAsync();
        }
    }
}
