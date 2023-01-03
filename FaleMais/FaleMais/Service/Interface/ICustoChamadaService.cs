using FaleMais.Domain;
using FaleMais.Domain.DTO;

namespace FaleMais.Service.Interface
{
    public interface ICustoChamadaService : IBaseService<CustoChamada>
    {
        List<CustoChamadaListagemDTO> Listar();
        List<CustoChamadaDTO> ListarParaInput();
        IResult Cadastrar(CustoChamadaCadastrarDTO dto);

        IResult Atualizar(CustoChamadaAtualizarDTO dto);
    }
}