using Moq;
using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Repository;
using FaleMaisTestes.Utils;
using FaleMais.Infrastructure.Database;

namespace FaleMaisTestes.RepositoryTestes
{
    public class CustoChamadaRepositoryTests
    {
        [Fact]
        public void ListarCustoComIncludes_QuandoCustoChamadaComDataDelecao_DeveIgnorarRegistro()
        {
            // Arrange
            var custoChamadaDeletado = new CustoChamada()
            {
                DataDelecao = DateTime.Now
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(new List<CustoChamada>() { custoChamadaDeletado });
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock.Setup(_ => _.CustoChamada).Returns(custoChamadaMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);
            // Act
            var custoBuscados = repository.ListarCustoComIncludes();
            // Assert
            Assert.Empty(custoBuscados);
        }
        
        [Fact]
        public void ListarCustoComIncludes_QuandoCustoChamadaValido_DeveRetornarDTO()
        {
            // Arrange
            var custoChamada = new CustoChamada()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 2,
                ValorPorMin = 1,
                Origem = new DDD() { Id = 1, Nome = "Origem" },
                Destino = new DDD() { Id = 2, Nome = "Destino" }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(new List<CustoChamada>() { custoChamada });
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock.Setup(_ => _.CustoChamada).Returns(custoChamadaMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);
            // Act
            var listaDTO = repository.ListarCustoComIncludes();
            // Assert
            Assert.NotEmpty(listaDTO);
            Assert.Equal("Origem", listaDTO.First().Origem);
            Assert.Equal("Destino", listaDTO.First().Destino);
        }
        
        [Fact]
        public void ObterCustoChamadaPorOrigemEDestino_QuandoCustoChamadaExistir_DeveRetornarObjeto()
        {
            // Arrange
            var origemIdCorreto = 1;
            var destinoIdCorreto = 1;
            var calculoDTO = new CalculosDTO()
            {
                OrigemId = origemIdCorreto,
                DestinoId = destinoIdCorreto,
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada()
                {
                    Id = 1,
                    OrigemId = origemIdCorreto,
                    DestinoId = destinoIdCorreto,
                    ValorPorMin = 1
                },
                new CustoChamada()
                {
                    Id = 2,
                    OrigemId = 3,
                    DestinoId = 4,
                    ValorPorMin = 5
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock.Setup(_ => _.CustoChamada).Returns(custoChamadaMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);
            // Act
            var custoChamadaRetornado = repository.ObterCustoChamadaPorOrigemEDestino(calculoDTO);
            // Assert
            Assert.NotNull(custoChamadaRetornado);
            Assert.Equal(origemIdCorreto, custoChamadaRetornado?.OrigemId);
            Assert.Equal(origemIdCorreto, custoChamadaRetornado?.DestinoId);
        }
        
        [Fact]
        public void ObterCustoChamadaPorOrigemEDestino_QuandoCustoChamadaNaoExistir_DeveRetornarNull()
        {
            // Arrange
            var calculoDTO = new CalculosDTO()
            {
                OrigemId = 1,
                DestinoId = 1,
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada()
                {
                    Id = 2,
                    OrigemId = 3,
                    DestinoId = 4,
                    ValorPorMin = 5
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock.Setup(_ => _.CustoChamada).Returns(custoChamadaMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);
            // Act
            var custoChamadaRetornado = repository.ObterCustoChamadaPorOrigemEDestino(calculoDTO);
            // Assert
            Assert.Null(custoChamadaRetornado);
        }
        
        [Fact]
        public void ValidarValorECombinacaoOrigemDestino_QuandoCustoChamadaNaoExistir_DeveRetornarFalse()
        {
            // Arrange
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = 1
            };
            var custosChamadas = new List<CustoChamada>();
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.Set<CustoChamada>())
                .Returns(custoChamadaMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);
            // Act
            var custoExiste = repository.ValidarValorECombinacaoOrigemDestino(dto);
            // Assert
            Assert.False(custoExiste);
        }

        [Fact]
        public void ValidarValorECombinacaoOrigemDestino_QuandoOrigemNaoExistir_DeveRetornarFalse()
        {
            // Arrange
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 2,
                ValorPorMin = 1
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada {
                    Id = 1,
                    OrigemId = 1,
                    DestinoId = 1,
                    ValorPorMin = 1
                }
            };
            var ddds = new List<DDD>()
            {
                new DDD
                {
                    Id= 2
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var dddMock = MockDbSetUtil.MockDbSet(ddds);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.Set<CustoChamada>())
                .Returns(custoChamadaMock.Object);
            contextMock
                .Setup(_ => _.DDD)
                .Returns(dddMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);

            // Act
            var valido = repository.ValidarValorECombinacaoOrigemDestino(dto);

            // Assert
            Assert.False(valido);
        }

        [Fact]
        public void ValidarValorECombinacaoOrigemDestino_QuandoDestinoNaoExistir_DeveRetornarFalse()
        {
            // Arrange
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 2,
                ValorPorMin = 1
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada {
                    Id = 1,
                    OrigemId = 1,
                    DestinoId = 1,
                    ValorPorMin = 1
                }
            };
            var ddds = new List<DDD>()
            {
                new DDD
                {
                    Id= 1
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var dddMock = MockDbSetUtil.MockDbSet(ddds);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.Set<CustoChamada>())
                .Returns(custoChamadaMock.Object);
            contextMock
                .Setup(_ => _.DDD)
                .Returns(dddMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);

            // Act
            var valido = repository.ValidarValorECombinacaoOrigemDestino(dto);

            // Assert
            Assert.False(valido);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(null)]
        public void ValidarValorECombinacaoOrigemDestino_QuandoValorPorMinInvalido_DeveRetornarFalse(double valorPorMin)
        {
            // Arrange
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = valorPorMin
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada {
                    Id = 1,
                    OrigemId = 1,
                    DestinoId = 1,
                    ValorPorMin = 1
                }
            };
            var ddds = new List<DDD>()
            {
                new DDD
                {
                    Id= 1
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var dddMock = MockDbSetUtil.MockDbSet(ddds);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.Set<CustoChamada>())
                .Returns(custoChamadaMock.Object);
            contextMock
                .Setup(_ => _.DDD)
                .Returns(dddMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);

            // Act
            var valido = repository.ValidarValorECombinacaoOrigemDestino(dto);

            // Assert
            Assert.False(valido);
        }
        
        [Fact]
        public void ValidarValorECombinacaoOrigemDestino_QuandoValido_DeveRetornarTrue()
        {
            // Arrange
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id = 1,
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = 1
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada {
                    Id = 1,
                    OrigemId = 1,
                    DestinoId = 1,
                    ValorPorMin = 1
                }
            };
            var ddds = new List<DDD>()
            {
                new DDD
                {
                    Id= 1
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var dddMock = MockDbSetUtil.MockDbSet(ddds);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.Set<CustoChamada>())
                .Returns(custoChamadaMock.Object);
            contextMock
                .Setup(_ => _.DDD)
                .Returns(dddMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);

            // Act
            var valido = repository.ValidarValorECombinacaoOrigemDestino(dto);

            // Assert
            Assert.True(valido);
        }

        [Fact]
        public void VerificarSeJaExiste_QuandoRegistroDeletado_DeveRetornarFalse()
        {
            // Arrange
            var dto = new CustoChamadaCadastrarDTO()
            {
                OrigemId = 1,
                DestinoId = 1,
                ValorPorMin = 1
            };
            var custosChamadas = new List<CustoChamada>()
            {
                new CustoChamada {
                    Id = 1,
                    OrigemId = 1,
                    DestinoId = 1,
                    ValorPorMin = 1,
                    DataDelecao = DateTime.Now
                }
            };
            var custoChamadaMock = MockDbSetUtil.MockDbSet(custosChamadas);
            var contextMock = new Mock<IFaleMaisDbContext>();
            contextMock
                .Setup(_ => _.CustoChamada)
                .Returns(custoChamadaMock.Object);
            var repository = new CustoChamadaRepository(contextMock.Object);

            // Act
            var existe = repository.VerificarSeJaExiste(dto);

            // Assert
            Assert.False(existe);
        }
    }
}
