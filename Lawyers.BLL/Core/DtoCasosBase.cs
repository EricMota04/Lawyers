using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Core
{
    public class DtoCasosBase
    {
        public int Id { get; set; }
        public DateTime FechaCaso { get; set; }
        public int? IdAbogado { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEstadoCaso { get; set; }
        public int? IdTipoCaso { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public string? Descripcion { get; set; }
    }
}
