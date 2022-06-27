using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Lab2.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> Get(int? id);

        Task<IEnumerable<TEntity>> GetAll(string? includeProperties = null);

        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        public void Add(TEntity entity);

        public void Remove(TEntity entity);

        public bool CheckIfExists(Expression<Func<TEntity, bool>> predicate);
    }
}
