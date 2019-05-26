using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindContextLib;
using NorthwindEntityLib;

namespace NorthwindService.Repositories
{
    public class RepoUniversal : IRepoUniversal
    {
        // TODO: Define a new type fot DB implementing INorthwind interface
        // private static ConcurrentDictionary<string, TEntity> cacheMemory 
        private NorthwindDbContext dbContext;

        public RepoUniversal(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepoUniversal.CreateAsync<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TEntity>> IRepoUniversal.ReadAllAsync<TEntity>()
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepoUniversal.ReadAsync<TEntity>(string id)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepoUniversal.UpdateAsync<TEntity>(string id)
        {
            throw new NotImplementedException();
        }
    }
}
