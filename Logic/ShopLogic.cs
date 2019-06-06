using Data.Base;
using Logic.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IShopLogic : IBaseLogic<Shop>
    {
    }
    public class ShopLogic : BaseLogic<Shop>, IShopLogic
    {
        protected new IShopRepository Repository => (IShopRepository)base.Repository;
        public ShopLogic(IShopRepository repository) : base((IRepository<Shop>)repository)
        {
        }
    }
}
