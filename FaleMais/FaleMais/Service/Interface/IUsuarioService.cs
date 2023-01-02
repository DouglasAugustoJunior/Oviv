using FaleMais.Domain;
using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        List<UsuariosListagemDTO> Listar();
        IResult Atualizar(UsuarioAtualizarDTO dto);
    }
}