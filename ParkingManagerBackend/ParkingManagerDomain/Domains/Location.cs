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
        public ICollection<Street>? Streets { get; set; }
        // Note: No Locations navigation property - query locations by StreetId instead

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Represents a street/road within a thana.
    /// Supports hierarchical streets via composite pattern.
    /// </summary>
    public class Street
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? NameBangla { get; set; }

        [MaxLength(50)]
        public string? BlockNumber { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [Required]
        public Guid ThanaId { get; set; }

        [ForeignKey(nameof(ThanaId))]
        public Thana? Thana { get; set; }

        // Navigation properties
        public ICollection<Street>? ChildStreets { get; set; }
        
        // Note: No Locations navigation property to avoid loading all vehicle positions

        public ICollection<GarageLocation>? GarageLocations { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Base class for location with GPS coordinates on a street
    /// </summary>
    public abstract class Location
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public Street? Street { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Represents a garage location on a street
    /// </summary>
    public class GarageLocation : Location
    {
        [Required]
        public Guid GarageId { get; set; }

        [ForeignKey(nameof(GarageId))]
        public Garage? Garage { get; set; }
    }

    /// <summary>
    /// Represents a vehicle's current position on a street
    /// </summary>
    public class VehicleLocation : Location
    {
        [Required]
        public Guid VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle? Vehicle { get; set; }
    }
}
