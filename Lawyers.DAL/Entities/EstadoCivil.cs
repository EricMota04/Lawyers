using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("EstadoCivil", Schema = "dbo")]
    public class EstadoCivil
    {
        [Key]
        public int IdEstadoCivil { get; set; }
        public string? Descripcion { get; set; }
    }
}
