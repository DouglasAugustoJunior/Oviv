using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Plano : EntidadeBase
    {
        [Required]
        public int MinutosGratuitos { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;
    }
}
