using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain.DTO
{
    public sealed class DDDAtualizarDTO
    {
        [Required(ErrorMessage = "Preencha o campo ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo DDD")]
        public string Nome { get; set; } = string.Empty;

        public DDD ToDDD() =>
            new DDD() {
                Id= Id,
                Nome= Nome
            };
    }
}
