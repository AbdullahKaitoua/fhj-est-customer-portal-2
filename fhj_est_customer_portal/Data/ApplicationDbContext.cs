using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using fhj_est_customer_portal.Entities;

namespace fhj_est_customer_portal.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
       
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<UserLocation> UserLocations { get; set; } = null!;
        public DbSet<ChargingStation> ChargingStations { get; set; } = null!;  
        public DbSet<Books> Books { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLocation>().HasKey(ul => new { ul.UserId, ul.LocationId });
            modelBuilder.Entity<UserLocation>().HasOne(ul => ul.User).WithMany(u => u.UserLocations).HasForeignKey(ul => ul.UserId);
            modelBuilder.Entity<UserLocation>().HasOne(ul => ul.Location).WithMany(l => l.UserLocations).HasForeignKey(ul => ul.LocationId);
        }
    }

}
