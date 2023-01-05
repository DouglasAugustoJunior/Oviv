using Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DDD : EntidadeBase
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(3, ErrorMessage = "DDD deve ter 3 caracteres")]
        public string Nome { get; set; } = string.Empty;

        public DDD(DDDCadastrarDTO dto)
        {
            Nome = dto.DDD;
        }

        public DDD() { }
    }
}
