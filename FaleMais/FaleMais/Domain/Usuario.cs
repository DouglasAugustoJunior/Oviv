using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain
{
    public class Usuario : EntidadeBase
    {
        [Required(ErrorMessage ="Preencha o campo Nome")]
        [MinLength(3,ErrorMessage = "O campo Nome precisa ter no mínimo 3 caracteres")]
        [MaxLength(100,ErrorMessage = "O campo Nome precisa ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage ="Preencha o campo Senha")]
        [MinLength(8, ErrorMessage = "O campo Senha precisa ter no mínimo 8 caracteres")]
        [MaxLength(12, ErrorMessage = "O campo Senha precisa ter no máximo 12 caracteres")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage ="Preencha o campo Autorização")]
        public string Autorizacao { get; set; } = string.Empty;
    }
}
