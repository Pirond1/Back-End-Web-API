using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Tarefa
    {
        public int id { get; set; }
        public string titulo { get; set; } = String.Empty;
        public string descricao { get; set; } = String.Empty;
        public bool concluido { get; set; }
        public DateTime? DataVencimento { get; set; }

        public int idTipoTarefa { get; set; }
        public int idLogin { get; set; }
        public virtual TipoTarefa? tipotarefa { get; set; }
        public virtual Login? login { get; set; }
    }
}
