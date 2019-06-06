using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IGameObjectRepository
    {
        Task<List<GameObject>> GetListOfGameObjects();
    }
    public class GameObjectRepository : Repository<GameObject>, IGameObjectRepository
    {
        public GameObjectRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<GameObject>> GetListOfGameObjects()
        {
            //return await GetDbSet<GameObject>().ToListAsync();
            return await GetDbSet<GameObject>().Include(s => s.GameObjectShop).Include(e => e.Shop).Include(d => d.Device).ToListAsync();
        }
    }
}
