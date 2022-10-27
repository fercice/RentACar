using RentACar.Domain.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.ViewModels
{
    public class VeiculoInsertViewModel
    {
        [Required(ErrorMessage = "Placa é obrigatório")]
        [MinLength(7, ErrorMessage = "Placa deve ter 7 caracteres")]
        [MaxLength(7, ErrorMessage = "Placa deve ter 7 caracteres")]        
        [DisplayName("Placa")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório")]
        [MinLength(4, ErrorMessage = "Ano deve ter 4 caracteres")]
        [MaxLength(4, ErrorMessage = "Ano deve ter 4 caracteres")]
        [DisplayName("Ano")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "Combustível é obrigatório")]
        [DisplayName("Combustivel")]
        public EnumCombustivel Combustivel { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório")]
        [DisplayName("Categoria")]
        public EnumCategoria Categoria { get; set; }

        [Required(ErrorMessage = "Valor Hora é obrigatório")]
        [DisplayName("ValorHora")]
        public double ValorHora { get; set; }

        [Required(ErrorMessage = "Limite Porta Malas é obrigatório")]
        [DisplayName("LimitePortaMalas")]
        public double LimitePortaMalas { get; set; }

        [Required(ErrorMessage = "Id do Modelo é obrigatório")]
        public Guid ModeloId { get; set; }
    }
}
