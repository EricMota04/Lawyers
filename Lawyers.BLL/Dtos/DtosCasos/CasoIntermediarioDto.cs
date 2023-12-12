using Lawyers.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Dtos.DtosCasos
{
    public class CasoIntermediarioDto : DtoCasosBase
    {
        public string? NombreCliente { get; set; }
        public string? NombreAbogado { get; set; }
        public string? EstadoCaso { get; set; }
        public string? TipoCaso { get; set; }
    }
}
