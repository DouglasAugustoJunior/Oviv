using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Preencha o campo usuário")]
        [MinLength(3, ErrorMessage = "O campo usuário precisa ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo usuário precisa ter no máximo 100 caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MinLength(8, ErrorMessage = "O campo Senha precisa ter no mínimo 8 caracteres")]
        [MaxLength(12, ErrorMessage = "O campo Senha precisa ter no máximo 12 caracteres")]
        public string Senha{ get; set; }
    }
}
