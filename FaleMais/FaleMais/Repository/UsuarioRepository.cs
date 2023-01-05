using Domain;
using Repository.Interface;
using Infrastructure.Database;
using Domain.DTO;

namespace Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IFaleMaisDbContext context) : base(context) { }

        public Usuario? EfetuarLogin(LoginDTO login) =>
            Context.Usuario
                .FirstOrDefault(usuario => usuario.Nome.Equals(login.Usuario)
                    && usuario.Senha.Equals(login.Senha)
                    && !usuario.DataDelecao.HasValue);

        public bool VerificarSeJaExiste(string nome) =>
            Context.Usuario.Any(_ => _.Nome.Equals(nome) && !_.DataDelecao.HasValue);
    }
}
