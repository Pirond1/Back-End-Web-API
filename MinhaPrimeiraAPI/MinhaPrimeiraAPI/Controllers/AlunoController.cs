using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraAPI.Data;
using MinhaPrimeiraAPI.Model;

namespace MinhaPrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private EscolaContext _context;

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<List<AlunoModel>>> listar()
        {
            // Select * From Alunos
            return await _context.alunos.ToListAsync();
        }

        [HttpPost("Inserir")]
        public async Task<ActionResult<AlunoModel>> inserir(AlunoModel model)
        {
            // Insert
            await _context.alunos.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<ActionResult> excluir(int id)
        {
            // Delete From Alunos Where id=id
            var obj = await _context.alunos.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.alunos.Remove(obj);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

        [HttpGet("Recuperar/{id}")]
        public async Task<ActionResult<AlunoModel>> recuperar(int id)
        {
            // Select * From Alunos Where id=id
            var obj = await _context.alunos.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return obj;
            }
        }
    }
}
