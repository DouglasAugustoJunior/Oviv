using MiniValidation;
using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class DDDService: IDDDService
    {
        private readonly IBaseRepository<DDD> _dddRepository;

        public DDDService(IBaseRepository<DDD> dddRepository) =>
            _dddRepository = dddRepository;

        public IResult Atualizar(DDDAtualizarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if (!int.TryParse(dto.Nome, out int _))
                return Results.BadRequest("DDD inválido!");
            if (_dddRepository.BuscarPorId(dto.Id) == null)
                return Results.BadRequest("DDD não encontrado para atualizar!");
            _dddRepository.Atualizar(dto.ToDDD());
            return Results.Ok("Atualizado com sucesso!");
        }

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
