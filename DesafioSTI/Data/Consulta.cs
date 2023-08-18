namespace DesafioSTI.Data
{
    public class Consulta
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string? Especialidade { get; set; }
        public bool? frequentada { get; set; }

        // Relacionamento com Doente
        public Doente Doente { get; set; }
    }
}
