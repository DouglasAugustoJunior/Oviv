using Microsoft.AspNetCore.Authorization;

namespace FaleMais.Infrastructure.Auth
{
    internal static class ConfiguracaoAutorizacao
    {
        public static string Cliente = "Cliente";
        public static string Administrador = "Administrador";
        public static Action<AuthorizationOptions> ConfigurarAutorizacoes() =>
            options =>
            {
                options.AddPolicy("Cliente", politica => politica.RequireRole(Cliente));
                options.AddPolicy("Administrador", politica => politica.RequireRole(Administrador));
            };
    }
}
