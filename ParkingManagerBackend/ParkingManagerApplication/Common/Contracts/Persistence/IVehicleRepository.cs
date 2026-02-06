using ParkingManagerDomain.Domains;
using ParkingManagerDomain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetByUserIdAsync(Guid userId);

        Task<Vehicle?> GetByLicensePlateAsync(string licensePlate);

        Task<bool> LicensePlateExistsAsync(string licensePlate);

        
        Task<Vehicle?> GetWithBookingsAsync(Guid vehicleId);

        Task<Vehicle?> GetWithLocationAsync(Guid vehicleId);

        // Get vehicle with complete details (user, bookings, location)
        Task<Vehicle?> GetWithCompleteDetailsAsync(Guid vehicleId);

        
        Task<IEnumerable<Vehicle>> FilterByVehicleType(EnlistedVehicles vehicleType);
        Task<IEnumerable<Vehicle>> FilterByVehicleTypeAsync(CarType vehicleType);

        Task<IEnumerable<Vehicle>> FilterByCarLevel(CarLevel carLevel);

        // Search vehicles by license plate, make, or model
        Task<IEnumerable<Vehicle>> SearchVehiclesAsync(string searchTerm);

    }
}