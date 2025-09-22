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
    public interface ILoginService
    {
        Task<LoginDTO> addAsync(LoginDTO login);
        Task removeAsync(int id);
        Task<LoginDTO?> getAsync(int id);
        Task<IEnumerable<LoginDTO>> getAllAsync(Expression<Func<Login, bool>>expression);
        Task updateAsync(LoginDTO login);
    }
}
