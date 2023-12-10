using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.BLL.Models
{
    [Table("Abogados", Schema ="dbo")]
    public class AbogadosModel : Core.Persona
    {
        public string? correo { get; set; }
        public string? Telefono { get; set; }
        public string? celular { get; set; }
        public int? IdUsuario { get; set; }

    }
}
