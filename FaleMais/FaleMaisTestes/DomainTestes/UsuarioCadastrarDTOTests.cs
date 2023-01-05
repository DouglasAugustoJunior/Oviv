using MiniValidation;
using Domain.DTO;

namespace FaleMaisTestes.DomainTestes
{
    public class UsuarioCadastrarDTOTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void UsuarioCadastrarDTO_QuandoNomeVazio_DeveRetornarErro(string nome)
        {
            // Arrange
            var dto = new UsuarioCadastrarDTO()
            {
                Nome = nome,
                Senha = "12345678",
                Autorizacao = "000"
            };
            // Act
            var estaValido = MiniValidator.TryValidate(dto, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha o campo Nome", erros.First().Value.First());
        }

        [Theory]
        [InlineData("12", "O campo Nome precisa ter no mínimo 3 caracteres")]
        [InlineData(
            "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
            "O campo Nome precisa ter no máximo 100 caracteres")]
        public void UsuarioCadastrarDTO_QuandoNomeInvalido_DeveRetornarErro(string senha,string mensagem)
        {
            // Arrange
            var dto = new UsuarioCadastrarDTO()
            {
                Nome = senha,
                Senha = "12345678",
                Autorizacao = "000"
            };
            // Act
            var estaValido = MiniValidator.TryValidate(dto, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal(mensagem, erros.First().Value.First());
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void UsuarioCadastrarDTO_QuandoSenhaVazio_DeveRetornarErro(string senha)
        {
            // Arrange
            var dto = new UsuarioCadastrarDTO()
            {
                Nome = "123",
                Senha = senha,
                Autorizacao = "000"
            };
            // Act
            var estaValido = MiniValidator.TryValidate(dto, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha o campo Senha", erros.First().Value.First());
        }

        [Theory]
        [InlineData("1234567", "O campo Senha precisa ter no mínimo 8 caracteres")]
        [InlineData(
            "1111111111111",
            "O campo Senha precisa ter no máximo 12 caracteres")]
        public void UsuarioCadastrarDTO_QuandoSenhaInvalido_DeveRetornarErro(string senha, string mensagem)
        {
            // Arrange
            var dto = new UsuarioCadastrarDTO()
            {
                Nome = "123",
                Senha = senha,
                Autorizacao = "000"
            };
            // Act
            var estaValido = MiniValidator.TryValidate(dto, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal(mensagem, erros.First().Value.First());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void UsuarioCadastrarDTO_QuandoAutorizacaoVazio_DeveRetornarErro(string autorizacao)
        {
            // Arrange
            var dto = new UsuarioCadastrarDTO()
            {
                Nome = "123",
                Senha = "12345678",
                Autorizacao = autorizacao
            };
            // Act
            var estaValido = MiniValidator.TryValidate(dto, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal("Preencha o campo Autorização", erros.First().Value.First());
        }
    }
}
