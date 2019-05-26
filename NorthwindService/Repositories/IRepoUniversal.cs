using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindEntityLib;

namespace NorthwindService.Repositories
{
    public interface IRepoUniversal
    {
        Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, INorthwindDb;
        Task<IEnumerable<TEntity>> ReadAllAsync<TEntity>() where TEntity : class, INorthwindDb;
        Task<TEntity> ReadAsync<TEntity>(string id) where TEntity : class, INorthwindDb;
        Task<TEntity> UpdateAsync<TEntity>(string id) where TEntity : class, INorthwindDb;
        Task<bool> DeleteAsync(string id);

    }
}
