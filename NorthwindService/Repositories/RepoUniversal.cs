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
        private readonly NorthwindDbContext dbContext;

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

        public async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            //return await Task<IEnumerable<TEntity>>(() => dbContext.Set<TEntity>().ToList());
            return await Task.Run(() =>
            {
                return dbContext.Set<TEntity>().ToList();
            });
        }


        public async Task<TEntity> ReadAsync(string id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }


        public Task<TEntity> UpdateAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
