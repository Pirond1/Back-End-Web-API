using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class TipoTarefaDTO
    {
        public int id { get; set; }
        public string nome { get; set; } = String.Empty;
        public string cor { get; set; }
    }
}
