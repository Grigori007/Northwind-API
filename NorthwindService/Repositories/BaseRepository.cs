using NorthwindContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly NorthwindDbContext dbContext;

        public BaseRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        #region CRUD Methods
        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public Task<TEntity> GetAsync(int id)
        {
            return dbContext.Set<TEntity>().FindAsync(id);
        }


        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run<IEnumerable<TEntity>>(() => dbContext.Set<TEntity>().ToList());    
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run<IEnumerable<TEntity>>(() => dbContext.Set<TEntity>().Where(predicate));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }


        public void Add(TEntity entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public Task AddAsync(TEntity entity)
        {
            return Task.Run(() => 
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();
            });
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.AddRange(entities);
            dbContext.SaveChanges();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return Task.Run(() =>
            {
                AddRange(entities);
            });
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.Run(() =>
            {
                Update(entity);
            });
        }

        public bool Remove(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Remove(entity);
            int changedEntities = dbContext.SaveChanges();
            if (changedEntities == 1)
            {
                return true;
            }
            return false;
        }

        public Task<bool> RemoveAsync(int id)
        {
            return Task.Run(() => 
            {
                var entity = dbContext.Set<TEntity>().Find(id);
                dbContext.Remove(entity);
                int changedEntities = dbContext.SaveChanges();
                if (changedEntities == 1)
                {
                    return true;
                }
                return false;
            });
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            return Task.Run(() => 
            {
                RemoveRange(entities);
            });
        }
        #endregion


        #region OtherMethods

        #endregion
    }
}
