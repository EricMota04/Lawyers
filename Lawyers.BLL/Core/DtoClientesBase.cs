using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Core
{
    public class DtoClientesBase : DtoPersona
    {
        public string? Cedula { get; set; }
        public string? correo { get; set; }
        public string? Telefono { get; set; }
        public string? celular { get; set; }
        public string? Direccion { get; set; }
        public int? IdEstadoCivil { get; set; }

    }
}
