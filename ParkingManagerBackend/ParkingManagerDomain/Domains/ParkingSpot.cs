using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Domains
{
    public class ParkingSpot
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string SpotId { get; set; }
        [Required]
        public int FloorNo { get; set; }

        [Required]
        public Guid GarageId { get; set; }

        [ForeignKey(nameof(GarageId))]
        [Required]
        public Garage Garage { get; set; }
        public Guid? OccupiedByVehicleId { get; set; }

        [ForeignKey(nameof(OccupiedByVehicleId))]
        public Vehicle? OccupiedBy { get; set; }
        public DateTimeOffset? OccupiedAt { get; set; }

        public DateTimeOffset WillAvailableAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
