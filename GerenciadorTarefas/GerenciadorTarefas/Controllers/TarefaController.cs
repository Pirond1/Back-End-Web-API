using Dominio.DTOs;
using Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private ITarefaService service;

        public TarefaController(ITarefaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TarefaDTO>> addAsync(TarefaDTO tarefaDTO)
        {
            var dto = await this.service.addAsync(tarefaDTO);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaDTO>>> getAllAsync()
        {
            var lista = await this.service.getAllAsync(p => true);
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDTO>> getAsync(int id)
        {
            var tarefa = await this.service.getAsync(id);
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
            await this.service.removeAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateAsync(TarefaDTO tar)
        {
            await this.service.updateAsync(tar);
            return NoContent();
        }
    }
}
