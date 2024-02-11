using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace fhj_est_customer_portal.Entities
{
    public class ChargingCard
    {
        [Key]
        [StringLength(255)]
        [Unicode(false)]
        public string CardId { get; set; } = null!;
        public int Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Number { get; set; } = null!;
        [StringLength(255)]
        public string? Label { get; set; }
        public bool Active { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? BillingValidFrom { get; set; }
        public DateTime? BillingValidTo { get; set; }
        public virtual ICollection<LocationChargingCard> LocationChargingCards { get; set; }
        public virtual ICollection<ChargingProcess> ChargingProcesses { get; set; }

    }
}
