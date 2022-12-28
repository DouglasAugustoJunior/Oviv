namespace FaleMais.Domain
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataDelecao { get; set; }

        public void AdicionarDataDelecao()
        {
            DataDelecao = DateTime.Now;
        }
    }
}
