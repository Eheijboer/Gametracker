using Data.Base;
using Logic.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IDeviceLogic : IBaseLogic<Device>
    {
        Task<List<Device>> GetAllDevicesByBrandId(int brandId);
    }
    public class DeviceLogic : BaseLogic<Device>, IDeviceLogic
    {
        protected new IDeviceRepository Repository => (IDeviceRepository)base.Repository;
        public DeviceLogic(IDeviceRepository repository) : base((IRepository<Device>)repository)
        {
        }

        public async Task<List<Device>> GetAllDevicesByBrandId(int brandId)
        {
            return await Repository.GetAllDevicesByBrandId(brandId);
        }
    }
}
