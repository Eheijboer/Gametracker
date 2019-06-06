using Data.Base;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data

{
    public interface IAuthRepository
    {
        Task<User> Login(string Email, string Password);
        Task<bool> UserExists(string Email, string Password);
    }
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> Login(string Email, string Password)
        {
            var user = await GetDbSet<User>().FirstOrDefaultAsync(u => u.Email == Email);

            if (user == null) return null;

            if (Password == null) return null;

            return user;
        }

        public async Task<bool> UserExists(string Name, string Email)
        {
            if (await GetDbSet<User>().AnyAsync(u => u.Name == Name || Email == u.Email)) return true;

            return false;
        }
    }
}