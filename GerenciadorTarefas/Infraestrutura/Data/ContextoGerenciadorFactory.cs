using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestrutura.Data
{
    public class ContextoGerenciadorFactory : IDesignTimeDbContextFactory<ContextoGerenciador>
    {
        public ContextoGerenciador CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoGerenciador>();

            optionsBuilder.UseSqlServer(@"Server=localhost;
                DataBase=dbGerenciadorTarefas;
                integrated security=true;TrustServerCertificate=True;");
            return new ContextoGerenciador(optionsBuilder.Options);
        }
    }
}
