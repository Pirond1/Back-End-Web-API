using Dominio.Entidades;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Interface.Repositorio;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private ContextoGerenciador contexto;

        public TarefaRepositorio(ContextoGerenciador contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Tarefa> addAsync(Tarefa tarefa)
        {
            await this.contexto.Tarefa.AddAsync(tarefa);
            await this.contexto.SaveChangesAsync();
            return tarefa;
        }

        public async Task<IEnumerable<Tarefa>> getAllAsync(Expression<Func<Tarefa, bool>> expression)
        {
            return await this.contexto.Tarefa.Where(expression).OrderBy(p => p.id).ToListAsync();
        }

        public async Task<Tarefa?> getAsync(int id)
        {
            return await this.contexto.Tarefa.FindAsync(id);
        }

        public async Task updateAsync(Tarefa tarefa)
        {
            this.contexto.Entry(tarefa).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }

        public async Task removeAsync(Tarefa tarefa)
        {
            this.contexto.Tarefa.Remove(tarefa);
            await this.contexto.SaveChangesAsync();
        }
    }
}
