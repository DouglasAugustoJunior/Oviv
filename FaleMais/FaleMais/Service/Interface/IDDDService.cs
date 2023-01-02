using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface IDDDService
    {
        IResult Atualizar(DDDAtualizarDTO dto);
        List<DDDListagemDTO> Listar();
    }
}