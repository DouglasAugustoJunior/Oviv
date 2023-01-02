using FaleMais.Domain;
using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface ICustoChamadaService : IBaseService<CustoChamada>
    {
        List<CustoChamadaListagemDTO> Listar();
        List<CustoChamadaDTO> ListarParaInput();
        IResult Atualizar(CustoChamadaAtualizarDTO dto);
    }
}