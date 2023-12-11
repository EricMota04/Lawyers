using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("Clientes", Schema ="dbo")]
    public class Clientes: Core.Persona
    {
        [Column("Cedula")]
        public string? Cedula { get; set; }
        [Column("Correo")]
        public string? correo { get; set; }
        [Column("Telefono")]
        public string? Telefono { get; set; }
        [Column("Celular")]
        public string? celular { get; set; }
        [Column("Direccion")]
        public string? Direccion { get; set; }
        [Column("EstadoCivil")]
        public int? IdEstadoCivil { get; set; }
        
    }
}
