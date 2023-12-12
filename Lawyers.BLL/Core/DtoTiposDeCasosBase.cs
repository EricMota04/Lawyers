using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Core
{
    public class DtoTiposDeCasosBase
    {
        public int Id { get; set; }
        public string TipoDeCaso { get; set; } = string.Empty;
    }
}
