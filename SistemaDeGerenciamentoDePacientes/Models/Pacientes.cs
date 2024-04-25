namespace SistemaDeGerenciamentoDePacientes.Models
{
    public class Pacientes
    {
        public int? id { get; set; }
        public string? nome { get; set; }
        public int? idade { get; set; }
        public char sexo { get; set; }
        public string? valorResultadoEx1 { get; set; }
        public string? valorResultadoEx2 { get; set; }
    }
}
