using MiniValidation;
using Domain.DTO;
using Domain;
using Repository.Interface;
using Infrastructure;
using Service.Interface;

namespace Service
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository) =>
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

        public IResult Cadastrar(UsuarioCadastrarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if (_usuarioRepository.VerificarSeJaExiste(dto.Nome))
                return Results.BadRequest("Usuário informado já existe");
            _usuarioRepository.Cadastrar(new Usuario(dto));
            return Results.Ok("Cadastrado com sucesso!");
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
