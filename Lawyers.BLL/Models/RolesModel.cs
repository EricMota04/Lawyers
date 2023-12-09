using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("Roles")]
    public class RolesModel
    {
        public int Id { get; set; }
        public string Rol { get; set; } = string.Empty;
    }
}
