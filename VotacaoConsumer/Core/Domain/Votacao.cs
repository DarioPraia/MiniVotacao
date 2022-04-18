using System.ComponentModel.DataAnnotations.Schema;

namespace VotacaoConsumer.Core.Domain
{
    public class Votacao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Participante Participante { get; set; }
        public int ParticipanteId { get; set; }
        public DateTime Data { get; set; }
    }
}