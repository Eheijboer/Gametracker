using Data.Base;
using Logic.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IGameObjectLogic : IBaseLogic<GameObject>
    {
        Task<List<GameObject>> GetListOfGameObjects();
        Task<GameObjectShop> GetSpecificGameObjectShop(int id);
        Task<List<GameObjectShop>> GetListGameObjectShop(int GameObjectId);
        Task<GameObject> GetSpecificGameObject(int GameObjectId);
    }
    public class GameObjectLogic : BaseLogic<GameObject>, IGameObjectLogic
    {
        protected new IGameObjectRepository Repository => (IGameObjectRepository)base.Repository;
        public GameObjectLogic(IGameObjectRepository repository) : base((IRepository<GameObject>)repository)
        {
        }
        public async Task<List<GameObject>> GetListOfGameObjects()
        {
            return await Repository.GetListOfGameObjects();
        }
        public async Task<GameObjectShop> GetSpecificGameObjectShop(int id)
        {
            return await Repository.GetSpecificGameObjectShop(id);
        }
        public async Task<List<GameObjectShop>> GetListGameObjectShop(int GameObjectId)
        {
            return await Repository.GetListOfGameObjectShop(GameObjectId);
        }

        public async Task<GameObject> GetSpecificGameObject(int GameObjectId)
        {
            return await Repository.GetSpecificGameObject(GameObjectId);
        }
    }
}
