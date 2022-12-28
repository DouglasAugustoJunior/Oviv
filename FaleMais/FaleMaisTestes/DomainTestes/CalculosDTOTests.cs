using MiniValidation;
using FaleMais.Domain.DTO;

namespace FaleMaisTestes.DomainTestes
{
    public class CalculosDTOTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CalculosDTO_QuandoQtdeMinInvalido_DeveRetornarErro(int qtdeMin)
        {
            // Arrange
            var calculoDTO = new CalculosDTO()
            {
                DestinoId = 1,
                OrigemId = 1,
                QtdeMin = qtdeMin
            };
            // Act
            var estaValido = MiniValidator.TryValidate(calculoDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha um valor válido para o campo Quantidade Minutos", erros.First().Value.First());
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CalculosDTO_QuandoOrigemInvalido_DeveRetornarErro(int origemId)
        {
            // Arrange
            var calculoDTO = new CalculosDTO()
            {
                DestinoId = 1,
                OrigemId = origemId,
                QtdeMin = 1
            };
            // Act
            var estaValido = MiniValidator.TryValidate(calculoDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha um valor válido para o campo Origem", erros.First().Value.First());
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CalculosDTO_QuandoDestinoInvalido_DeveRetornarErro(int destinoId)
        {
            // Arrange
            var calculoDTO = new CalculosDTO()
            {
                DestinoId = destinoId,
                OrigemId = 1,
                QtdeMin = 1
            };
            // Act
            var estaValido = MiniValidator.TryValidate(calculoDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha um valor válido para o campo Destino", erros.First().Value.First());
        }
    }
}
