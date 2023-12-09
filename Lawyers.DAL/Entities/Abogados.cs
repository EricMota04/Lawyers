using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("Abogados", Schema ="dbo")]
    public class Abogados : Core.Persona
    {
        public string? correo { get; set; }
        public string? Telefono { get; set; }
        public string? celular { get; set; }

    }
}
