using VotacaoConsumer.Core.Repositories;

namespace VotacaoConsumer.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IVotacaoRepository Votacoes { get; }

        int Complete();
    }
}