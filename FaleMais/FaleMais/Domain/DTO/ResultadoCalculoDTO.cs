namespace FaleMais.Domain.DTO
{
    public sealed class ResultadoCalculoDTO
    {
        public string Plano { get; set; } = string.Empty;
        public double TotalPlano { get; set; }
        public double TotalSemPlano { get; set; }
    }
}
