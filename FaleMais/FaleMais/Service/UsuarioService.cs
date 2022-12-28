using FaleMais.Domain.DTO;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) =>
            _usuarioRepository = usuarioRepository;
        
        public List<UsuariosListagemDTO> Listar() =>
            _usuarioRepository
                .Listar()
                .Select(usuario => new UsuariosListagemDTO()
                {
                    Id = usuario.Id,
                    DataCriacao = usuario.DataCriacao,
                    Nome = usuario.Nome,
                    Autorizacao = usuario.Autorizacao
                })
                .ToList();
    }
}
