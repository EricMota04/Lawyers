namespace Lawyers.WEB.Models
{
    public class Casos
    {

        public int? Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdAbogado { get; set; }
        public string? Descripcion { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? Fecha { get; set; }
        public int? TipoDeCaso{ get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }

    }
}
