using Domain;
using Domain.DTO;

namespace Service.Interface
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        List<UsuariosListagemDTO> Listar();
        IResult Atualizar(UsuarioAtualizarDTO dto);
        IResult Cadastrar(UsuarioCadastrarDTO dto);
    }
}