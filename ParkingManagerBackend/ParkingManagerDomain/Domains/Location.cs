using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    /// <summary>
    /// Represents a district in Bangladesh
    /// </summary>
    public class District: IAddress
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? NameBangla { get; set; }

        // Navigation property
        public ICollection<Thana>? Thanas { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Represents a thana/upazila within a district
    /// </summary>
    public class Thana: IAddress
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? NameBangla { get; set; }

        [Required]
        public Guid DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public District? District { get; set; }

        // Navigation property
        public ICollection<Location>? Locations { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Represents a specific location/address
    /// </summary>
    public class Location
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ThanaId { get; set; }

        [ForeignKey(nameof(ThanaId))]
        public Thana? Thana { get; set; }

        [MaxLength(500)]
        public string? FullAddress { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        // GPS coordinates (optional)
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public int GeoFenceRadiusMeters { get; set; } = 50; // Default to 50 meters 
    }
}
