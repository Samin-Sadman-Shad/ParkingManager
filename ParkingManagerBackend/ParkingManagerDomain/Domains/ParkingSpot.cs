using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Domains
{
    /// <summary>
    /// Represents a physical parking spot in a garage.
    /// Occupancy and availability are tracked via Booking entity.
    /// </summary>
    public class ParkingSpot
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string SpotId { get; set; } = string.Empty;

        [Required]
        public int FloorNo { get; set; }

        [Required]
        public Guid GarageId { get; set; }

        [ForeignKey(nameof(GarageId))]
        public Garage? Garage { get; set; }

        // Navigation property for bookings
        public ICollection<Booking>? Bookings { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}

