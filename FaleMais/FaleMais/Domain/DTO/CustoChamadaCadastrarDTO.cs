using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class CustoChamadaCadastrarDTO
    {
        [Required(ErrorMessage = "Preencha o campo Origem")]
        [Range(1, int.MaxValue, ErrorMessage = "Preencha um valor válido para o campo Origem")]
        public int OrigemId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Destino")]
        [Range(1, int.MaxValue, ErrorMessage = "Preencha um valor válido para o campo Destino")]
        public int DestinoId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Precisa ser maior que R${1}.")]
        [Required(ErrorMessage = "Preencha o campo 'Valor Por Minuto'")]
        public double ValorPorMin { get; set; }
    }
}
