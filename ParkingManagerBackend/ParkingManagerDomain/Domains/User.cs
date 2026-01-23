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
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        // Navigation property for ratings given to this user
        public ICollection<UserRating>? ReceivedRatings { get; set; }

        // Navigation property for ratings given by this user
        public ICollection<Rating>? GivenRatings { get; set; }
    }
}
