using FaleMais.Domain;
using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface IDDDService : IBaseService<DDD>
    {
        List<DDDListagemDTO> Listar();
        IResult Atualizar(DDDAtualizarDTO dto);
        IResult Cadastrar(DDDCadastrarDTO dto);
    }
}