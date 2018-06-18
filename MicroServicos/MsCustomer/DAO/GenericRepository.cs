using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MsCustomer.DAO
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
            where TEntity : class
    {
        private readonly CatalogContext _dbContext;

        public GenericRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = GetAll();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    result = result.Include(include);
                }
            }
            return result.FirstOrDefault(predicate);
        }

        public IList<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>()
                        .Where(predicate)
                        .ToList();
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
