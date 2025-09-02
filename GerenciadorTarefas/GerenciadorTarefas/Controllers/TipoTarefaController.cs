using Dominio.DTOs;
using Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTarefaController : ControllerBase
    {
        private ITipoTarefaService service;

        public TipoTarefaController(ITipoTarefaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TipoTarefaDTO>> addAsync(TipoTarefaDTO tipoTarefaDTO)
        {
            var dto = await this.service.addAsync(tipoTarefaDTO);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoTarefaDTO>>> getAllAsync()
        {
            var lista = await this.service.getAllAsync(p => true);
            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {
            await this.service.removeAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateAsync(TipoTarefaDTO tipo)
        {
            await this.service.updateAsync(tipo);
            return NoContent();
        }
    }
}
