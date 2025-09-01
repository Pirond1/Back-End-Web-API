using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositorio
{
    public interface ITarefaRepositorio
    {
        Task<Tarefa> addAsync(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> getAllAsync(Expression<Func<Tarefa, bool>> expression);
        Task<Tarefa?> getAsync(int id);
        Task updateAsync(Tarefa tarefa);
        Task removeAsync(Tarefa tarefa);
    }
}
