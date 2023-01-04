using System.Text.Json;
using FaleMais.Service.Interface;

namespace FaleMaisTestes.Utils
{
    public class RetornoExtendido : Retorno
    {
        public string Value { get; set; } = string.Empty;

        public static RetornoExtendido? ObterRetornoExtendido(object retorno)
        {
            var serializado = JsonSerializer.Serialize(retorno);
            return JsonSerializer.Deserialize<RetornoExtendido>(serializado);
        }
    }
}
