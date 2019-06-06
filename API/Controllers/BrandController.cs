using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandLogic _brandLogic;
        private readonly IConfiguration _config;

        public BrandController(IBrandLogic brandLogic, IConfiguration config)
        {
            _config = config;
            _brandLogic = brandLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrand()
        {
            var brands = await _brandLogic.GetListOfBrands();
            if (brands == null)
            {
                return NoContent();
            }

            return Ok(brands);
        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            Brand brand = await _brandLogic.FindAsync(brandId);
            if (brand == null)
            {
                return NoContent();
            }

            return Ok(brand);
        }

        /// <summary>
        /// Adds the User.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            await _brandLogic.AddAsync(brand);
            return CreatedAtAction(nameof(GetBrandById),
                new { brandId = brand.Id },
                brand);
        }

        // PUT: api/User/5
        [HttpPut("{brandId}")]
        public async Task<IActionResult> UpdateBrand(int brandId, Brand brand)
        {
            Brand exiBrand = await _brandLogic.FindAsync(brandId);
            if (exiBrand == null)
            {
                return NoContent();
            }
            _brandLogic.Update(brand);
            return Ok(brand);
        }

        [HttpDelete("{brandId}")]
        public async Task<IActionResult> DeleteaBrand(int brandId)
        {
            if (await _brandLogic.FindAsync(brandId) == null)
            {
                return NoContent();
            }

            await _brandLogic.RemoveAsync(brandId);
            return Ok();
        }
    }
}
