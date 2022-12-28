using FaleMais.Domain;
using FaleMais.Domain.DTO;

namespace FaleMais.Repository.Interface
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario? EfetuarLogin(LoginDTO login);
    }
}