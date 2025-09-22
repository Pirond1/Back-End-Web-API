using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repositorio
{
    public interface ILoginRepositorio
    {
        Task<Login> addAsync(Login login);
        Task removeAsync(Login login);
        Task<Login?> getAsync(int id);
        Task<IEnumerable<Login>> getAllAsync(Expression<Func<Login, bool>> expression);
        Task updateAsync(Login login);
    }
}
