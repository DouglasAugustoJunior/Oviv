using FaleMais.Domain;

namespace FaleMais.Service.Interface
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}