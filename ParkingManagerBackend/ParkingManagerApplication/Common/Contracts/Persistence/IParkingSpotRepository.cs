using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagerDomain.Domains;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
   public interface IParkingSpotRepository:IGenericRepository<ParkingSpot>
    {
        Task<IEnumerable<ParkingSpot>> GetByGarageIdAsync(Guid garageId);
        Task<IEnumerable<ParkingSpot>> GetByFloorAsync(Guid garageId, int floorNo);

        Task<IEnumerable<ParkingSpot>> GetAvailableSpotsAsync(Guid garageId, 
            DateTimeOffset start, 
            DateTimeOffset end); //check against bookings

        Task<ParkingSpot?> GetWithBookingsAsync(Guid spotId); //include bookings

        Task<bool> IsSpotAvailableAsync(Guid spotId, 
            DateTimeOffset start, 
            DateTimeOffset end); //check against bookings

        
    }
}
