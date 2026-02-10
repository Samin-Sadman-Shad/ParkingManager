using Microsoft.EntityFrameworkCore;
using ParkingManagerApplication.Common.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerPersistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ParkingManagerDbContext _dbContext;
        public GenericRepository(ParkingManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            return item;
        }

        public async Task DeleteAllAsync()
        {
            var entities = await _dbContext.Set<T>().ToListAsync();
            foreach(var entity in entities)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _dbContext.FindAsync<T>(id);
            if(item is not null)
            {
                _dbContext.Set<T>().Remove(item);
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            var item = await _dbContext.FindAsync<T>(id);
            return item;
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            var item = await _dbContext.FindAsync<T>(id);
            return item is not null;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var itemTracked = _dbContext.Set<T>().Entry(item);
            itemTracked.State = EntityState.Modified;

            return item;
        }
    }
}
