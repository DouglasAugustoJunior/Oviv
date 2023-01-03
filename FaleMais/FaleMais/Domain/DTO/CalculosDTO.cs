using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain.DTO
{
    public sealed class CalculosDTO
    {
        [Required(ErrorMessage = "Preencha o campo Origem")]
        [Range(1, int.MaxValue, ErrorMessage = "Preencha um valor válido para o campo Origem")]
        public int OrigemId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Destino")]
        [Range(1, int.MaxValue, ErrorMessage = "Preencha um valor válido para o campo Destino")]
        public int DestinoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo o campo Quantidade Minutos")]
        [Range(1, int.MaxValue, ErrorMessage = "Preencha um valor válido para o campo Quantidade Minutos")]
        public int QtdeMin { get; set; }
    }
}
