using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fhj_est_customer_portal.Entities
{
    public class Location
    {
        // location must have a uinique id and name it should have many to many relationship with Application user
        // it should have a one to many relationship with charging station

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string Id { get; set; }

            [Required]
            [StringLength(255)]
            public string Name { get; set; }

          
            public virtual ICollection<UserLocation> UserLocations { get; set; }
            public virtual ICollection<ChargingStation> ChargingStations { get; set; }
        }
    }



