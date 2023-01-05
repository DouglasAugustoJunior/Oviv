using Moq;
using Domain;
using Service;
using Domain.DTO;
using Repository.Interface;
using FaleMaisTestes.Utils;
using Microsoft.AspNetCore.Http;

namespace FaleMaisTestes.ServiceTestes
{
    public class CustoChamadaServiceTests
    {
        [Fact]
        public void Cadastrar_QuandoDestinoNaoExistir_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            var servico = new CustoChamadaService(dddRepositoryMock.Object,null);
            var dto = new CustoChamadaCadastrarDTO()
            {
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = 1
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Cadastrar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("Destino informado é inválido", erro?.Value);
        }
        
        [Fact]
        public void Cadastrar_QuandoOrigemNaoExistir_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            dddRepositoryMock
                .Setup(_ => _.BuscarPorId(1))
                .Returns(new DDD());
            var servico = new CustoChamadaService(dddRepositoryMock.Object,null);
            var dto = new CustoChamadaCadastrarDTO()
            {
                OrigemId = 2,
                DestinoId = 1,
                ValorPorMin = 1
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Cadastrar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("Origem informado é inválida", erro?.Value);
        }
        
        [Fact]
        public void Cadastrar_QuandoTarifaJaExistir_DeveRetornarErro()
        {
            // Arrange
            var dddRepositoryMock = new Mock<IDDDRepository>();
            var custoChamadaRepositoryMock = new Mock<ICustoChamadaRepository>();
            custoChamadaRepositoryMock
                .Setup(_ => _.VerificarSeJaExiste(It.IsAny<CustoChamadaCadastrarDTO>()))
                .Returns(true);
            dddRepositoryMock
                .Setup(_ => _.BuscarPorId(It.IsAny<int>()))
                .Returns(new DDD());
            var servico = new CustoChamadaService(
                dddRepositoryMock.Object,
                custoChamadaRepositoryMock.Object);
            var dto = new CustoChamadaCadastrarDTO()
            {
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = 1
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Cadastrar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("Tarifa informada já existe", erro?.Value);
        }
        
        [Fact]
        public void Atualizar_QuandoValoresInvalidos_DeveRetornarErro()
        {
            // Arrange
            var custoChamadaRepositoryMock = new Mock<ICustoChamadaRepository>();
            custoChamadaRepositoryMock
                .Setup(_ => _.ValidarValorECombinacaoOrigemDestino(It.IsAny<CustoChamadaAtualizarDTO>()))
                .Returns(false);
            var servico = new CustoChamadaService(
                null,
                custoChamadaRepositoryMock.Object);
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = 1
            };
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Atualizar(dto));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("Valores inválidos para atualizar!", erro?.Value);
        }
    }
}
