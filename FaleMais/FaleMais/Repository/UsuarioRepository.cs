using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Repository.Interface;
using FaleMais.Infrastructure.Database;

namespace FaleMais.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IFaleMaisDbContext context): base(context) { }

        public Usuario? EfetuarLogin(LoginDTO login) =>
            Context.Usuario
                .FirstOrDefault(usuario => usuario.Nome.Equals(login.Usuario)
                    && usuario.Senha.Equals(login.Senha)
                    && !usuario.DataDelecao.HasValue);
    }
}
