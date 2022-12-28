using Moq;
using FaleMais.Service;
using System.Text.Json;
using FaleMais.Domain.DTO;
using Microsoft.AspNetCore.Http;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;
using FaleMais.Domain;

namespace FaleMaisTestes.ServiceTestes
{
    public class LoginServiceTests
    {
        [Fact]
        public void Login_QuandoDTOInvalido_DeveRetornarBadRequest()
        {
            // Arrange
            var login = new LoginDTO();
            var servico = new LoginService(null, null);
            // Act
            var retornoLogin = servico.Login(login);
            var loginSerializado = JsonSerializer.Serialize<object>(retornoLogin);
            var loginComStatusCode = JsonSerializer.Deserialize<Retorno>(loginSerializado);
            // Arrange
            Assert.Equal(StatusCodes.Status400BadRequest, loginComStatusCode?.StatusCode);
        }
        
        [Fact]
        public void Login_QuandoCredenciaisInvalidas_DeveRetornarNotFound()
        {
            // Arrange
            var login = new LoginDTO()
            {
                Usuario = "administrador",
                Senha = "12345678"
            };
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            var servico = new LoginService(usuarioRepositoryMock.Object, null);
            // Act
            var retornoLogin = servico.Login(login);
            var loginSerializado = JsonSerializer.Serialize<object>(retornoLogin);
            var loginComStatusCode = JsonSerializer.Deserialize<Retorno>(loginSerializado);
            // Arrange
            Assert.Equal(StatusCodes.Status404NotFound, loginComStatusCode?.StatusCode);
        }
        
        [Fact]
        public void Login_QuandoCredenciaisValidas_DeveRetornarOK()
        {
            // Arrange
            var login = new LoginDTO()
            {
                Usuario = "administrador",
                Senha = "12345678"
            };
            var tokenServiceMock = new Mock<ITokenService>();
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock
                .Setup(_ => _.EfetuarLogin(It.IsAny<LoginDTO>()))
                .Returns(new Usuario());
            var servico = new LoginService(usuarioRepositoryMock.Object, tokenServiceMock.Object);
            // Act
            var retornoLogin = servico.Login(login);
            var loginSerializado = JsonSerializer.Serialize<object>(retornoLogin);
            var loginComStatusCode = JsonSerializer.Deserialize<Retorno>(loginSerializado);
            // Arrange
            Assert.Equal(StatusCodes.Status200OK, loginComStatusCode?.StatusCode);
        }
    }
}
