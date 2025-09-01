using Dominio.Entidades;
using Infraestrutura.Data;
using Interface.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class TipoTarefaRepositorio : ITipoTarefaRepositorio
    {
        private ContextoGerenciador contexto;

        public TipoTarefaRepositorio(ContextoGerenciador contexto)
        {
            this.contexto = contexto;
        }

        public async Task<TipoTarefa> addAsync(TipoTarefa tipoTarefa)
        {
            await this.contexto.TipoTarefa.AddAsync(tipoTarefa);
            await this.contexto.SaveChangesAsync();
            return tipoTarefa;
        }

        public async Task<IEnumerable<TipoTarefa>> getAllAsync(Expression<Func<TipoTarefa, bool>> expression)
        {
            return await this.contexto.TipoTarefa.Where(expression).OrderBy(p => p.id).ToListAsync();
        }

        public async Task<TipoTarefa?> getAsync(int id)
        {
            return await this.contexto.TipoTarefa.FindAsync(id);
        }

        public async Task removeAsync(TipoTarefa tipoTarefa)
        {
            this.contexto.TipoTarefa.Remove(tipoTarefa);
            await this.contexto.SaveChangesAsync();
        }

        public async Task updateAsync(TipoTarefa tipoTarefa)
        {
            this.contexto.Entry(tipoTarefa).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
