using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllDevicesByBrandId(int brandId);
    }
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Device>> GetAllDevicesByBrandId(int brandId)
        {
            return await GetDbSet<Device>().Where(z => z.Brand.Id == brandId).ToListAsync();
        }
    }
}
