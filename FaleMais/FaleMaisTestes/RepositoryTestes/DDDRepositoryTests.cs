using Moq;
using Domain;
using Repository;
using FaleMaisTestes.Utils;
using Infrastructure.Database;

namespace FaleMaisTestes.RepositoryTestes
{
    public class DDDRepositoryTests
    {
        [Fact]
        public void VerificarSeJaExiste_QuandoDDDDeletado_DeveRetornarFalse()
        {
            // Arrange
            var ddd = "011";
            var ddds = new List<DDD>()
            {
                new DDD() {
                    Nome = ddd,
                    DataDelecao = DateTime.Now
                }
            };
            var dddStub = MockDbSetUtil.MockDbSet(ddds);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.DDD)
                .Returns(dddStub.Object);
            var repository = new DDDRepository(contextMock.Object);

            // Act
            var existe = repository.VerificarSeJaExiste(ddd);

            // Assert
            Assert.False(existe);
        }
        
        [Fact]
        public void ValidarExistenciaDeTarifaComDDD_QuandoCustoDeletado_DeveRetornarFalse()
        {
            // Arrange
            var dddId = 1;
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada() {
                    DestinoId = dddId,
                    OrigemId= dddId,
                    DataDelecao = DateTime.Now
                }
            };
            var custochamadaStub = MockDbSetUtil.MockDbSet(custosChamadas);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.CustoChamada)
                .Returns(custochamadaStub.Object);
            var repository = new DDDRepository(contextMock.Object);

            // Act
            var existe = repository.ValidarExistenciaDeTarifaComDDD(dddId);

            // Assert
            Assert.False(existe);
        }
    }
}
