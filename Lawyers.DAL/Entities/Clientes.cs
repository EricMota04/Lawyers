using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("Clientes", Schema ="dbo")]
    public class Clientes: Core.Persona
    {
        public string? Cedula { get; set; }
        public string? correo { get; set; }
        public string? Telefono { get; set; }
        public string? celular { get; set; }
        public string? Direccion { get; set; }
        public int? IdEstadoCivil { get; set; }
        
    }
}
