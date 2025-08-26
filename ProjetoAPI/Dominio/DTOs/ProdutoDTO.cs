using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class ProdutoDTO
    {
        public int id { get; set; }
        public string descricao { get; set; } = String.Empty;
        public decimal valor { get; set; }
        public int quantidade { get; set; }

        public int idCategoria { get; set; }
        [JsonIgnore]
        public virtual CategoriaDTO? Categoria { get; set; }
    }
}
