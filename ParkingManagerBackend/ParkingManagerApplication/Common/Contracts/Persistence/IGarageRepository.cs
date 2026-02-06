using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IGarageRepository : IGenericRepository<Garage>
    {
        
        Task<IEnumerable<Garage>> GetByOwnerIdAsync(Guid ownerId);

        
        Task<Garage?> GetWithSpotsAsync(Guid garageId);

        
        Task<Garage?> GetWithLocationAsync(Guid garageId);

        
        Task<int> GetTotalCapacityAsync(Guid garageId);

        
        Task<int> GetAvailableCapacityAsync(Guid garageId, DateTimeOffset start, DateTimeOffset end);

        //street -> garage location -> garage
        Task<IEnumerable<Garage>> GetByStreetIdAsync(Guid streetId);

        // Get active garages only
        Task<IEnumerable<Garage>> GetActiveGaragesAsync();

        // Get garage with complete details (spots, location, bookings)
        Task<Garage?> GetWithCompleteDetailsAsync(Guid garageId);

        // Get garages by district
        Task<IEnumerable<Garage>> GetByDistrictIdAsync(Guid districtId);

        // Get garages by thana
        Task<IEnumerable<Garage>> GetByThanaIdAsync(Guid thanaId);
    }
}