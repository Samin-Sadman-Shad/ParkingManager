using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task DeleteAllAsync();

        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> IsExistAsync(Guid id);
    }
}
