using Moq;
using Service;
using Domain.DTO;
using FaleMaisTestes.Utils;
using Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace FaleMaisTestes.ServiceTestes
{
    public class DDDServiceTests
    {
        [Fact]
        public void Cadastrar_QuandoDDDJaExistir_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            dddRepositoryMock
                .Setup(_ => _.VerificarSeJaExiste(It.IsAny<string>()))
                .Returns(true);
            var servico = new DDDService(dddRepositoryMock.Object);
            var dto = new DDDCadastrarDTO()
            {
                DDD = "011"
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Cadastrar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("DDD informado já existe", erro?.Value);
        }

        [Fact]
        public void Atualizar_QuandoDDDNaoConverterParaInt_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            var servico = new DDDService(dddRepositoryMock.Object);
            var dto = new DDDAtualizarDTO()
            {
                Id = 1,
                Nome = "qwerty"
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Atualizar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("DDD inválido!", erro?.Value);
        }
        
        [Fact]
        public void Atualizar_QuandoDDDNaoExistir_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            var servico = new DDDService(dddRepositoryMock.Object);
            var dto = new DDDAtualizarDTO()
            {
                Id = 1,
                Nome = "011"
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Atualizar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("DDD não encontrado para atualizar!", erro?.Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deletar_QuandoIDInvalido_DeveRetornarErro(int id)
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            var servico = new DDDService(dddRepositoryMock.Object);
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Deletar(id));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("ID inválido para deletar", erro?.Value);
        }

        [Fact]
        public void Deletar_QuandoDDDEmUso_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            dddRepositoryMock
                .Setup(_ => _.ValidarExistenciaDeTarifaComDDD(It.IsAny<int>()))
                .Returns(true);
            var servico = new DDDService(dddRepositoryMock.Object);
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Deletar(1));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("DDD em uso, favor alterar tarifa com DDD primeiro", erro?.Value);
        }
    }
}
