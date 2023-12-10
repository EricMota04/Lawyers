using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Core
{
    public class DtoAbogadoBase : DtoPersona
    {
        public string? correo { get; set; }
        public string? Telefono { get; set; }
        public string? celular { get; set; }
        public int? IdUsuario { get; set; }
    }
}
