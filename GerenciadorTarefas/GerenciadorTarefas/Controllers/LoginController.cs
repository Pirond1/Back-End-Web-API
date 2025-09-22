using Dominio.DTOs;
using FluentValidation;
using Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService service;
        private IValidator<LoginDTO> validator;

        public LoginController(ILoginService service, IValidator<LoginDTO> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
    }
}
