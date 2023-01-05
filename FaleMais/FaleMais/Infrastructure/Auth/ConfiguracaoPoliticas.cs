using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Infrastructure.Auth
{
    public static class ConfiguracaoPoliticas
    {
        public static Action<CorsOptions> ConfigurarPoliticas(string politica, string allowewHosts) =>
            options =>
            {
                options.AddPolicy(
                    name: politica,
                    politica =>
                    {
                        politica
                            .WithOrigins(allowewHosts)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            };
    }
}
