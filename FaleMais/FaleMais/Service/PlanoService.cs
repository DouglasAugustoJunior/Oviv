using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class PlanoService: IPlanoService
    {
        private readonly IBaseRepository<Plano> _planoRepository;

        public PlanoService(IBaseRepository<Plano> planoRepository) =>
            _planoRepository = planoRepository;

        public List<PlanoListagemDTO> Listar() =>
            _planoRepository.Listar()
                .Select(plano => new PlanoListagemDTO()
                {
                    Nome = plano.Nome,
                    MinutosGratuitos = plano.MinutosGratuitos
                })
                .ToList();
    }
}
