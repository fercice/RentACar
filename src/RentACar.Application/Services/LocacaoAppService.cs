using AutoMapper;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;
using RentACar.Domain.Services;
using System.Threading.Tasks;

namespace RentACar.Application.Services
{
    public class LocacaoAppService : ILocacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoService _veiculoService;

        public LocacaoAppService(IMapper mapper, IVeiculoService veiculoService)
        {
            _mapper = mapper;
            _veiculoService = veiculoService;
        }

        public async Task<SimulacaoViewModel> Simulacao(SimulacaoConsultaViewModel model)
        {
            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoService.GetById(model.VeiculoId));

            SimulacaoViewModel simulacao  = new SimulacaoViewModel() { 
                Veiculo = veiculoViewModel,
                TotalHoras = model.TotalHoras,
                ValorTotalSimulacao = veiculoViewModel.ValorHora * model.TotalHoras
            };

            return simulacao;
        }        
    }
}
