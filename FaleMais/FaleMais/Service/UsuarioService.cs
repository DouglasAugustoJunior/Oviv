using MiniValidation;
using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class UsuarioService: BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository): base(usuarioRepository) =>
            _usuarioRepository = usuarioRepository;

        public IResult Atualizar(UsuarioAtualizarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if (_usuarioRepository.BuscarPorId(dto.Id) == null)
                return Results.BadRequest("Usuário não encontrado para atualizar!");
            _usuarioRepository.Atualizar(dto.ToUsuario());
            return Results.Ok("Atualizado com sucesso!");
        }

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
