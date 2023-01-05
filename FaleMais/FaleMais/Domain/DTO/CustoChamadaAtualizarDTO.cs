using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public sealed class CustoChamadaAtualizarDTO : CustoChamadaCadastrarDTO
    {
        [Required(ErrorMessage = "Preencha o campo ID")]
        public int Id { get; set; }

        public CustoChamada ToCustoChamada() =>
            new CustoChamada()
            {
                Id = Id,
                OrigemId = OrigemId,
                DestinoId = DestinoId,
                ValorPorMin = ValorPorMin
            };
    }
}