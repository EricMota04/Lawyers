using Lawyers.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Dtos.DtosClientes
{
    public class ClienteIntermediarioDto: DtoClientesBase
    {
        public string EstadoCivil { get; set; }
    }
}
