using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.BLL.Models
{
    [Table("EstadoCivil", Schema = "dbo")]
    public class EstadoCivilModel
    {   
        public int IdEstadoCivil { get; set; }
        public string? Descripcion { get; set; }
    }
}
