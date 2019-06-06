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
    }
}
