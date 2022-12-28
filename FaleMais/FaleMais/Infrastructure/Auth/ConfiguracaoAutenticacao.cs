using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FaleMais.Infrastructure.Auth
{
    internal sealed class ConfiguracaoAutenticacao : IConfiguracaoAutenticacao
    {
        private string _chaveSecreta { get; set; }
        public string ChaveSecreta
        {
            get => _chaveSecreta;
            init
            {
                _chaveSecreta = string.IsNullOrEmpty(value)
                    ? "eyJzdWIiOiJGYWxlTWFpc0FQSVRva2VuIiwibmFtZSI6IkRvdWdsYXNTaWx2YSIsImlhdCI6MTUxNjIzOTAyMn0"
                    : value;
            }
        }
        public byte[] ChaveSecretaEncode { get => Encoding.ASCII.GetBytes(ChaveSecreta); }

        public static Action<AuthenticationOptions> ConfigurarSchemes()
            => options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            };

        public static Action<JwtBearerOptions> ConfigurarJwt(byte[] chave)
            => options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            };
    }
}
