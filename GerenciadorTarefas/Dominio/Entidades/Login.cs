using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Login
    {
        public int id { get; set; }
        public string usuario { get; set; } = String.Empty;
        public string senha { get; set; } = String.Empty;
    }
}
