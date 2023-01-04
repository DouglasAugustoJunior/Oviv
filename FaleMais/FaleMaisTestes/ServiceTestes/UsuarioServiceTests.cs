using Moq;
using FaleMais.Service;
using FaleMais.Domain.DTO;
using FaleMaisTestes.Utils;
using Microsoft.AspNetCore.Http;
using FaleMais.Repository.Interface;

namespace FaleMaisTestes.ServiceTestes
{
    public class UsuarioServiceTests
    {
        [Fact]
        public void Cadastrar_QuandoUsuarioJaExistir_DeveRetornarErro()
        {
            // Arrange
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock
                .Setup(_ => _.VerificarSeJaExiste(It.IsAny<string>()))
                .Returns(true);
            var servico = new UsuarioService(usuarioRepositoryMock.Object);
            var dto = new UsuarioCadastrarDTO()
            {
                Nome = "nome",
                Senha = "12345678",
                Autorizacao = "Cliente"
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Cadastrar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("Usuário informado já existe", erro?.Value);
        }

        [Fact]
        public void Atualizar_QuandoUsuarioNaoExistir_DeveRetornarErro()
        {
            // Arrange
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            var servico = new UsuarioService(usuarioRepositoryMock.Object);
            var dto = new UsuarioAtualizarDTO()
            {
                Id = 1,
                Nome = "nome",
                Senha = "12345678",
                Autorizacao = "Cliente"
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Atualizar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("Usuário não encontrado para atualizar!", erro?.Value);
        }
    }
}
