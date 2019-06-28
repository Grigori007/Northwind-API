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
        private static ConcurrentDictionary<int, TEntity> cacheMemory;

        public RepoUniversal(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            if (cacheMemory == null)
            {
                cacheMemory = new ConcurrentDictionary<int, TEntity>
                    (dbContext.Set<TEntity>().ToDictionary(t => t.EntityID));
            }
        }


        #region CRUD Methods
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            EntityEntry<TEntity> added = await dbContext.Set<TEntity>().AddAsync(entity);
            int changed = await dbContext.SaveChangesAsync();
            
            if(changed == 1)
            {
                return cacheMemory.AddOrUpdate(entity.EntityID, entity, UpdateCacheMemory);
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.Run(() => {
                TEntity entity = dbContext.Set<TEntity>().Find(id);
                dbContext.Remove(entity);
                int changed = dbContext.SaveChanges();
                if (changed == 1)
                {
                    return Task.Run(() => cacheMemory.TryRemove(id, out entity));
                }
                else
                {
                    return null;
                }
            });
        }


        public async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            return await Task.Run<IEnumerable<TEntity>>(() => cacheMemory.Values);
        }


        public async Task<TEntity> ReadAsync(int id)
        {
            return await Task.Run(() => {
                TEntity entity;
                cacheMemory.TryGetValue(id, out entity);
                return entity;
            });
        }


        public async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            return await Task.Run(() => {
                dbContext.Set<TEntity>().Update(entity);
                int changed = dbContext.SaveChanges();
                if(changed == 1)
                {
                    return Task.Run(() => UpdateCacheMemory(id, entity));
                }
                return null;
            });
        }
        #endregion


        #region OtherMethods
        private TEntity UpdateCacheMemory(int id, TEntity entity)
        {
            TEntity oldEntity;
            if(cacheMemory.TryGetValue(id, out oldEntity))
            {
                if(cacheMemory.TryUpdate(id, entity, oldEntity))
                {
                    return entity;
                }
            }
            return null;
        }
        #endregion
    }
}
