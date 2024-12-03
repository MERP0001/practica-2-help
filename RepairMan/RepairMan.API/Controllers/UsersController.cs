using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.Business.Common;
using RepairMan.DataClasses.Common;
using RepairMan.Services.Common;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserControlLogic _userControlLogic;
        private readonly IUserService _service;

        public UsersController(IUserControlLogic userControlLogic, IUserService userService)
        {
            _userControlLogic = userControlLogic;
            _service = userService;
        }

        /// <summary>
        /// Retorna un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Un usuario</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _service.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Permite crear un usuario
        /// </summary>
        /// <param name="user">Un usuario</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try { 
                var createdUser = _userControlLogic.Create(user);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }


        /// <summary>
        /// Permite actualizar un usuario
        /// </summary>
        /// <param name="id">Id del usuario a actualizar</param>
        /// <param name="user">Un usuario</param>
        /// <returns></returns>
        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult UpdateUser(Guid id, User user)
        {
            var identifiedUser = _userControlLogic.GetUserByIdentity(User.Identity);
            if(!identifiedUser.Roles.Contains(UserRole.Administrator) && (identifiedUser.UserId != user.UserId || id != identifiedUser.UserId))
            {
                return Unauthorized();
            }
            try
            {
                _userControlLogic.UpdateUser(user);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}