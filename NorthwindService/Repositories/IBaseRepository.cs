using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindEntityLib;

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
