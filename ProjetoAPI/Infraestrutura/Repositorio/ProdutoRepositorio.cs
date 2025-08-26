using Dominio.Entidades;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class ProdutoRepositorio
    {
        private EmpresaContexto contexto;

        public ProdutoRepositorio(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Produto> addAsync(Produto produto)
        {
            await this.contexto.Produtos.AddAsync(produto);
            await this.contexto.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> getAllAsync(Expression<Func<Produto, bool>> expression)
        {
            return await this.contexto.Produtos.Where(expression).OrderBy(p => p.descricao).ToListAsync();
        }

        public async Task<Produto?> getAsync(int id)
        {
            return await this.contexto.Produtos.FindAsync(id);
        }

        public async Task removeAsync(Produto produto)
        {
            this.contexto.Produtos.Remove(produto);
            await this.contexto.SaveChangesAsync();
        }

        public async Task updateAsync(Produto produto)
        {
            this.contexto.Entry(produto).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
