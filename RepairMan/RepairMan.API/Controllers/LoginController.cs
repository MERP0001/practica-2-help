using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepairMan.Business.Common;
using RepairMan.DataClasses.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserControlLogic _userControlLogic;
        private readonly IConfiguration _configuration;

        public LoginController(IUserControlLogic userControlLogic, IConfiguration configuration)
        {
            _userControlLogic = userControlLogic;
            _configuration = configuration;
        }


        /// <summary>
        /// Obtener los datos asociados al token del usuario
        /// </summary>
        /// <returns>El usuario</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAuthenticatedUser()
        {
            return Ok(_userControlLogic.GetUserByIdentity(User.Identity));
        }

        /// <summary>
        /// Retorna el token para consultas del API
        /// </summary>
        /// <param name="credentials">credenciales del usuario (Solo se requieren las propiedades usuario y clave)</param>
        /// <returns>Un token</returns>
        [HttpPost("oauth2/login/authorize")]
        public IActionResult Login(UserCredentials credentials)
        {
            var authenticatedUser = _userControlLogic.GetUserByCredentials(credentials);

            if (authenticatedUser == null || !authenticatedUser.Active)
            {
                return Unauthorized();
            }

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, authenticatedUser.UserId.ToString())
            };

            claims.AddRange(authenticatedUser.Roles.Select(x => new Claim(ClaimTypes.Role, x)));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["Authentication:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]!)), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token_type = "Bearer",
                access_token = tokenHandler.WriteToken(token)
            });
        }
    }
}
