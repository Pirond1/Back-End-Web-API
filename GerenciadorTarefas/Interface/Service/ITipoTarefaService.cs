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
        Task<TipoTarefaDTO> addAsync(TipoTarefaDTO tipoTarefa);
        Task<IEnumerable<TipoTarefaDTO>> getAllAsync(Expression<Func<TipoTarefa, bool>> expression);
        Task<TipoTarefaDTO?> getAsync(int id);
        Task updateAsync(TipoTarefaDTO tipoTarefa);
        Task removeAsync(int id);
    }
}
