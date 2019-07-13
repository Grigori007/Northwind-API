using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NorthwindService.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        bool Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
