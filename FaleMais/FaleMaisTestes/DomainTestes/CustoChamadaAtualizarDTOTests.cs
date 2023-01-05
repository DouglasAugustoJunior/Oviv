using Domain.DTO;

namespace FaleMaisTestes.DomainTestes
{
    public class CustoChamadaAtualizarDTOTests
    {
        [Fact]
        public void ToCustoChamada_QuandoChamado_DevePreencherTodosOsCampos()
        {
            // Arrange
            var dto = new CustoChamadaAtualizarDTO()
            {
                Id= 1,
                OrigemId= 1,
                DestinoId= 1,
                ValorPorMin = 1
            };

            // Act
            var custoChamada = dto.ToCustoChamada();

            // Assert
            Assert.Equal(custoChamada.Id, dto.Id);
            Assert.Equal(custoChamada.OrigemId, dto.OrigemId);
            Assert.Equal(custoChamada.DestinoId, dto.DestinoId);
            Assert.Equal(custoChamada.ValorPorMin, dto.ValorPorMin);

        }
    }
}
