using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    public class VehicleImage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public string? ThumbnailUrl { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime UploadedAt { get; set; }

        public int DisplayOrder { get; set; }

        // Navigation property
        [ForeignKey(nameof(VehicleId))]
        public Vehicle? Vehicle { get; set; }
    }
}
