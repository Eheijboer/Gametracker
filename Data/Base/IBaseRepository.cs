using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(int id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task RemoveAsync(int id);
        Task Remove(TEntity entity);
    }
}
