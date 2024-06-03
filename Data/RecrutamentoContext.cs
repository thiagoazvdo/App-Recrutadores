using Microsoft.EntityFrameworkCore;
using RecrutamentoAPI.Models;

namespace RecrutamentoAPI.Data
{
    public class RecrutamentoContext : DbContext
    {
        public RecrutamentoContext(DbContextOptions<RecrutamentoContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
    }
}
