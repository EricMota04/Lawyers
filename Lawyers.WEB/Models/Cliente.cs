namespace Lawyers.WEB.Models
{
    public class Cliente : Base.Persona
    {
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public int IdEstadoCivil { get; set; }
    }
}
