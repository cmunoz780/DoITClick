using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Models.Security;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Doitclick.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] InfoUsuario infoUsuario)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(infoUsuario.Identificacion, infoUsuario.Llave, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuildToken(infoUsuario);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Datos de Acceso Invalidos.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(InfoUsuario infoUsuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, infoUsuario.Identificacion),
                //new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });

        }

    }
}