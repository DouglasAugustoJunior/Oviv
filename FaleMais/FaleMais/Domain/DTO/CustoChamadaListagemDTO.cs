namespace FaleMais.Domain.DTO
{
    public class CustoChamadaListagemDTO
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double ValorPorMin { get; set; }
    }
}
