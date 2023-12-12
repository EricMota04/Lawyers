using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("EstadosCasos", Schema ="dbo")]
    public class EstadosCasos
    {
        [Column("IdEstado")]
        public int Id { get; set; }
        [Column("Estado")]
        public string? Estado { get; set; }
    }
}
