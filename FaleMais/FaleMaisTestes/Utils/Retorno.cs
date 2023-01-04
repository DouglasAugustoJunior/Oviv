using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace FaleMais.Service.Interface
{
    public class Retorno : IResult
    {
        public int? StatusCode { get; set; }

        public Task ExecuteAsync(HttpContext httpContext)
        {
            throw new NotImplementedException();
        }

        public static Retorno? ObterRetorno(object retorno)
        {
            var serializado = JsonSerializer.Serialize(retorno);
            return JsonSerializer.Deserialize<Retorno>(serializado);
        }
    }
}
