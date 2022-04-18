using Microsoft.EntityFrameworkCore;
using VotacaoConsumer.Core.Domain;
using VotacaoConsumer.Core.Repositories;

namespace VotacaoConsumer.Persistence.Repositories
{
    public class ParticipanteRepository : Repository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(VotacaoContext context) : base(context)
        {
        }

        public VotacaoContext VotacaoContext
        {
            get { return Context as VotacaoContext; }
        }
    }
}