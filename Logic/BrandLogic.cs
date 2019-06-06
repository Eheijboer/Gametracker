using Data.Base;
using Logic.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBrandLogic : IBaseLogic<Brand>
    {
        Task<List<Brand>> GetListOfBrands();
    }
    public class BrandLogic : BaseLogic<Brand>, IBrandLogic
    {
        protected new IBrandRepository Repository => (IBrandRepository)base.Repository;
        public BrandLogic(IBrandRepository repository) : base((IRepository<Brand>)repository)
        {
        }

        public async Task<List<Brand>> GetListOfBrands()
        {
            return await Repository.GetListOfBrands();
        }
    }
}
