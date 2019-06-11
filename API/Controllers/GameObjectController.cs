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
    public class GameObjectController : ControllerBase
    {
        private readonly IGameObjectLogic _gameobjectLogic;
        private readonly IConfiguration _config;

        public GameObjectController(IGameObjectLogic gameobjectLogic, IConfiguration config)
        {
            _config = config;
            _gameobjectLogic = gameobjectLogic;
        }
        [HttpGet]
        public async Task<IActionResult> GetGameObject()
        {
            var gameobjects = await _gameobjectLogic.GetListOfGameObjects();
            if (gameobjects == null)
            {
                return NoContent();
            }

            return Ok(gameobjects);
        }

        [HttpGet("GetListGameObjectShop/{gameobjectId}")]
        public async Task<IActionResult> GetListGameObjectShop(int gameobjectId)
        {
            var gameobjects = await _gameobjectLogic.GetListGameObjectShop(gameobjectId);
            if (gameobjects == null)
            {
                return NoContent();
            }

            return Ok(gameobjects);
        }

        [HttpGet("GetSpecificGameObjectShop/{id}")]
        public async Task<IActionResult> GetSpecificGameObjectShop(int id)
        {
            var gameobjects = await _gameobjectLogic.GetSpecificGameObjectShop(id);
            if (gameobjects == null)
            {
                return NoContent();
            }

            return Ok(gameobjects);
        }


        [HttpGet("{gameobjectId}")]
        public async Task<IActionResult> GetGameObjectById(int gameobjectId)
        {
            GameObject gameobject = await _gameobjectLogic.GetSpecificGameObject(gameobjectId);
            if (gameobject == null)
            {
                return NoContent();
            }

            return Ok(gameobject);
        }

        /// <summary>
        /// Adds the User.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddGameObject(GameObject gameobject)
        {
            await _gameobjectLogic.AddAsync(gameobject);
            return CreatedAtAction(nameof(GetGameObjectById),
                new { vId = gameobject.Id },
                gameobject);
        }

        // PUT: api/User/5
        [HttpPut("{gameobjectId}")]
        public async Task<IActionResult> UpdateGameObject(int gameobjectId, GameObject gameobject)
        {
            GameObject exiGameObject = await _gameobjectLogic.FindAsync(gameobjectId);
            if (exiGameObject == null)
            {
                return NoContent();
            }
            _gameobjectLogic.Update(gameobject);
            return Ok(gameobject);
        }

        [HttpDelete("{gameobjectId}")]
        public async Task<IActionResult> DeleteGameObject(int gameobjectId)
        {
            if (await _gameobjectLogic.FindAsync(gameobjectId) == null)
            {
                return NoContent();
            }

            await _gameobjectLogic.RemoveAsync(gameobjectId);
            return Ok();
        }
    }
}
