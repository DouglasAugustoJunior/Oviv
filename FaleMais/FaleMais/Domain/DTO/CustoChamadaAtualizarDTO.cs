﻿using System.ComponentModel.DataAnnotations;

namespace FaleMais.Domain.DTO
{
    public class CustoChamadaAtualizarDTO
    {
        [Required(ErrorMessage = "Preencha o campo ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Origem")]
        public int OrigemId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Destino")]
        public int DestinoId { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Precisa ser maior que R${1}.")]
        [Required(ErrorMessage = "Preencha o campo 'Valor Por Minuto'")]
        public double ValorPorMin { get; set; }

        internal CustoChamada ToCustoChamada() =>
            new CustoChamada()
            {
                Id = Id,
                OrigemId = OrigemId,
                DestinoId = DestinoId,
                ValorPorMin = ValorPorMin
            };
    }
}