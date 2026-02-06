using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IVehicleLocationRepository : IGenericRepository<VehicleLocation>
    {
        // one-to-one relationship
        Task<VehicleLocation?> GetByVehicleIdAsync(Guid vehicleId);

        // Get all vehicle locations on a specific street
        Task<IEnumerable<VehicleLocation>> GetByStreetIdAsync(Guid streetId);

        //street -> thana -> district
        Task<VehicleLocation?> GetWithFullAddressAsync(Guid vehicleLocationId);

        // vehicle details included
        Task<VehicleLocation?> GetWithVehicleAsync(Guid vehicleLocationId);

        // Update vehicle location (change street)
        Task UpdateLocationAsync(Guid vehicleId, Guid streetId);

        // Get nearby vehicles on the same street
        Task<IEnumerable<VehicleLocation>> GetNearbyVehiclesAsync(Guid streetId);

        Task<IEnumerable<VehicleLocation>> GetByThanaIdAsync(Guid thanaId);

        Task<IEnumerable<VehicleLocation>> GetByDistrictIdAsync(Guid districtId);

        // Search vehicle locations by address
        Task<IEnumerable<VehicleLocation>> SearchByAddressAsync(string searchTerm);
    }
}