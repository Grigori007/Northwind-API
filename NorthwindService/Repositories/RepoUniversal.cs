using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindContextLib;
using NorthwindEntityLib;

namespace NorthwindService.Repositories
{
    public class RepoUniversal<TEntity> : IRepoUniversal<TEntity> where TEntity : class, INorthwindDb
    {
        // TODO: Define a new type fot DB implementing INorthwind interface
        // private static ConcurrentDictionary<string, TEntity> cacheMemory 
        private NorthwindDbContext dbContext;

        public RepoUniversal(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
