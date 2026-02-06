using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IGarageLocationRepository : IGenericRepository<GarageLocation>
    {
        //  (one-to-one relationship)
        Task<GarageLocation?> GetByGarageIdAsync(Guid garageId);

        
        Task<IEnumerable<GarageLocation>> GetByStreetIdAsync(Guid streetId);

        // street -> thana
        Task<IEnumerable<GarageLocation>> GetByThanaIdAsync(Guid thanaId);

        // street -> thana -> district
        Task<IEnumerable<GarageLocation>> GetByDistrictIdAsync(Guid districtId);

       
        Task<IEnumerable<GarageLocation>> GetNearbyAsync(double latitude, double longitude, double radiusKm);

        // street -> thana -> district
        Task<GarageLocation?> GetWithFullAddressAsync(Guid garageLocationId);

        // Get garage location with garage details included
        Task<GarageLocation?> GetWithGarageAsync(Guid garageLocationId);

        // Search garage locations by address
        Task<IEnumerable<GarageLocation>> SearchByAddressAsync(string searchTerm);

        // street -> postal code
        Task<IEnumerable<GarageLocation>> GetByPostalCodeAsync(string postalCode);
    }
}