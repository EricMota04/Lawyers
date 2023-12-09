using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("EstadoCivil", Schema = "dbo")]
    public class EstadoCivil
    {   
        public int IdEstadoCivil { get; set; }
        public string? Descripcion { get; set; }
    }
}
