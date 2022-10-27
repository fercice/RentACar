using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.ViewModels
{
    public class SimulacaoViewModel
    {
        [DisplayName("Veiculo")]
        public VeiculoViewModel Veiculo { get; set; }

        [DisplayName("TotalHoras")]
        public int TotalHoras { get; set; }

        [DisplayName("ValorTotalSimulacao")]
        public double ValorTotalSimulacao { get; set; }
    }
}
