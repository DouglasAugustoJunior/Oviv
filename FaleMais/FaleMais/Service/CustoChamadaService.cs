using MiniValidation;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class CustoChamadaService : ICustoChamadaService
    {
        private readonly ICustoChamadaRepository _custoChamadaRepository;
        public CustoChamadaService(ICustoChamadaRepository custoChamadaRepository) =>
            _custoChamadaRepository = custoChamadaRepository;

        public IResult Atualizar(CustoChamadaAtualizarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if (!_custoChamadaRepository.ValidarValorECombinacaoOrigemDestino(dto))
                return Results.BadRequest("Valores inválidos para atualizar!");
            _custoChamadaRepository.Atualizar(dto.ToCustoChamada());
            return Results.Ok("Atualizado com sucesso!");
        }

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
