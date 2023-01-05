using Domain;
using Domain.DTO;

namespace Repository.Interface
{
    public interface ICustoChamadaRepository : IBaseRepository<CustoChamada>
    {
        List<CustoChamadaListagemDTO> ListarCustoComIncludes();
        CustoChamada? ObterCustoChamadaPorOrigemEDestino(CalculosDTO calculos);
        bool ValidarValorECombinacaoOrigemDestino(CustoChamadaAtualizarDTO dto);
        bool VerificarSeJaExiste(CustoChamadaCadastrarDTO dto);
    }
}