﻿using Microsoft.EntityFrameworkCore;
using Domain.DTO;
using Infrastructure.Database;
using Domain;
using Repository.Interface;

namespace Repository
{
    public class CustoChamadaRepository : BaseRepository<CustoChamada>, ICustoChamadaRepository
    {
        public CustoChamadaRepository(IFaleMaisDbContext context) : base(context) { }

        public List<CustoChamadaListagemDTO> ListarCustoComIncludes() =>
            Context.CustoChamada
                .Include(custo => custo.Origem)
                .Include(custo => custo.Destino)
                .Where(custo => !custo.DataDelecao.HasValue)
                .Select(custo => new CustoChamadaListagemDTO()
                {
                    Id = custo.Id,
                    Origem = custo.Origem != null ? custo.Origem.Nome : string.Empty,
                    Destino = custo.Destino != null ? custo.Destino.Nome : string.Empty,
                    ValorPorMin = custo.ValorPorMin
                })
                .ToList();

        public CustoChamada? ObterCustoChamadaPorOrigemEDestino(CalculosDTO calculos) =>
            Context.CustoChamada
            .FirstOrDefault(custoChamada => custoChamada.DestinoId == calculos.DestinoId
                && custoChamada.OrigemId == calculos.OrigemId);

        public bool ValidarValorECombinacaoOrigemDestino(CustoChamadaAtualizarDTO dto)
        {
            var custoChamadaAtual = BuscarPorId(dto.Id);
            if (custoChamadaAtual == null
                || !Context.DDD.Any(_ => _.Id == dto.OrigemId)
                || !Context.DDD.Any(_ => _.Id == dto.DestinoId)
                || dto.ValorPorMin <= 0)
                return false;
            return true;
        }

        public bool VerificarSeJaExiste(CustoChamadaCadastrarDTO dto) =>
            Context.CustoChamada.Any(_ =>
                _.OrigemId == dto.OrigemId
                && _.DestinoId == dto.DestinoId
                && !_.DataDelecao.HasValue);
    }
}
