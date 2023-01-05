using Domain.DTO;

namespace Service.Interface
{
    public interface ILoginService
    {
        IResult Login(LoginDTO login);
    }
}
