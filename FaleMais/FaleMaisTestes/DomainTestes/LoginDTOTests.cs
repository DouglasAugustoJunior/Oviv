using MiniValidation;
using FaleMais.Domain.DTO;

namespace FaleMaisTestes.DomainTestes
{
    public class LoginDTOTests
    {
        [Theory]
        [InlineData(null, "Preencha o campo usuário")]
        [InlineData("", "Preencha o campo usuário")]
        [InlineData("1", "O campo usuário precisa ter no mínimo 3 caracteres")]
        [InlineData(
            "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq",
            "O campo usuário precisa ter no máximo 100 caracteres")]
        public void LoginDTO_QuandoUsuarioInvalido_DeveRetornarErro(string usuario, string erro)
        {
            // Arrange
            var loginDTO = new LoginDTO()
            {
                Senha = "12345678",
                Usuario = usuario
            };
            // Act
            var estaValido = MiniValidator.TryValidate(loginDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal(erro, erros.First().Value.First());
        }
        
        [Theory]
        [InlineData(null, "Preencha o campo Senha")]
        [InlineData("", "Preencha o campo Senha")]
        [InlineData("1", "O campo Senha precisa ter no mínimo 8 caracteres")]
        [InlineData("qqqqqqqqqqqqq", "O campo Senha precisa ter no máximo 12 caracteres")]
        public void LoginDTO_QuandoSenhaInvalido_DeveRetornarErro(string senha, string erro)
        {
            // Arrange
            var loginDTO = new LoginDTO()
            {
                Usuario = "Administrador",
                Senha = senha
            };
            // Act
            var estaValido = MiniValidator.TryValidate(loginDTO, out var erros);
            // Assert 
            Assert.False(estaValido);
            Assert.Single(erros);
            Assert.Equal(erro, erros.First().Value.First());
        }
    }
}
