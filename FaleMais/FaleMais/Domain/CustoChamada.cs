using Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CustoChamada : EntidadeBase
    {
        public CustoChamada() { }

        public CustoChamada(CustoChamadaCadastrarDTO dto)
        {
            OrigemId = dto.OrigemId;
            DestinoId = dto.DestinoId;
            ValorPorMin = dto.ValorPorMin;
        }

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
