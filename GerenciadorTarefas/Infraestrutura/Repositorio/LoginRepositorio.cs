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
    public class LoginRepositorio : ILoginRepositorio
    {
        private ContextoGerenciador contexto;

        public LoginRepositorio(ContextoGerenciador contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Login> addAsync(Login login)
        {
            await this.contexto.Login.AddAsync(login);
            await this.contexto.SaveChangesAsync();
            return login;
        }

        public async Task<IEnumerable<Login>> getAllAsync(Expression<Func<Login, bool>> expression)
        {
            return await this.contexto.Login.Where(expression).Include(p => p.usuario).OrderBy(p => p.id).ToListAsync();
        }

        public async Task<Login?> getAsync(int id)
        {
            return await this.contexto.Login.Where(p => p.id == id).Include(p => p.usuario).FirstOrDefaultAsync();
        }

        public async Task removeAsync(Login login)
        {
            this.contexto.Login.Remove(login);
            await this.contexto.SaveChangesAsync();
        }

        public async Task updateAsync(Login login)
        {
            this.contexto.Entry(login).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
