using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("USUARIOS")]
    public class Usuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("UserName")]
        public string? Usuario { get; set; }
        [Column("UserPassword")]
        public string? Contrasena { get; set; }
        [Column("Rol")]
        public int RolId { get; set; }
    }
}
