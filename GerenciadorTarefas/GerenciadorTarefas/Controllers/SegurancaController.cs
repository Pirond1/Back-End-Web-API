using Dominio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        private IConfiguration _config;
        public SegurancaController (IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDetalhes)
        {
            bool result = ValidarUsuario(loginDetalhes);
            if (result)
            {
                var tokenString = GerarTokenJWT();
                return Ok(new
                {
                    acces_token = tokenString,
                    token_type = "Bearer",
                    expires_in = 60 * 60 //60 Min
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "1"),
                new Claim(JwtRegisteredClaimNames.UniqueName, "admin"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool ValidarUsuario(LoginDTO loginDetalhes)
        {
            if (loginDetalhes.usuario == "admin" && loginDetalhes.senha == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
