namespace RecrutamentoAPI.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Candidato>? Candidatos { get; set; }
    }
}
