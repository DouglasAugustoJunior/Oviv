using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface ICustoChamadaService
    {
        List<CustoChamadaListagemDTO> Listar();
        List<CustoChamadaDTO> ListarParaInput();
    }
}