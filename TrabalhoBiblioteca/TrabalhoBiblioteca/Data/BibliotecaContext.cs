using Microsoft.EntityFrameworkCore;
using TrabalhoBiblioteca.Model;

namespace TrabalhoBiblioteca.Data
{
    public class BibliotecaContext: DbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LivroModel> livros { get; set; }
    }
}
