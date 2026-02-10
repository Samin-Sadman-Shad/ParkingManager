using Microsoft.EntityFrameworkCore;
using ParkingManagerApplication.Common.Contracts.Persistence;
using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagerApplication.Common.Utils;

namespace ParkingManagerPersistence.Repositories
{
    public class GarageLocationRepository : GenericRepository<GarageLocation>, IGarageLocationRepository
    {
        public GarageLocationRepository(ParkingManagerDbContext dbContext) : base(dbContext)
        {
        }

        //district -> streets -> garage locations
        public async Task<IEnumerable<GarageLocation>> GetByDistrictIdAsync(Guid districtId)
        {
            //var district = await _dbContext.Set<District>().FindAsync(districtId);
            //var thanas = await _dbContext.Set<Thana>().Where(t => t.DistrictId == districtId).ToListAsync();

            //var streets = new List<Street>();
            //foreach(var thana in thanas)
            //{
            //    var thanaStreets = await _dbContext.Set<Street>().Where(s => s.ThanaId == thana.Id).ToListAsync();
            //    streets.AddRange(thanaStreets);
            //}

            //var garageLocs = new List<GarageLocation>();
            //foreach(var street in streets)
            //{
            //    var gls = await _dbContext.Set<GarageLocation>().Where(gl => gl.StreetId == street.Id).ToListAsync();
            //    garageLocs.AddRange(gls);
            //}
            //return garageLocs;

            return await _dbContext.Set<GarageLocation>()
                .Where(gl => gl.Street!.Thana!.DistrictId == districtId)
                .Include(gl => gl.Street)
                    .ThenInclude(s => s.Thana)
                    .ToListAsync(); // we need fulla address loaded 

        }

        public async Task<GarageLocation?> GetByGarageIdAsync(Guid garageId)
        {
            return await _dbContext.Set<GarageLocation>()
                .Where(gl => gl.GarageId == garageId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GarageLocation>> GetByPostalCodeAsync(string postalCode)
        {
            return await _dbContext.Set<GarageLocation>()
                .Where(gl => gl.Street!.PostalCode == postalCode).ToListAsync();
        }

        public async Task<IEnumerable<GarageLocation>> GetByStreetIdAsync(Guid streetId)
        {
            return await _dbContext.Set<GarageLocation>()
                .Where(gl=> gl.StreetId == streetId).ToListAsync();
        }

        public async Task<IEnumerable<GarageLocation>> GetByThanaIdAsync(Guid thanaId)
        {
            return await _dbContext.Set<GarageLocation>()
                .Where(gl => gl.Street!.ThanaId == thanaId)
                .Include(gl => gl.Street)
                    .ThenInclude(s => s.Thana)
                    .ToListAsync(); // we need fulla address loaded

        }

        public async Task<IEnumerable<GarageLocation>> GetNearbyAsync(double latitude, double longitude, double radiusKm)
        {
            //get location from latitite and longitude
            return await _dbContext.Set<GarageLocation>()
                .Where(gl => MathUtils.EquirectangularDistance(gl.Latitude, gl.Longitude, latitude, longitude) <= radiusKm)
                .ToListAsync();
        }

        public async Task<GarageLocation?> GetWithFullAddressAsync(Guid garageLocationId)
        {
            return await _dbContext.Set<GarageLocation>().
                Where(gl => gl.Id == garageLocationId).
                Include(gl => gl.Street)
                    .ThenInclude(s => s.Thana)
                    .ThenInclude(t => t.District)
                .FirstOrDefaultAsync();
        }

        public async Task<GarageLocation?> GetWithGarageAsync(Guid garageLocationId)
        {
            return await _dbContext.Set<GarageLocation>()
                .Where(gl => gl.Id == garageLocationId).
                Include(gl => gl.Garage)
                .FirstOrDefaultAsync();
                
        }

        public async Task<IEnumerable<GarageLocation>> SearchByAddressAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<GarageLocation>();
            }

            var searchPattern = $"%{searchTerm}%";
            
            return await _dbContext.Set<GarageLocation>()
                .Include(gl => gl.Street)
                    .ThenInclude(s => s!.Thana)
                    .ThenInclude(t => t!.District)
                .Where(gl => 
                    EF.Functions.Like(gl.Street!.Name, searchPattern) ||
                    EF.Functions.Like(gl.Street!.Thana!.Name, searchPattern) ||
                    EF.Functions.Like(gl.Street!.Thana!.District!.Name, searchPattern) ||
                    EF.Functions.Like(gl.Street!.PostalCode ?? string.Empty, searchPattern))
                .ToListAsync();
        }
    }
}
