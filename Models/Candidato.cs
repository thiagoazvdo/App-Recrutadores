using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecrutamentoAPI.Models
{
    public class Candidato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Contato é obrigatório")]
        public string Contatos { get; set; }

        [Required(ErrorMessage = "O campo Habilidades é obrigatório")]
        public string Habilidades { get; set; }

        [Required(ErrorMessage = "O campo Linkedin é obrigatório")]
        public string Linkedin { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório")]
        public string Status { get; set; }

        public DateTime? DataContratacao { get; set; }

        // Chave estrangeira para a tabela Empresas
        public int EmpresaId { get; set; }
     //   public Empresa Empresa { get; set; }

        public Candidato(string nome, string contatos, string habilidades, string linkedin, string status, DateTime? dataContratacao, int empresaId)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome), "Nome não pode ser nulo");
            Contatos = contatos ?? throw new ArgumentNullException(nameof(contatos), "Contatos não podem ser nulos");
            Habilidades = habilidades ?? throw new ArgumentNullException(nameof(habilidades), "Campo Habilidades não pode ser nulo");
            Linkedin = linkedin ?? throw new ArgumentNullException(nameof(linkedin), "Campo Linkedin não pode ser nulo");
            Status = status ?? throw new ArgumentNullException(nameof(status), "Campo Status não pode ser nulo");
            DataContratacao = dataContratacao;
            EmpresaId = empresaId;
        }

        // Construtor padrão necessário para o Entity Framework
        public Candidato() { }
    }
}
