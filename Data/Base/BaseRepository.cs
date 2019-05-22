using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext { get; }
        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
        protected DbSet<T> GetDbSet<T>() where T : class
        {
            return DbContext.Set<T>();
        }

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Update(entity);
            DbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            TEntity entity = await FindAsync(id);
            if (entity == null) { throw new KeyNotFoundException($"Id: {id} not found"); }
            await Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached) { DbSet.Attach(entity); }
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }

}
