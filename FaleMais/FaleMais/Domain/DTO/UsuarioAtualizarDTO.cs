using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain.DTO
{
    public sealed class UsuarioAtualizarDTO: UsuarioCadastrarDTO
    {
        [Required]
        public int Id { get; set; }

        public Usuario ToUsuario() =>
            new Usuario() {
                Id= Id,
                Nome= Nome,
                Senha= Senha,
                Autorizacao= Autorizacao
            };
    }
}
