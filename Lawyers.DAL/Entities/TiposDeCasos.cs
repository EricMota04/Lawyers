using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.DAL.Entities
{
    [Table("TiposDeCasos")]
    public class TiposDeCasos
    {
        public int Id { get; set; }
        public string TipoDeCaso { get; set; } = string.Empty;
    }
}
