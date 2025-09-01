using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class TarefaDTO
    {
        public int id { get; set; }
        public string titulo { get; set; } = String.Empty;
        public string descricao { get; set; } = String.Empty;
        public bool status { get; set; }
        public DateTime? DataVencimento { get; set; }

        public int idTipoTarefa { get; set; }
        public virtual TipoTarefaDTO? tipotarefa { get; set; }
    }
}
