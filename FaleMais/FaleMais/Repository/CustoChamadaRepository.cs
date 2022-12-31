using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using FaleMais.Infrastructure.Database;

namespace FaleMais.Repository
{
    public class CustoChamadaRepository : BaseRepository<CustoChamada>, ICustoChamadaRepository
    {
        public CustoChamadaRepository(IFaleMaisDbContext context): base(context) { }

        public List<CustoChamadaListagemDTO> ListarCustoComIncludes() =>
            Context.CustoChamada
                .Include(custo => custo.Origem)
                .Include(custo => custo.Destino)
                .Where(custo => !custo.DataDelecao.HasValue)
                .Select(custo => new CustoChamadaListagemDTO()
                {
                    Id = custo.Id,
                    Origem = custo.Origem.Nome,
                    Destino = custo.Destino.Nome,
                    CustoPorMin = custo.ValorPorMin
                })
                .ToList();

        public CustoChamada? ObterCustoChamadaPorOrigemEDestino(CalculosDTO calculos) =>
            Context.CustoChamada
            .FirstOrDefault(custoChamada => custoChamada.DestinoId == calculos.DestinoId
                && custoChamada.OrigemId == calculos.OrigemId);

        public bool ValidarValorECombinacaoOrigemDestino(CustoChamadaAtualizarDTO dto)
        {
            var custoChamadaAtual = BuscarPorId(dto.Id);
            if(custoChamadaAtual == null
                || !Context.DDD.Any(_ => _.Id == dto.OrigemId)
                || !Context.DDD.Any(_ => _.Id == dto.DestinoId)
                || dto.ValorPorMin <= 0)
                return false;
            return true;
        }
    }
}
