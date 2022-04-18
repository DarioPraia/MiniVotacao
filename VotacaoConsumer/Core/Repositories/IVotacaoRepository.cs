using VotacaoConsumer.Core.Domain;

namespace VotacaoConsumer.Core.Repositories
{
    public interface IVotacaoRepository : IRepository<Votacao>
    {
        void Votar(Participante participante, DateTime dataVotacao);
    }
}