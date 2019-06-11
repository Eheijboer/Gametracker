using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IGameObjectRepository
    {
        Task<List<GameObject>> GetListOfGameObjects();
        Task<List<GameObjectShop>> GetListOfGameObjectShop(int GameObjectId);
        Task<GameObjectShop> GetSpecificGameObjectShop(int id);
        Task<GameObject> GetSpecificGameObject(int GameObjectId);
    }
    public class GameObjectRepository : Repository<GameObject>, IGameObjectRepository
    {
        public GameObjectRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<GameObject>> GetListOfGameObjects()
        {
            return await GetDbSet<GameObject>()
                .Include(s => s.GameObjectShop)
                .Include(e => e.Shop)
                .Include(d => d.Device)
                .ToListAsync();
        }

        public async Task<GameObjectShop> GetSpecificGameObjectShop(int id)
        {
            return await GetDbSet<GameObjectShop>()
                .Include(s => s.Shop)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
                
        }

        public async Task<List<GameObjectShop>> GetListOfGameObjectShop(int GameObjectId)
        {
            return await GetDbSet<GameObjectShop>()
                .Include(s => s.Shop)
                .Where(i => i.GameObjectId == GameObjectId)
                .ToListAsync();
        }

        public async Task<GameObject> GetSpecificGameObject(int GameObjectId)
        {
            return await GetDbSet<GameObject>()
                .Where(e => e.Id == GameObjectId)
                .Include(s => s.GameObjectShop)
                .Include(e => e.Shop)
                .Include(d => d.Device)
                .FirstOrDefaultAsync();
        }
    }
}
