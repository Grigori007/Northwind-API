using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindEntityLib;

namespace NorthwindService.Repositories
{
    public interface IRepoUniversal<TEntity> where TEntity : class, INorthwindDb
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> ReadAllAsync();
        Task<TEntity> ReadAsync(int id);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);

    }
}
