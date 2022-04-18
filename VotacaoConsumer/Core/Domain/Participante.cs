using System.ComponentModel.DataAnnotations.Schema;

namespace VotacaoConsumer.Core.Domain
{
    public class Participante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}