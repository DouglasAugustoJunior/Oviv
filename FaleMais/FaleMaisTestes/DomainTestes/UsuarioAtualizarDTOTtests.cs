using FaleMais.Domain.DTO;

namespace FaleMaisTestes.DomainTestes
{
    public class UsuarioAtualizarDTOTtests
    {
        [Fact]
        public void ToUsuario_QuandoChamado_DevePreencherTodosOsCampos()
        {
            // Arrange
            var dto = new UsuarioAtualizarDTO()
            {
                Id = 1,
                Nome = "011",
                Senha = "000",
                Autorizacao = "Cliente"
            };

            // Act
            var usuario = dto.ToUsuario();

            // Assert
            Assert.Equal(usuario.Id, dto.Id);
            Assert.Equal(usuario.Nome, dto.Nome);
            Assert.Equal(usuario.Senha, dto.Senha);
            Assert.Equal(usuario.Autorizacao, dto.Autorizacao);
        }
    }
}
