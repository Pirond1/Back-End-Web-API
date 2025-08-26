﻿using Dominio.DTOs;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Service
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> addAsync(ProdutoDTO categoria);
        Task removeAsync(int id);
        Task<ProdutoDTO> getAsync(int id);
        Task<IEnumerable<ProdutoDTO>> getAllAsync(Expression<Func<Categoria, bool>> expression);
        Task updateAsync(ProdutoDTO categoria);
    }
}
