using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.ViewModels
{
    public class SimulacaoConsultaViewModel
    {
        [Required(ErrorMessage = "Id do Veiculo é obrigatório")]
        public Guid VeiculoId { get; set; }

        [Required(ErrorMessage = "Total de Horas é obrigatório")]
        [DisplayName("TotalHoras")]
        public int TotalHoras { get; set; }
    }
}
