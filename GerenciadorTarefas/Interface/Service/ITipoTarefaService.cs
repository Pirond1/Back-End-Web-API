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
    public interface ITipoTarefaService
    {
        Task<TipoTarefaDTO> addAsync(TipoTarefaDTO tipoTarefa, int userID);
        Task<IEnumerable<TipoTarefaDTO>> getAllAsync(int userID);
        Task<TipoTarefaDTO?> getAsync(int id, int userID);
        Task updateAsync(TipoTarefaDTO tipoTarefa, int userID);
        Task removeAsync(int id, int userID);
    }
}
