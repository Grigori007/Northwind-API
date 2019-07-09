﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindContextLib;
using NorthwindEntityLib;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NorthwindService.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly NorthwindDbContext dbContext;
        private static ConcurrentDictionary<dynamic, TEntity> cacheMemory;

        public BaseRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;

            if (cacheMemory == null)
            {
                cacheMemory = new ConcurrentDictionary<dynamic, TEntity>
                    (dbContext.Set<TEntity>().ToDictionary(t => t.EntityId));
            }
        }


        #region CRUD Methods
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            EntityEntry<TEntity> added = await dbContext.Set<TEntity>().AddAsync(entity);
            int changed = await dbContext.SaveChangesAsync();
            
            if(changed == 1)
            {
                return cacheMemory.AddOrUpdate(entity.EntityId, entity, UpdateCacheMemory(entity.EntityId, entity));
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> DeleteAsync(dynamic id)
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


        public async Task<TEntity> ReadAsync(dynamic id)
        {
            return await Task.Run(() => {
                cacheMemory.TryGetValue(id, out TEntity entity);
                return entity;
            });
        }


        public async Task<TEntity> UpdateAsync(dynamic id, TEntity entity)
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
        private TEntity UpdateCacheMemory(dynamic id, TEntity entity)
        {
            if(cacheMemory.TryGetValue(id, out TEntity oldEntity))
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
