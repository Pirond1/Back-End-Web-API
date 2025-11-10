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
        Task<TarefaDTO> addAsync(TarefaDTO tarefa, int userID);
        Task<IEnumerable<TarefaDTO>> getAllAsync(int userID, int? idTipoTarefa);
        Task<TarefaDTO?> getAsync(int id, int userID);
        Task updateAsync(TarefaDTO tarefa, int userID);
        Task removeAsync(int id, int userID);
    }
}
