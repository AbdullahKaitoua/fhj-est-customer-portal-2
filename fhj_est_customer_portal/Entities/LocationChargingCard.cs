namespace fhj_est_customer_portal.Entities
{
    public class LocationChargingCard
    {
        public string LocationId { get; set; }
        public Location Location { get; set; }
        public string ChargingCardId { get; set; }
        public ChargingCard ChargingCard { get; set; }
    }
}
