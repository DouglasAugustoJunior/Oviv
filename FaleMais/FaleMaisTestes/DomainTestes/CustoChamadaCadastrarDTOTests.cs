using Domain.DTO;
using MiniValidation;

namespace FaleMaisTestes.DomainTestes
{
    public class CustoChamadaCadastrarDTOTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CustoChamadaCadastrarDTO_QuandoValorPorMinInvalido_DeveRetornarErro(double ValorPorMin)
        {
            // Arrange
            var custoChamadaCadastrarDTO = new CustoChamadaCadastrarDTO()
            {
                DestinoId = 1,
                OrigemId = 1,
                ValorPorMin = ValorPorMin
            };
            // Act
            var estaValido = MiniValidator.TryValidate(custoChamadaCadastrarDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Precisa ser maior que R$0,01.", erros.First().Value.First());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CustoChamadaCadastrarDTO_QuandoOrigemInvalido_DeveRetornarErro(int origemId)
        {
            // Arrange
            var custoChamadaCadastrarDTO = new CustoChamadaCadastrarDTO()
            {
                DestinoId = 1,
                OrigemId = origemId,
                ValorPorMin = 1
            };
            // Act
            var estaValido = MiniValidator.TryValidate(custoChamadaCadastrarDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha um valor válido para o campo Origem", erros.First().Value.First());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CustoChamadaCadastrarDTO_QuandoDestinoInvalido_DeveRetornarErro(int destinoId)
        {
            // Arrange
            var custoChamadaCadastrarDTO = new CustoChamadaCadastrarDTO()
            {
                DestinoId = destinoId,
                OrigemId = 1,
                ValorPorMin = 1
            };
            // Act
            var estaValido = MiniValidator.TryValidate(custoChamadaCadastrarDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha um valor válido para o campo Destino", erros.First().Value.First());
        }
    }
}
