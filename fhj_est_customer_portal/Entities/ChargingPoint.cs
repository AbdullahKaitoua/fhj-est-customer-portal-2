using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fhj_est_customer_portal.Entities
{
    public class ChargingPoint
    {
        public int Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(2)]
        [Unicode(false)]
        public string PowerType { get; set; } = null!;
        public int? MaxPower { get; set; }
        [StringLength(255)]
        public string? PlugTypes { get; set; }
        public bool? IsPublic { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string ChargingStationId { get; set; }
        public ChargingStation ChargingStation { get; set; }
        public virtual ICollection<ChargingProcess> ChargingProcesses { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("uuid")]
        [StringLength(255)]
        [Unicode(false)]
        public string Uuid { get; set; } = null!;
    }
}
