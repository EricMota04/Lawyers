using System.ComponentModel.DataAnnotations.Schema;

namespace Lawyers.BLL.Models
{
    [Table("TiposDeCasos")]
    public class TiposDeCasosModel
    {
        public int Id { get; set; }
        public string TipoDeCaso { get; set; } = string.Empty;
    }
}
