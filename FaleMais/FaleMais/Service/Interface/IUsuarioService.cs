using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface IUsuarioService
    {
        List<UsuariosListagemDTO> Listar();
        IResult Atualizar(UsuarioAtualizarDTO dto);
    }
}