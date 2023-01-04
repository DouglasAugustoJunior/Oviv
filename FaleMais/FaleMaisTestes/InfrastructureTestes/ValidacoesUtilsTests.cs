using FaleMais.Infrastructure;

namespace FaleMaisTestes.InfrastructureTestes
{
    public class ValidacoesUtilsTests
    {
        [Fact]
        public void ObterErros_QuandoConterErro_DeveRetornarListaFormatada()
        {
            // Arrange
            var nomePropriedade = "NomePropriedade";
            var erroPropriedade = "Preencha a propriedade";
            var dicionarioErros = new Dictionary<string, string[]>()
            {
                { nomePropriedade, new string[]{ erroPropriedade } }
            };
            // Act
            var erroFormatado = ValidacoesUtils.ObterErros(dicionarioErros);
            // Assert
            Assert.Single(erroFormatado);
            Assert.Equal($"{nomePropriedade}: {erroPropriedade}", erroFormatado.First());
        }
        
        [Fact]
        public void ObterErros_QuandoConterDiversosErro_DeveRetornarListaDeAcordoComQuantidade()
        {
            // Arrange
            var dicionarioErros = new Dictionary<string, string[]>()
            {
                { "1", new string[]{ string.Empty } },
                { "2", new string[]{ string.Empty } },
                { "3", new string[]{ string.Empty } }
            };
            // Act
            var errosFormatados = ValidacoesUtils.ObterErros(dicionarioErros);
            // Assert
            Assert.NotNull(errosFormatados);
            Assert.Equal(3, errosFormatados.Count);
        }
    }
}
