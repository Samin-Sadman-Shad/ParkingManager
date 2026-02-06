using ParkingManagerDomain.Domains;
using ParkingManagerDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment?> GetByBookingIdAsync(Guid bookingId);

        Task<Payment?> GetByParkingSessionId(Guid parkingSessionId);

        Task<IEnumerable<Payment>> GetByUserIdAsync(Guid userId);

        // through booking relationship
        Task<IEnumerable<Payment>> GetByGarageIdAsync(Guid garageId);

        // through booking relationship
        Task<IEnumerable<Payment>> GetByParkingSpotIdAsync(Guid parkingSpotId);

        Task<IEnumerable<Payment>> FilterByPaymentMethodAsync(PaymentMethod paymentMethod);

        Task<IEnumerable<Payment>> FilterByMobilePaymentMethodAsync(MobilePaymentMethod mobilePaymentMethod);

        Task<IEnumerable<Payment>> FilterByPaymentStatusAsync(PaymentStatus paymentStatus);

        Task<IEnumerable<Payment>> FilterByAmountRangeAsync(decimal minAmount, decimal maxAmount);

        Task<IEnumerable<Payment>> FilterByAmountAsync(decimal amount);

        // Combined filters for more complex queries
        Task<IEnumerable<Payment>> FilterPaymentsAsync(
            Guid? userId = null,
            Guid? bookingId = null,
            Guid? garageId = null,
            Guid? parkingSpotId = null,
            PaymentMethod? paymentMethod = null,
            MobilePaymentMethod? mobilePaymentMethod = null,
            PaymentStatus? paymentStatus = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTimeOffset? startDate = null,
            DateTimeOffset? endDate = null);

        Task<IEnumerable<Payment>> FilterByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);

        // Get user payment history with pagination
        Task<IEnumerable<Payment>> GetUserPaymentHistoryAsync(Guid userId, int pageNumber = 1, int pageSize = 10);

        // Get garage payment summary
        Task<IEnumerable<Payment>> GetGaragePaymentsAsync(Guid garageId, 
            DateTimeOffset? startDate = null, DateTimeOffset? endDate = null);

        Task<decimal> GetTotalPaymentAmountByUserAsync(Guid userId);
    }
}
