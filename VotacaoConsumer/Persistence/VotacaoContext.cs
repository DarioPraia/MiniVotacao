using Microsoft.EntityFrameworkCore;
using VotacaoConsumer.Core.Domain;

namespace VotacaoConsumer.Persistence
{
    public class VotacaoContext : DbContext
    {
        public virtual DbSet<Votacao> Votacoes { get; set; }

        public virtual DbSet<Participante> Participantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=L3091DBI21\\MSSQLSERVER_NEW;Database=GloboVotacao;Trusted_Connection=True;User=developer;Password=Dapr4573d4s;");
        }
    }
}