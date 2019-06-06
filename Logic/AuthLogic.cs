using Data;
using Data.Base;
using Logic.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IAuthLogic : IBaseLogic<User>
    {
        Task<User> Login(string Email, string Password);
        Task<bool> UserExists(string Name, string Email);
    }
    public class AuthLogic : BaseLogic<User>, IAuthLogic
    {
        protected new IAuthRepository Repository => (IAuthRepository)base.Repository;
        public AuthLogic(IAuthRepository repository) : base((IRepository<User>)repository)
        {
        }

        public async Task<User> Login(string Email, string Password)
        {
            return await Repository.Login(Email, Password);
        }

        public async Task<bool> UserExists(string Name, string Email)
        {
            return await Repository.UserExists(Name, Email);
        }
    }
}