using NorthwindContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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


        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
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


        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.AddRange(entities);
            dbContext.SaveChanges();
        }


        public bool Remove(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            int changedEntities = dbContext.SaveChanges();
            if (changedEntities == 1)
            {
                return true;
            }
            return false;
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.RemoveRange(entities);
            dbContext.SaveChanges();
        }
        #endregion


        #region OtherMethods

        #endregion
    }
}
