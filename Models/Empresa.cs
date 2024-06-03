namespace RecrutamentoAPI.Models
{
    public class Empresa
    {

        public int EmpresaId { get; set; }

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Candidato> Candidatos { get; set; }
    }
}
