using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindContextLib;
using NorthwindEntityLib;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NorthwindService.Repositories
{
    public class RepoUniversal<TEntity> : IRepoUniversal<TEntity> where TEntity : class, INorthwindDb
    {
        // TODO: string may not work as in ID for all NorthwindDB enitites 
        private readonly NorthwindDbContext dbContext;
        // Scoped or Transient for cache memory ????
        private static ConcurrentDictionary<string, TEntity> cacheMemory;

        public RepoUniversal(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            //if (cacheMemory == null)
            //{
            //    cacheMemory = new ConcurrentDictionary<string, TEntity>
            //        (dbContext.Set<TEntity>)
            //}
        }

        #region CRUD Methods
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            // TODO: normalise ID to string -> capital letters only
            EntityEntry<TEntity> added = await dbContext.Set<TEntity>().AddAsync(entity);
            int changed = await dbContext.SaveChangesAsync();
            // TODO: int changed left for an implementation of concurrent dictionary (cache memory)
            return entity;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            return await Task.Run(() =>
            {
                return dbContext.Set<TEntity>().ToList();
            });
        }


        public async Task<TEntity> ReadAsync(string id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() => {
                dbContext.Set<TEntity>().Update(entity);
                dbContext.SaveChanges();
                return entity; // TODO: remove this after cache memory implementation
            });
        }
        #endregion
    }
}
