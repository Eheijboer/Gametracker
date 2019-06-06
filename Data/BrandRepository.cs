using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetListOfBrands();
    }
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Brand>> GetListOfBrands()
        {
            return await GetDbSet<Brand>().ToListAsync();
        }
    }
}
