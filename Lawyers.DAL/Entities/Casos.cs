using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("Casos", Schema ="dbo")]
    public class Casos
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("FechaCaso")]
        public DateTime FechaCaso { get; set; }
        [Column("AbogadoId")]
        public int? IdAbogado { get; set; }
        [Column("ClienteId")]
        public int? IdCliente { get; set; }
        [Column("Estado")]
        public int? IdEstadoCaso { get; set; }
        [Column("TipoCaso")]
        public int? IdTipoCaso { get; set; }
        [Column("Latitud")]
        public string? Latitud { get; set; }
        [Column("Longitud")]
        public string? Longitud { get; set; }
        [Column("Descripcion")]
        public string? Descripcion { get; set; }
    }
}
