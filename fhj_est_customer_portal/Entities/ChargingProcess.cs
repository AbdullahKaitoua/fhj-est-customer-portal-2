using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fhj_est_customer_portal.Entities
{
    public class ChargingProcess
    {
        public int Deleted { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public DateTime? StartDatetime { get; set; }

        public DateTime? EndDatetime { get; set; }

        public long? MeterStart { get; set; }

        public long? MeterEnd { get; set; }

        public int? MeterTotal { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Status { get; set; }
        public bool Finished { get; set; }
   
        [StringLength(1023)]
        public string Costs { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string? ChargingCardId { get; set; }
        public virtual ChargingCard ChargingCard { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? ChargingPointId { get; set; }
        public virtual ChargingPoint ChargingPoint { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("uuid")]
        [StringLength(255)]
        [Unicode(false)]
        public string Uuid { get; set; } = null!;
    }
}
