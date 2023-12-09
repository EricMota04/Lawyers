using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Core
{
    public class DtoUsuariosBase
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
        public int RolId { get; set; }
    }
}
