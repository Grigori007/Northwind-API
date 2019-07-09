using NorthwindEntityLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> ReadAllAsync();
        Task<TEntity> ReadAsync(dynamic id);
        Task<TEntity> UpdateAsync(dynamic id, TEntity entity);
        Task<bool> DeleteAsync(dynamic id);

    }
}
