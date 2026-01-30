using ParkingManagerDomain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    /// <summary>
    /// Which spot to book, by whom, for which vehicle, from when to when, in which garage
    /// </summary>
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ParkingSpotId { get; set; } //which parking spot to book 

        [ForeignKey(nameof(ParkingSpotId))]
        public ParkingSpot? ParkingSpot { get; set; }

        [Required]
        public Guid UserId { get; set; } //by whom

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required]
        public Guid VehicleId { get; set; } //for which vehicle

        [ForeignKey(nameof(VehicleId))]
        public Vehicle? Vehicle { get; set; }

        // Booking time window
        [Required]
        public DateTimeOffset StartTime { get; set; }

        [Required]
        public DateTimeOffset EndTime { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return EndTime - StartTime;
            }
        }

        [Required]
        public Guid GarageId { get; set; }
        public Garage? Garage { get; set; }

        // Status tracking
        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Reserved;

        // Actual usage tracking
        public DateTimeOffset? ActualCheckIn { get; set; }
        public DateTimeOffset? ActualCheckOut { get; set; }

        // Payment tracking
        public decimal EstimatedPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public bool IsPaid { get; set; }

        // Audit fields
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? CancelledAt { get; set; }
        public string? CancellationReason { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
