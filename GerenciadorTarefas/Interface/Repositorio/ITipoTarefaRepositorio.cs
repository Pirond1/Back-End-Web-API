using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositorio
{
    public interface ITipoTarefaRepositorio
    {
        Task<TipoTarefa> addAsync(TipoTarefa tipoTarefa);
        Task<IEnumerable<TipoTarefa>> getAllAsync(Expression<Func<TipoTarefa, bool>> expression);
        Task<TipoTarefa?> getAsync(int id);
        Task removeAsync(TipoTarefa tipoTarefa);
        Task updateAsync(TipoTarefa tipoTarefa);
    }
}
