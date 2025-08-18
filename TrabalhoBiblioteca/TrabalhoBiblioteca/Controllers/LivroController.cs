using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoBiblioteca.Data;
using TrabalhoBiblioteca.Model;

namespace TrabalhoBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private BibliotecaContext _context;

        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroModel>>> listar()
        {
            return await _context.livros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroModel>> listarId(int id)
        {
            var obj = await _context.livros.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return obj;
            }
        }

        [HttpGet("buscarISBN/{isbn}")]
        public async Task<ActionResult<LivroModel>> listarISBN(int isbn)
        {
            var obj = await _context.livros.FindAsync(isbn);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return obj;
            }
        }

        [HttpPost]
        public async Task<ActionResult<LivroModel>> inserir(LivroModel model)
        {
            await _context.livros.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        [HttpPut]
        public async Task<ActionResult<LivroModel>> atualizar(LivroModel model)
        {
            var obj = await _context.livros.FindAsync(model.id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                obj.titulo = model.titulo;
                obj.autor = model.autor;
                obj.isbn = model.isbn;
                obj.anoPublicacao = model.anoPublicacao;

                await _context.SaveChangesAsync();

                return model;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> excluir(int id)
        {
            var obj = await _context.livros.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.livros.Remove(obj);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
