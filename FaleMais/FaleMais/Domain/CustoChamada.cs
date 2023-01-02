using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain
{
    public class CustoChamada : EntidadeBase
    {
        [Required]
        public int OrigemId { get; set; }
        public DDD? Origem { get; set; }

        [Required]
        public int DestinoId { get; set; }
        public DDD? Destino { get; set; }

        [Required]
        public double ValorPorMin { get; set; }
    }
}
