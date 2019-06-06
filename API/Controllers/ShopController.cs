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
    public class ShopController : ControllerBase
    {
        private readonly IShopLogic _shopLogic;
        private readonly IConfiguration _config;

        public ShopController(IShopLogic shopLogic, IConfiguration config)
        {
            _config = config;
            _shopLogic = shopLogic;
        }
        [HttpGet("{shopId}")]
        public async Task<IActionResult> GetShopById(int shopId)
        {
            Shop shop = await _shopLogic.FindAsync(shopId);
            if (shop == null)
            {
                return NoContent();
            }

            return Ok(shop);
        }

        /// <summary>
        /// Adds the User.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddShop(Shop shop)
        {
            await _shopLogic.AddAsync(shop);
            return CreatedAtAction(nameof(GetShopById),
                new { shopId = shop.Id },
                shop);
        }

        // PUT: api/Shop/5
        [HttpPut("{shopId}")]
        public async Task<IActionResult> UpdateShop(int shopId, Shop shop)
        {
            Shop exiShop = await _shopLogic.FindAsync(shopId);
            if (exiShop == null)
            {
                return NoContent();
            }
            _shopLogic.Update(shop);
            return Ok(shop);
        }

        [HttpDelete("{shopId}")]
        public async Task<IActionResult> DeleteShop(int shopId)
        {
            if (await _shopLogic.FindAsync(shopId) == null)
            {
                return NoContent();
            }

            await _shopLogic.RemoveAsync(shopId);
            return Ok();
        }
    }
}
