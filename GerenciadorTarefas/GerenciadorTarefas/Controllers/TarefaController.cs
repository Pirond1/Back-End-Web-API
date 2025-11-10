using Dominio.DTOs;
using FluentValidation;
using Interface.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TarefaController : ControllerBase
    {
        private ITarefaService service;
        private IValidator<TarefaDTO> validator;

        private int UsuarioID => int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public TarefaController(ITarefaService service, IValidator<TarefaDTO> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<TarefaDTO>> addAsync(TarefaDTO tarefaDTO)
        {
            var dto = await this.service.addAsync(tarefaDTO, UsuarioID);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaDTO>>> getAllAsync(int? idTipoTarefa)
        {
            var lista = await this.service.getAllAsync(UsuarioID, idTipoTarefa);
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDTO>> getAsync(int id)
        {
            var tarefa = await this.service.getAsync(id, UsuarioID);
            if(tarefa == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tarefa);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {
            await this.service.removeAsync(id, UsuarioID);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateAsync(TarefaDTO tar)
        {
            await this.service.updateAsync(tar, UsuarioID);
            return NoContent();
        }
    }
}
