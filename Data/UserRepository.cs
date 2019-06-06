﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IUserRepository
    {
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
