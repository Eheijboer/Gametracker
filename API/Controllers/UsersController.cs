using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IConfiguration _config;
 
        public UsersController(IUserLogic userLogic, IConfiguration config)
        {
            _config = config;
            _userLogic = userLogic;
        }
        // GET: api/Users
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            User user = await _userLogic.FindAsync(userId);
            if (user == null)
            {
                return NoContent();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userLogic.AddAsync(user);
            return CreatedAtAction(nameof(GetUserById),
                new { userId = user.Id },
                user);
        }

        //PUT: api/User/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, User user)
        {
            User exiUser = await _userLogic.FindAsync(userId);
            if(exiUser == null)
            {
                return NoContent();
            }
            _userLogic.Update(user);
            return Ok(user);
        }
      [HttpDelete("{userId}")]
      public async Task<IActionResult> DeleteUser(int userId)
        {
            if(await _userLogic.FindAsync(userId) == null)
            {
                return NoContent();
            }
            await _userLogic.RemoveAsync(userId);
            return Ok();
        }
    }
}
