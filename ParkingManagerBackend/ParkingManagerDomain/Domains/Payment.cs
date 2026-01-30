using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParkingManagerDomain.Enums;

namespace ParkingManagerDomain.Domains
{
    //who is making the payment, for which booking, amount, payment method, status, timestamp
    public class Payment
    {
        public Guid Id { get; set; }

        [Required]
        public Guid BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        public Booking? Booking { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public MobilePaymentMethod? MobileMethod { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public DateTimeOffset? CompletedAt { get; set; }

        public PaymentStatus Status { get; set; }

    }
}