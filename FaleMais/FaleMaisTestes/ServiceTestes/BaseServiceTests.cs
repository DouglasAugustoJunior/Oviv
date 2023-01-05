using Moq;
using Service;
using Domain;
using FaleMaisTestes.Utils;
using Repository.Interface;
using Microsoft.AspNetCore.Http;

namespace FaleMaisTestes.ServiceTestes
{
    public class BaseServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deletar_QuandoIDInvalido_DeveRetornarErro(int id)
        {
            // Arrange
            var custoChamadaRepositoryMock = new Mock<IBaseRepository<CustoChamada>>();
            var servico = new BaseService<CustoChamada>(custoChamadaRepositoryMock.Object);
            // Act
            var erro = RetornoExtendido.ObterRetornoExtendido(servico.Deletar(id));
            // Arrange
            Assert.NotNull(erro);
            Assert.Equal(StatusCodes.Status400BadRequest, erro?.StatusCode);
            Assert.Equal("ID inválido para deletar", erro?.Value);
        }
    }
}
