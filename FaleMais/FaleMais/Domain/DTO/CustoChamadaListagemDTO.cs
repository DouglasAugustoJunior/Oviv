﻿namespace Domain.DTO
{
    public sealed class CustoChamadaListagemDTO
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public double ValorPorMin { get; set; }
    }
}
