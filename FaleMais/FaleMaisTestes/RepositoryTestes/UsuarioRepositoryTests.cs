using Moq;
using Domain;
using Repository;
using Domain.DTO;
using FaleMaisTestes.Utils;
using Infrastructure.Database;

namespace FaleMaisTestes.RepositoryTestes
{
    public  class UsuarioRepositoryTests
    {
        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("usuario","")]
        [InlineData("","12345678")]
        [InlineData("USUARIO","12345678")]
        [InlineData("usuário","12345678")]
        [InlineData("Usuario","12345678")]
        public void EfetuarLogin_QuandoDadosInvalidos_DeveRetornarNull(string usuario, string senha)
        {
            // Arrange
            var login = new LoginDTO()
            {
                Usuario = usuario,
                Senha = senha
            };
            var usuarioStub = MockDbSetUtil.MockDbSet(new List<Usuario>() { new Usuario() { Nome = "Usuário", Senha = "12345678" } });
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock.Setup(_ => _.Usuario).Returns(usuarioStub.Object);
            var repository = new UsuarioRepository(contextMock.Object);
            // Act
            var usuarioRetornado = repository.EfetuarLogin(login);
            // Assert
            Assert.Null(usuarioRetornado);
        }

        [Fact]
        public void EfetuarLogin_QuandoDadosValidos_DeveRetornarUsuarioCorreto()
        {
            // Arrange
            var usuarioCorreto = "Usuário";
            var senhaCorreta = "12345678";
            var login = new LoginDTO()
            {
                Usuario = usuarioCorreto,
                Senha = senhaCorreta
            };
            var usuarios = new List<Usuario>()
            {
                new Usuario() { Nome = "ceo", Senha = "sddddfdsfsd" },
                new Usuario() { Nome = "moderador", Senha = "dsddfsdfsdf" },
                new Usuario() { Nome = usuarioCorreto, Senha = senhaCorreta }
            };
            var usuarioStub = MockDbSetUtil.MockDbSet(usuarios);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock.Setup(_ => _.Usuario).Returns(usuarioStub.Object);
            var repository = new UsuarioRepository(contextMock.Object);
            // Act
            var usuarioRetornado = repository.EfetuarLogin(login);
            // Assert
            Assert.NotNull(usuarioRetornado);
            Assert.Equal(usuarioCorreto, usuarioRetornado?.Nome);
            Assert.Equal(senhaCorreta, usuarioRetornado?.Senha);
        }

        [Fact]
        public void VerificarSeJaExiste_QuandoUsuarioDeletado_DeveRetornarFalse()
        {
            // Arrange
            var usuario = "Usuário";
            var usuarios = new List<Usuario>()
            {
                new Usuario() {
                    Nome = usuario,
                    Senha = "12345678",
                    DataDelecao = DateTime.Now
                }
            };
            var usuarioStub = MockDbSetUtil.MockDbSet(usuarios);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.Usuario)
                .Returns(usuarioStub.Object);
            var repository = new UsuarioRepository(contextMock.Object);

            // Act
            var existe = repository.VerificarSeJaExiste(usuario);

            // Assert
            Assert.False(existe);
        }
    }
}
