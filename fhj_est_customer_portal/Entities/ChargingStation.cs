using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using fhj_est_customer_portal.Data;


// create anothor entity like this named location and add it to the context
// and then add a migration and update the database
// then add a controller for the location entity
// then add a view for the location entity
// then add a link to the location view in the navigation bar
// then add a link to the location view in the home page
// then add a link to the location view in the index view
// then add a link to the location view in the layout view
// then add a link to the location view in the about view
    
namespace fhj_est_customer_portal.Entities
{
    public class ChargingStation
    {
      
        public int? Deleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? Manufacturer { get; set; }
        [StringLength(255)]
        public string? Model { get; set; }
        [StringLength(255)]
        public string? SerialNbr { get; set; }
        [StringLength(255)]
        public string? FirmwareVersion { get; set; }
        [StringLength(255)]
        public string OperatorName { get; set; } = null!;
        [Column(TypeName = "decimal(9,6)")]
        public decimal? Lat { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Long { get; set; }
        [StringLength(255)]
        public string? Country { get; set; }
        [StringLength(255)]
        public string? City { get; set; }
        [StringLength(255)]
        public string? Zip { get; set; }
        [StringLength(255)]
        public string? Street { get; set; }
        public DateTime? BillingBegin { get; set; }
        public DateTime? BillingEnd { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string EnergyProvider { get; set; } = null!;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("uuid")]
        [StringLength(255)]
        [Unicode(false)]
        public string Uuid { get; set; } = null!;

        public string LocationId { get; set; }

        public  Location Location { get; set; }

    }
}
