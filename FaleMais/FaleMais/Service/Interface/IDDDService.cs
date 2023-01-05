using Domain;
using Domain.DTO;

namespace Service.Interface
{
    public interface IDDDService : IBaseService<DDD>
    {
        List<DDDListagemDTO> Listar();
        IResult Atualizar(DDDAtualizarDTO dto);
        IResult Cadastrar(DDDCadastrarDTO dto);
    }
}