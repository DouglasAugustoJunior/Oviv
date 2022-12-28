using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class DDDService: IDDDService
    {
        private readonly IBaseRepository<DDD> _dddRepository;

        public DDDService(IBaseRepository<DDD> dddRepository) =>
            _dddRepository = dddRepository;

        public List<DDDListagemDTO> Listar() =>
            _dddRepository
                .Listar()
                .Select(ddd => new DDDListagemDTO()
                {
                    ID = ddd.Id,
                    Nome = ddd.Nome
                })
                .ToList();
    }
}
