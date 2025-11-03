using Dominio.DTOs;
using FluentValidation;
using Interface.Service;
using Microsoft.AspNetCore.Authorization;
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
    public class LoginController : ControllerBase
    {
        private ILoginService service;
        private IValidator<LoginDTO> validator;
        private IConfiguration _config;

        public LoginController(ILoginService service, IValidator<LoginDTO> validator, IConfiguration config)
        {
            this.service = service;
            this.validator = validator;
            this._config = config;
        }

        [HttpPost]
        public async Task<ActionResult<LoginDTO>>addAsync(LoginDTO login)
        {

            var result = validator.Validate(login);
            if (result.IsValid)
            {
                var dto = await this.service.addAsync(login);
                return Ok(dto);
            }
            else
                return BadRequest(result);


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDTO>>>getAllAsync()
        {
            var lista = await this.service.getAllAsync(p => true);
            return Ok(lista);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDTO>>getAsync(int id)
        {
            var login = await this.service.getAsync(id);
            if (login == null)
                return NotFound();
            else
                return Ok(login);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {

            await this.service.removeAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> updateAsync(LoginDTO login)
        {
            var result = validator.Validate(login);
            if (result.IsValid)
            {
                await this.service.updateAsync(login);
                return NoContent();
            }
            else return BadRequest(result);

        }

        [HttpPost("Auth")]
        public async Task<ActionResult> auth(LoginDTO login)
        {
            var result = validator.Validate(login);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            var usuario = await this.service.AutenticarAsync(login);

            if (usuario != null)
            {
                var tokenString = GerarTokenJWT(usuario);

                return Ok(new
                {
                    acces_token = tokenString,
                    token_type = "Bearer",
                    expires_in = 60 * 60 //60 Min
                });
            }
            else
            {
                return Unauthorized("Usuário ou Senha Inválidos!");
            }
        }

        private string GerarTokenJWT(LoginDTO usuario)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.usuario),
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
    }
}
