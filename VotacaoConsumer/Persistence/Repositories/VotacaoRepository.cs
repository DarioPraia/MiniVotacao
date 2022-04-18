using Microsoft.EntityFrameworkCore;
using VotacaoConsumer.Core.Domain;
using VotacaoConsumer.Core.Repositories;

namespace VotacaoConsumer.Persistence.Repositories
{
    public class VotacaoRepository : Repository<Votacao>, IVotacaoRepository
    {
        public VotacaoRepository(VotacaoContext context) : base(context)
        {
        }

        public void Votar(Participante participante, DateTime dataVotacao)
        {
            VotacaoContext.Votacoes.Add(
                new Votacao() {
                    Data = dataVotacao,
                    Participante = participante,
                    ParticipanteId = participante.Id
                }
            );
        }

        public VotacaoContext VotacaoContext
        {
            get { return Context as VotacaoContext; }
        }
    }
}