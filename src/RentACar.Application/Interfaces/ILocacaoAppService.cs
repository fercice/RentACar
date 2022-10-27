using RentACar.Application.ViewModels;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface ILocacaoAppService
    {
        Task<SimulacaoViewModel> Simulacao(SimulacaoConsultaViewModel model);
    }
}
