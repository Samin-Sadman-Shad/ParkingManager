using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IStreetRepository : IGenericRepository<Street>
    {
        
        Task<IEnumerable<Street>> GetByThanaIdAsync(Guid thanaId);

        // Get street with child streets (hierarchical)
        Task<Street?> GetWithChildStreetsAsync(Guid streetId);

        Task<Street?> GetByPostalCodeAsync(string postalCode);


        // Get street by name within a thana
        Task<Street?> GetByNameAsync(string name, Guid thanaId);

        
        Task<Street?> GetByNameBanglaAsync(string nameBangla, Guid thanaId);

        // Search streets by name (English or Bangla)
        Task<IEnumerable<Street>> SearchStreetsAsync(string searchTerm, Guid? thanaId = null);

        // Get street with complete hierarchy (parent, thana, district)
        Task<Street?> GetWithCompleteHierarchyAsync(Guid streetId);

        
        Task<IEnumerable<(Street Street, int GarageCount)>> GetStreetsWithGarageCountAsync(Guid thanaId);

        
        Task<IEnumerable<Street>> GetActiveStreetsByThanaAsync(Guid thanaId);
    }
}