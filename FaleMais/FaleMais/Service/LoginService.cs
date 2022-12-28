using MiniValidation;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public LoginService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public IResult Login(LoginDTO login)
        {
            if (!MiniValidator.TryValidate(login, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            var usuarioAutenticado = _usuarioRepository.EfetuarLogin(login);
            if (usuarioAutenticado == null)
                return Results.NotFound("Usuário ou senha incorretos.");
            return Results.Ok(new AcessoDTO
            {
                Usuario = usuarioAutenticado.Nome,
                Autorizacao = usuarioAutenticado.Autorizacao,
                Token = _tokenService.GerarToken(usuarioAutenticado)
            });
        }
    }
}
