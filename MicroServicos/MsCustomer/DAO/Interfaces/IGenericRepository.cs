using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MsCustomer.DAO
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IList<TEntity> Find(Func<TEntity, bool> predicate);
        void Create(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(TEntity id);
    }
}