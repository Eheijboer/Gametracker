using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Base
{
    public interface IShopRepository
    {
    }
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
