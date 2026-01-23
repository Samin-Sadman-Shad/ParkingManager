using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    public abstract class Rating
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Points { get; set; }

        public string? Review { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? UpdatedAt { get; set; }

        [Required]
        public Guid GivenByUserId { get; set; }

        [ForeignKey(nameof(GivenByUserId))]
        public User? GivenBy { get; set; }
    }
}
