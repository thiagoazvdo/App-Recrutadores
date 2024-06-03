namespace RecrutamentoAPI.Models
{
    public class Candidato
    {
        public int CandidatoId { get; set; }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contatos { get; set; }
        public string Habilidades { get; set; }
        public string Linkedin { get; set; }
        public bool Status { get; set; }
        public DateTime? DataContratacao { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
