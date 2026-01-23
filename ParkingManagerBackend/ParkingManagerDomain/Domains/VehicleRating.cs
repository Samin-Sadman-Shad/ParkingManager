using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    public class VehicleRating : Rating
    {
        [Required]
        public Guid VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle? Vehicle { get; set; }
    }
}
