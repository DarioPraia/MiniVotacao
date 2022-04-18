using VotacaoConsumer.Core;
using VotacaoConsumer.Core.Repositories;
using VotacaoConsumer.Persistence.Repositories;

namespace VotacaoConsumer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IVotacaoRepository Votacoes { get; private set; }

        public IParticipanteRepository Participantes { get; private set; }

        private readonly VotacaoContext _context;

        public UnitOfWork(VotacaoContext context)
        {
            _context = context;

            Participantes = new ParticipanteRepository(_context);
            Votacoes = new VotacaoRepository(_context);

            _context.Database.EnsureCreated();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}