using MiniValidation;
using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class CustoChamadaService : BaseService<CustoChamada>, ICustoChamadaService
    {
        private readonly ICustoChamadaRepository _custoChamadaRepository;
        private readonly IDDDRepository _dddRepository;

        public CustoChamadaService(
            IDDDRepository dddRepository,
            ICustoChamadaRepository custoChamadaRepository): base(custoChamadaRepository)
        {
            _dddRepository= dddRepository;
            _custoChamadaRepository = custoChamadaRepository;
        }

        public IResult Atualizar(CustoChamadaAtualizarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if (!_custoChamadaRepository.ValidarValorECombinacaoOrigemDestino(dto))
                return Results.BadRequest("Valores inválidos para atualizar!");
            _custoChamadaRepository.Atualizar(dto.ToCustoChamada());
            return Results.Ok("Atualizado com sucesso!");
        }

        public IResult Cadastrar(CustoChamadaCadastrarDTO dto)
        {
            if (!MiniValidator.TryValidate(dto, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            if(_dddRepository.BuscarPorId(dto.DestinoId) == null)
                return Results.BadRequest("Destino informado é inválido");
            if(_dddRepository.BuscarPorId(dto.OrigemId) == null)
                return Results.BadRequest("Origem informado é inválida");
            if (_custoChamadaRepository.VerificarSeJaExiste(dto))
                return Results.BadRequest("Tarifa informada já existe");
            _custoChamadaRepository.Cadastrar(new CustoChamada(dto));
            return Results.Ok("Cadastrado com sucesso!");
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
