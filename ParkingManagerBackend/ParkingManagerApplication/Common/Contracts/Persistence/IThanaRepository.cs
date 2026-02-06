using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IThanaRepository : IGenericRepository<Thana>
    {
        Task<IEnumerable<Thana>> GetByDistrictIdAsync(Guid districtId);

        Task<IEnumerable<Thana>> GetActiveThanasByDistrictAsync(Guid districtId);

        // Get thana with streets included
        Task<Thana?> GetWithStreetsAsync(Guid thanaId);

        // Get thana with parent district included
        Task<Thana?> GetWithDistrictAsync(Guid thanaId);

        // Get thana by name within a district
        Task<Thana?> GetByNameAsync(string name, Guid districtId);
        Task<Thana?> GetByNameBanglaAsync(string nameBangla, Guid districtId);

        Task<IEnumerable<Thana>> SearchThanasAsync(string searchTerm, Guid? districtId = null);

        // Get thana with complete hierarchy (district, streets)
        Task<Thana?> GetWithCompleteHierarchyAsync(Guid thanaId);

        // Get thanas with garage count
        Task<IEnumerable<(Thana Thana, int GarageCount)>> GetThanasWithGarageCountAsync(Guid districtId);
    }
}