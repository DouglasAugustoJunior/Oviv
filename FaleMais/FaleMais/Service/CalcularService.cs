using MiniValidation;
using FaleMais.Domain;
using FaleMais.Domain.DTO;
using FaleMais.Infrastructure;
using FaleMais.Service.Interface;
using FaleMais.Repository.Interface;

namespace FaleMais.Service
{
    public class CalcularService: ICalcularService
    {
        private readonly ICustoChamadaRepository _custoChamadaRepository;
        private readonly IBaseRepository<Plano> _planoRepository;

        public CalcularService(
            ICustoChamadaRepository custoChamadaRepository,
            IBaseRepository<Plano> planoRepository)
        {
            _custoChamadaRepository = custoChamadaRepository;
            _planoRepository = planoRepository;
        }

        public IResult Calcular(CalculosDTO calculos)
        {
            if (!MiniValidator.TryValidate(calculos, out var erros))
                return Results.BadRequest(ValidacoesUtils.ObterErros(erros));
            var custoChamadaSelecionado = _custoChamadaRepository.ObterCustoChamadaPorOrigemEDestino(calculos);
            if(custoChamadaSelecionado == null)
                return Results.NotFound("Não foi possível encontrar essa combinação Origem/Destino.");
            var planosDisponiveis = _planoRepository.Listar()
                .Select(plano => new ResultadoCalculoDTO()
                {
                    Plano = plano.Nome,
                    TotalPlano = CalcularTotalPlano(calculos.QtdeMin, plano.MinutosGratuitos, custoChamadaSelecionado.ValorPorMin),
                    TotalSemPlano = CalcularTotalSemPlano(calculos.QtdeMin, custoChamadaSelecionado.ValorPorMin)
                })
                .ToList();
            return Results.Ok(planosDisponiveis);
        }

        public static decimal CalcularTotalPlano(int qtdeMinutos, int minutosGratuitos, decimal valorPorMin) =>
            qtdeMinutos <= minutosGratuitos ? 0 : (qtdeMinutos - minutosGratuitos) * (valorPorMin * 1.1m);

        public static decimal CalcularTotalSemPlano(int qtdeMinutos, decimal valorPorMin) =>
            qtdeMinutos * valorPorMin;
    }
}
