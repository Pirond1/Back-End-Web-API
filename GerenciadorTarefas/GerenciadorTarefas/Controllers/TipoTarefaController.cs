using Dominio.DTOs;
using FluentValidation;
using Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoTarefaController : ControllerBase
    {
        private ITipoTarefaService service;
        private IValidator<TipoTarefaDTO> validator;

        private int UsuarioID => int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public TipoTarefaController(ITipoTarefaService service, IValidator<TipoTarefaDTO> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<TipoTarefaDTO>> addAsync(TipoTarefaDTO tipoTarefaDTO)
        {
            var result = validator.Validate(tipoTarefaDTO);
            if (result.IsValid)
            {
                var dto = await this.service.addAsync(tipoTarefaDTO, UsuarioID);
                return Ok(dto);
            }
            else
            {
                return BadRequest(result);
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoTarefaDTO>>> getAllAsync()
        {
            var lista = await this.service.getAllAsync(UsuarioID);
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTarefaDTO>> getAsync(int id)
        {
            var tipo = await this.service.getAsync(id, UsuarioID);
            if(tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {
            await this.service.removeAsync(id, UsuarioID);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateAsync(TipoTarefaDTO tipo)
        {
            var result = validator.Validate(tipo);
            if (result.IsValid)
            {
                await this.service.updateAsync(tipo, UsuarioID);
                return NoContent();
            }
            else
            {
                return BadRequest(result);
            }
            
        }
    }
}
