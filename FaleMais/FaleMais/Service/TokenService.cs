using FaleMais.Domain;
using System.Security.Claims;
using FaleMais.Service.Interface;
using FaleMais.Infrastructure.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace FaleMais.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguracaoAutenticacao _configuracaoAutenticacao;

        public TokenService(IConfiguracaoAutenticacao configuracaoAutenticacao) =>
            _configuracaoAutenticacao = configuracaoAutenticacao;

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = _configuracaoAutenticacao.ChaveSecretaEncode;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, usuario.Nome),
                    new(ClaimTypes.Role, usuario.Autorizacao)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha384Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
