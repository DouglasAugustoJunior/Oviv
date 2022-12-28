using FaleMais.Domain;
using FaleMais.Domain.DTO;

namespace FaleMais.Repository.Interface
{
    public interface ICustoChamadaRepository : IBaseRepository<CustoChamada>
    {
        List<CustoChamadaListagemDTO> ListarCustoComIncludes();
        CustoChamada? ObterCustoChamadaPorOrigemEDestino(CalculosDTO calculos);
    }
}