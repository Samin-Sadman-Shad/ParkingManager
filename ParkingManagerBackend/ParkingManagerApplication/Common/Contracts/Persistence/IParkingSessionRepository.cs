using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagerDomain.Domains;
using ParkingManagerDomain.Enums;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IParkingSessionRepository:IGenericRepository<ParkingSession>
    {
        //user-> booking-> parking session
        Task<IEnumerable<ParkingSession>> GetByUserIdAsync(Guid userId); 
        
        //parking session -> booking -> parkingspot -> garage
        Task<IEnumerable<ParkingSession>> GetActiveSessionsByGarageIdAsync(Guid garageId);

        //vehicle -> booking -> parking session
        Task<IEnumerable<ParkingSession>> GetByVehicleIdAsync(Guid vehicleId);

        Task<IEnumerable<ParkingSession>> GetAvailableSessionsByDateAsync(Guid garageId, 
        DateOnly date);

        Task<IEnumerable<ParkingSession>> GetAvailableSessionByTimeRangeAsync(
            Guid garageId,
            DateTimeOffset startTime,
            DateTimeOffset endTime);


        Task<IEnumerable<ParkingSession>> FilterByPaymentStatusAsync(PaymentStatus paymentStatus);

        Task<IEnumerable<ParkingSession>> GetUnpaidSessionsAsync(Guid garageId);
        Task<IEnumerable<ParkingSession>> FilterByStatusAsync(SessionStatus status);

        Task<ParkingSession?> GetWithBookingDetailsAsync(Guid sessionId);
    }
}
