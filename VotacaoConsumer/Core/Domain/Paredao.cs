using System.ComponentModel.DataAnnotations.Schema;

namespace VotacaoConsumer.Core.Domain
{
    public class Paredao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Data { get; set; }
    }
}