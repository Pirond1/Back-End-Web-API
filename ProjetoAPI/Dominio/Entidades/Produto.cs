using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; } = String.Empty;
        public decimal valor { get; set; }
        public int quantidade { get; set; }

        public int idCategoria {  get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}
