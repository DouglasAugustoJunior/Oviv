using FaleMais.Domain.DTO;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class CustoChamadaService : ICustoChamadaService
    {
        private readonly ICustoChamadaRepository _custoChamadaRepository;
        public CustoChamadaService(ICustoChamadaRepository custoChamadaRepository) =>
            _custoChamadaRepository = custoChamadaRepository;

        public List<CustoChamadaListagemDTO> Listar() =>
            _custoChamadaRepository.ListarCustoComIncludes();
        
        public List<CustoChamadaDTO> ListarParaInput() =>
            _custoChamadaRepository.Listar()
            .Select(custoChamada => new CustoChamadaDTO()
            {
                Id = custoChamada.Id,
                OrigemId = custoChamada.OrigemId,
                DestinoId = custoChamada.DestinoId
            }).ToList();
    }
}
