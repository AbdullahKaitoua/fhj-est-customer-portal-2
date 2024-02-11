using fhj_est_customer_portal.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace fhj_est_customer_portal.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required ,MaxLength(25)]
        public string? Name { get; set; }
        public virtual ICollection<UserLocation>? UserLocations { get; set; }
    }

}
