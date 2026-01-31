using ParkingManagerDomain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    /// <summary>
    /// Represents an active/completed parking session.
    /// Created when vehicle actually checks in (enters parking lot).
    /// Tracks real-time parking and payment.
    /// </summary>
    public class ParkingSession
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        public Booking? Booking { get; set; }

        // Session status (actual parking state)
        [Required]
        public SessionStatus Status { get; set; } = SessionStatus.CheckedIn;

        // Actual parking time (ground truth)
        [Required]
        public DateTimeOffset ActualCheckIn { get; set; } = DateTimeOffset.UtcNow;
        
        public DateTimeOffset? ActualCheckOut { get; set; }

        // Actual duration spent parking
        public TimeSpan? ActualDuration
        {
            get
            {
                if (ActualCheckOut.HasValue)
                    return ActualCheckOut.Value - ActualCheckIn;
                return DateTimeOffset.UtcNow - ActualCheckIn; // Current duration if still parked
            }
        }

        // Payment tracking
        public decimal? FinalPrice { get; set; }
        public bool IsPaid { get; set; }
        public DateTimeOffset? PaidAt { get; set; }

        // Audit fields
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
