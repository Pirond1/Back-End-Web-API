using Dominio.DTOs;
using Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaService service;

        public CategoriaController(ICategoriaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> addAsync(CategoriaDTO categoriaDTO)
        {
            var dto = await this.service.addAsync(categoriaDTO);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaDTO>>> getAllAsync()
        {
            var lista = await this.service.getAllAsync(p => true);
            return Ok(lista);
        }

        [HttpGet("/descricao/{descricao}")]
        public async Task<ActionResult<List<CategoriaDTO>>> getDescricaoAsync(string descricao)
        {
            var lista = await this.service.getAllAsync(p => p.descricao.Contains(descricao));
            return Ok(lista);
        }

        [HttpGet("/id/{id}")]
        public async Task<ActionResult<CategoriaDTO>> getAsync(int id)
        {
            var cat = await this.service.getAsync(id);
            if(cat == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cat);
            }
        }

        [HttpDelete("/{id}")]
        public async Task<ActionResult> deleteAsync(int id)
        {
            await this.service.removeAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> updateAsync(CategoriaDTO cat)
        {
            await this.service.updateAsync(cat);
            return NoContent();
        }
    }
}
