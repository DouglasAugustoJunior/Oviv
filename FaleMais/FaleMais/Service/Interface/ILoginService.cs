using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface ILoginService
    {
        IResult Login(LoginDTO login);
    }
}
