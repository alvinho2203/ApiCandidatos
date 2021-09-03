using System.Data.Entity;

namespace ApiCandidatos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("CandidatosContext")
        { }
        public DbSet<Candidatos> Candidatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }


}