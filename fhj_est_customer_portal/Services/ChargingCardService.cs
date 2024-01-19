using fhj_est_customer_portal.Data;
using fhj_est_customer_portal.Entities;
using Microsoft.AspNetCore.Identity;
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
        public async Task<List<ChargingCard>> GetChargingCardsByUserId(string userId)
        {
            var locations = await _context.UserLocations
                .Where(ul => ul.UserId == userId)
                .Select(ul => ul.LocationId)
                .ToListAsync();

            return await _context.LocationChargingCards
                .Where(lcc => locations.Contains(lcc.LocationId))
                .Select(lcc => lcc.ChargingCard)
                .ToListAsync();
        }
    }

}
