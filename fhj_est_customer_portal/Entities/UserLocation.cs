using fhj_est_customer_portal.Data;

namespace fhj_est_customer_portal.Entities
{
    public class UserLocation
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }
    }
}