using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Categoria
    {
        public int id { get; set; }
        public string descricao { get; set; } = String.Empty;

        public virtual List<Produto> produtos { get; set; } = new List<Produto>();
    }
}
