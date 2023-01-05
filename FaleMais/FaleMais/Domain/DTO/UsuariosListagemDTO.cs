namespace Domain.DTO
{
    public sealed class UsuariosListagemDTO
    {
        public DateTime DataCriacao { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Autorizacao { get; set; } = string.Empty;
    }
}
