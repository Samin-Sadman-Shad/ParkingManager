using ParkingManagerDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Domains
{
    public class Garage
    {
        [Key]
        public Guid Id { get; set; }

        public Guid GarageLocationId { get; set; }

        [ForeignKey(nameof(GarageLocationId))]
        public GarageLocation? GarageLocation { get; set; }

        public int Capacity { get; set; }

        public int FloorNo { get; set; }

        public ICollection<ParkingSpot>? ParkingSpots { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User? Owner { get; set; }

        public GarageStatus garageStatus { get; set; } = GarageStatus.Open;
    }
}
