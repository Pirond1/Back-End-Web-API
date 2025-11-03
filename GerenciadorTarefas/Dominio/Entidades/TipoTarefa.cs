using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TipoTarefa
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int idLogin { get; set; }
        public virtual Login? login { get; set; }

        public virtual List<Tarefa> tarefas { get; set; } = new List<Tarefa>();
    }
}
