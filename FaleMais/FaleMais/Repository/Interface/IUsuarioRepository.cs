using Domain;
using Domain.DTO;

namespace Repository.Interface
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario? EfetuarLogin(LoginDTO login);
        bool VerificarSeJaExiste(string dto);
    }
}