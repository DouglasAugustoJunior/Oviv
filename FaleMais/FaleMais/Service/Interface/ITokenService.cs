using Domain;

namespace Service.Interface
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}