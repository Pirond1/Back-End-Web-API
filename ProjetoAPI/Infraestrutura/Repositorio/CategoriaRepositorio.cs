﻿using Dominio.Entidades;
using Infraestrutura.Data;
using Interface.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private EmpresaContexto contexto;

        public CategoriaRepositorio(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Categoria> addAsync(Categoria categoria)
        {
            await this.contexto.Categorias.AddAsync(categoria);
            await this.contexto.SaveChangesAsync();
            return categoria;
        }

        public async Task<IEnumerable<Categoria>> getAllAsync(Expression<Func<Categoria, bool>> expression)
        {
            return await this.contexto.Categorias.Where(expression).OrderBy(p=>p.descricao).ToListAsync();
        }

        public async Task<Categoria?> getAsync(int id)
        {
            return await this.contexto.Categorias.FindAsync(id);
        }

        public async Task removeAsync(Categoria categoria)
        {
            this.contexto.Categorias.Remove(categoria);
            await this.contexto.SaveChangesAsync();
        }

        public async Task updateAsync(Categoria categoria)
        {
            this.contexto.Entry(categoria).State = EntityState.Modified;
            await this.contexto.SaveChangesAsync();
        }
    }
}
