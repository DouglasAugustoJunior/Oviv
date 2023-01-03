using FaleMais.Domain.DTO;
using MiniValidation;

namespace FaleMaisTestes.DomainTestes
{
    public class DDDAtualizarDTOTests
    {
        [Fact]
        public void ToDDD_QuandoChamado_DevePreencherTodosOsCampos()
        {
            // Arrange
            var dto = new DDDAtualizarDTO()
            {
                Id = 1,
                Nome = "011"
            };

            // Act
            var ddd = dto.ToDDD();

            // Assert
            Assert.Equal(ddd.Id, dto.Id);
            Assert.Equal(ddd.Nome, dto.Nome);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void DDDAtualizarDTO_QuandoNomeInvalido_DeveRetornarErro(string nome)
        {
            // Arrange
            var dto = new DDDAtualizarDTO()
            {
                Id= 1,
                Nome = nome
            };
            // Act
            var estaValido = MiniValidator.TryValidate(dto, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha o campo DDD", erros.First().Value.First());
        }
    }
}
