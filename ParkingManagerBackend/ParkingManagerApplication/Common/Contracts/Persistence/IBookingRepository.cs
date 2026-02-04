using ParkingManagerDomain.Domains;
using ParkingManagerDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetByUserIdAsync(Guid UserId);  //user's booking
        Task<IEnumerable<Booking>> GetByGarageIdAsync(Guid GarageId);  

        Task<IEnumerable<Booking>> GetBySpotIdAsync(Guid SpotId); //user's active booking

        Task<IEnumerable<Booking>> GetAvailableBookingsByGarageIdAsync(Guid GarageId, DateOnly Date);

        Task<IEnumerable<Booking>> GetBookedSlotsByGarageIdAsync(Guid GarageId, DateOnly Date);

        Task<IEnumerable<Booking>> GetByVehicleIdAsync(Guid VehicleId);

        Task<IEnumerable<Booking>> FilterByStatusAsync(BookingStatus status);
    }
}
