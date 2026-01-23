using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagerDomain.Domains
{
    public class UserRating : Rating
    {
        [Required]
        public Guid GivenToUserId { get; set; }

        [ForeignKey(nameof(GivenToUserId))]
        public User? GivenTo { get; set; }
    }
}
