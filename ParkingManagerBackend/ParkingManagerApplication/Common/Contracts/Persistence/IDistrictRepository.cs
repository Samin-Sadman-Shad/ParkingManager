using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IDistrictRepository : IGenericRepository<District>
    {

        Task<IEnumerable<District>> GetActiveDistrictsAsync();


        Task<District?> GetWithThanasAsync(Guid districtId);

        Task<District?> GetByNameAsync(string name);


        Task<District?> GetByNameBanglaAsync(string nameBangla);


        Task<IEnumerable<District>> SearchDistrictsAsync(string searchTerm);

        // Get district with complete hierarchy (thanas with streets)
        Task<District?> GetWithCompleteHierarchyAsync(Guid districtId);

        // Get districts with garage count
        Task<IEnumerable<(District District, int GarageCount)>> GetDistrictsWithGarageCountAsync();
    }
}