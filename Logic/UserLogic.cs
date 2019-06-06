using Data.Base;
using Logic.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IUserLogic : IBaseLogic<User>
    {
    }
    public class UserLogic : BaseLogic<User>, IUserLogic
    {
        protected new IUserRepository Repository => (IUserRepository)base.Repository;
        public UserLogic(IUserRepository repository) : base((IRepository<User>)repository)
        {
        }
    }
}
