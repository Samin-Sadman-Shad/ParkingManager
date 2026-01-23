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
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }

        public string? LicensePlate { get; set; }

        public EnlistedVehicles? VehicleType { get; set; }
        public CarType? CarType { get; set; }

        public CarLevel? CarLevel { get; set; }

        // Navigation property for vehicle images
        public ICollection<VehicleImage>? Images { get; set; }

        // Navigation property for vehicle ratings
        public ICollection<VehicleRating>? Ratings { get; set; }

        public Guid? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? OwnedBy { get; set; }
    }
}
