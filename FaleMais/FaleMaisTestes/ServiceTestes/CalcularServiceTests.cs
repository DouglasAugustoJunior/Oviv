using Moq;
using FaleMais.Domain;
using FaleMais.Service;
using FaleMais.Domain.DTO;
using Microsoft.AspNetCore.Http;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMaisTestes.ServiceTestes
{
    public class CalcularServiceTests
    {
        [Fact]
        public void Calcular_QuandoDTOInvalido_DeveRetornarBadRequest()
        {
            // Arrange
            var calculo = new CalculosDTO();
            var servico = new CalcularService(null, null);
            // Act
            var calculoComStatusCode = Retorno.ObterRetorno(servico.Calcular(calculo));
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, calculoComStatusCode?.StatusCode);
        }

        [Fact]
        public void Calcular_QuandoCustoChamadaNaoExistir_DeveRetornarNotFound()
        {
            // Arrange
            var calculo = new CalculosDTO()
            {
                DestinoId = 1,
                OrigemId = 1,
                QtdeMin = 1
            };
            var custoChamadaRepositoryMock = new Mock<ICustoChamadaRepository>();
            var servico = new CalcularService(custoChamadaRepositoryMock.Object, null);
            // Act
            var calculoComStatusCode = Retorno.ObterRetorno(servico.Calcular(calculo));
            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, calculoComStatusCode?.StatusCode);
        }

        [Fact]
        public void Calcular_QuandoCustoChamadaValidas_DeveRetornarOK()
        {
            // Arrange
            var calculo = new CalculosDTO()
            {
                DestinoId = 1,
                OrigemId = 1,
                QtdeMin = 1
            };
            var planoRepositoryMock = new Mock<IBaseRepository<Plano>>();
            planoRepositoryMock.Setup(_ => _.Listar()).Returns(new List<Plano>());
            var custoChamadaRepositoryMock = new Mock<ICustoChamadaRepository>();
            custoChamadaRepositoryMock
                .Setup(_ => _.ObterCustoChamadaPorOrigemEDestino(It.IsAny<CalculosDTO>()))
                .Returns(new CustoChamada());
            var servico = new CalcularService(custoChamadaRepositoryMock.Object, planoRepositoryMock.Object);
            // Act
            var calculoComStatusCode = Retorno.ObterRetorno(servico.Calcular(calculo));
            // Assert
            Assert.Equal(StatusCodes.Status200OK, calculoComStatusCode?.StatusCode);
        }
        
        [Theory]
        [InlineData(10,30,1.9,0)]
        [InlineData(30,30,1.9,0)]
        [InlineData(31,30,1.9,2.09)]
        [InlineData(60,30,1.9,62.7)]
        public void CalcularTotalPlano_QuandoChamado_DeveRetornarCalculoCorreto(int qtdeMinutos, int minutosGratuitos, double valorPorMin, double resultadoEsperado)
        {
            // Act
            var totalPlano = CalcularService.CalcularTotalPlano(qtdeMinutos,minutosGratuitos,valorPorMin);
            // Assert
            Assert.Equal(resultadoEsperado, Math.Round(totalPlano,2));
        }
        
        [Theory]
        [InlineData(10,1.9d,19)]
        [InlineData(0,1.9d,0)]
        public void CalcularTotalSemPlano_QuandoChamado_DeveRetornarCalculoCorreto(int qtdeMinutos, double valorPorMin, double resultadoEsperado)
        {
            // Act
            var totalSemPlano = CalcularService.CalcularTotalSemPlano(qtdeMinutos,valorPorMin);
            // Assert
            Assert.Equal(resultadoEsperado, totalSemPlano);
        }
    }
}
