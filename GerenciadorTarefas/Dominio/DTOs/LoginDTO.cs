using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class LoginDTO
    {
        public int id { get; set; }
        public string usuario { get; set; } = String.Empty;
        public string senha { get; set; } = String.Empty;
    }
}
