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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceLogic _deviceLogic;
        private readonly IConfiguration _config;

        public DeviceController(IDeviceLogic deviceLogic, IConfiguration config)
        {
            _config = config;
            _deviceLogic = deviceLogic;
        }

        [HttpGet("GetAllDevicesByBrandId/{brandId}")]
        public async Task<IActionResult> GetAllDevicesByBrandId(int brandId)
        {
            var devices = await _deviceLogic.GetAllDevicesByBrandId(brandId);
            if (devices == null)
            {
                return NoContent();
            }

            return Ok(devices);
        }
        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetDeviceById(int deviceId)
        {
            Device device = await _deviceLogic.FindAsync(deviceId);
            if (device == null)
            {
                return NoContent();
            }

            return Ok(device);
        }

        /// <summary>
        /// Adds the User.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDevice(Device device)
        {
            await _deviceLogic.AddAsync(device);
            return CreatedAtAction(nameof(GetDeviceById),
                new { deviceId = device.Id },
                device);
        }

        // PUT: api/Device/5
        [HttpPut("{deviceId}")]
        public async Task<IActionResult> UpdateDevice(int deviceId, Device device)
        {
            Device exiDevice = await _deviceLogic.FindAsync(deviceId);
            if (exiDevice == null)
            {
                return NoContent();
            }
            _deviceLogic.Update(device);
            return Ok(device);
        }

        [HttpDelete("{deviceId}")]
        public async Task<IActionResult> DeleteDevice(int deviceId)
        {
            if (await _deviceLogic.FindAsync(deviceId) == null)
            {
                return NoContent();
            }

            await _deviceLogic.RemoveAsync(deviceId);
            return Ok();
        }
    }
}
