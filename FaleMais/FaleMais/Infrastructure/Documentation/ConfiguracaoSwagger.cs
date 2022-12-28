using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FaleMais.Infrastructure.Documentacao
{
    internal static class ConfiguracaoSwagger
    {
        public static Action<SwaggerGenOptions> ConfigurarSwagger() =>
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FaleMaisAPI",
                    Description = "Aplicação para realizar o cálculo do valor das ligações utilizando os planos da VxTel.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Douglas Silva",
                        Email = "douglasSilva@falemais.com"
                    },
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Seu token de acesso deve estar no seguinte formato: \r\n\r\n Bearer {seu token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            };
    }
}
