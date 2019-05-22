using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Base;

namespace Logic.Base
{
    public class BaseLogic<TEntity> : IBaseLogic<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> Repository { get; }

        protected BaseLogic(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await Repository.FindAsync(id);
        }

        public virtual Task AddAsync(TEntity entity)
        {
            return Repository.AddAsync(entity);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return Repository.AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity) { Repository.Update(entity); }

        public virtual void Remove(TEntity entity) { Repository.Remove(entity); }

        public virtual Task RemoveAsync(int id)
        {
            return Repository.RemoveAsync(id);
        }
    }
}
