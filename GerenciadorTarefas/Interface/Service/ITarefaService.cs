using Dominio.DTOs;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Service
{
    public interface ITarefaService
    {
        Task<TarefaDTO> addAsync(TarefaDTO tarefa);
        Task<IEnumerable<TarefaDTO>> getAllAsync(Expression<Func<Tarefa, bool>> expression);
        Task<TarefaDTO?> getAsync(int id);
        Task updateAsync(TarefaDTO tarefa);
        Task removeAsync(int id);
    }
}
