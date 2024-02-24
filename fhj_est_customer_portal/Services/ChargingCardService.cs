using fhj_est_customer_portal.Data;
using fhj_est_customer_portal.Entities;
using Microsoft.EntityFrameworkCore;

namespace fhj_est_customer_portal.Services
{
    public class ChargingCardService
    {
        private readonly ApplicationDbContext _context;
        public ChargingCardService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChargingCard>> GetChargingCardsByUserId(string userId, bool? isActive)
        {
            var locations = await _context.UserLocations
                .Where(ul => ul.UserId == userId)
                .Select(ul => ul.LocationId)
                .ToListAsync();

            var query = _context.LocationChargingCards
                .Where(lcc => locations.Contains(lcc.LocationId))
                .Select(lcc => lcc.ChargingCard);

            if (isActive.HasValue)
            {
                query = query.Where(card => card.Active == isActive.Value);
            }

            return await query.ToListAsync();
        }

    }

}
