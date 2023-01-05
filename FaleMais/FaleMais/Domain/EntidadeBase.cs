using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class EntidadeBase
    {
        [Required]
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataDelecao { get; set; }

        public void AdicionarDataDelecao() =>
            DataDelecao = DateTime.Now;
    }
}
