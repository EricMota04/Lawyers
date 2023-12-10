using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.BLL.Models
{
    [Table("Casos", Schema ="dbo")]
    public class CasosModel
    {
        public int Id { get; set; }
        public DateOnly FechaCaso { get; set; }
        public int? IdAbogado { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEstadoCaso { get; set; }
        public int? IdTipoCaso { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public string? Descripcion { get; set; }
    }
}
