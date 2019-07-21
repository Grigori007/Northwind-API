using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindEntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly NorthwindDbContext _dbContext;

        public BaseRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region CRUD Methods
        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run<IEnumerable<TEntity>>(() => _dbContext.Set<TEntity>().Where(predicate));
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.AddRange(entities);
            _dbContext.SaveChanges();
            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            //_dbContext.Set<TEntity>().Update(entity);
            //_dbContext.SaveChanges();
            //return entity;
            var existingEntity = _dbContext.Set<TEntity>().Find(entity.EntityId);
            if(existingEntity == null)
            {
                return null;
            }
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return existingEntity;
        }

        //public virtual async Task UpdateAsync(TEntity entity)
        //{
        //    await _dbContext.Set<TEntity>().UpdateAsync()
        //}

        public virtual bool Remove(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            _dbContext.Remove(entity);
            int changedEntities = _dbContext.SaveChanges();
            if (changedEntities == 1)
            {
                return true;
            }
            return false;
        }

        public virtual async Task<bool> RemoveAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Remove(entity);
            int changedEntities = await _dbContext.SaveChangesAsync();
            if (changedEntities == 1)
            {
                return true;
            }
            return false;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
        #endregion


        #region OtherMethods

        #endregion
    }
}
