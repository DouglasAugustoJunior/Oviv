using Domain;
using Domain.DTO;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class PlanoService : IPlanoService
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
