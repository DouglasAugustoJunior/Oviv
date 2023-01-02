using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain.DTO
{
    public class UsuarioAtualizarDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MinLength(3, ErrorMessage = "O campo Nome precisa ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome precisa ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MinLength(8, ErrorMessage = "Precisa ter no mínimo 8 caracteres")]
        [MaxLength(12, ErrorMessage = "Precisa ter no máximo 12 caracteres")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Autorização")]
        public string Autorizacao { get; set; } = string.Empty;

        internal Usuario ToUsuario() =>
            new Usuario() {
                Id= Id,
                Nome= Nome,
                Senha= Senha,
                Autorizacao= Autorizacao
            };
    }
}
