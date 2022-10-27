using RentACar.Application.ViewModels;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface IVeiculoAppService : IAppService<Veiculo, VeiculoViewModel, VeiculoValidator>        
    {
        Task<VeiculoViewModel> Insert(VeiculoInsertViewModel model);

        Task<VeiculoViewModel> Update(VeiculoUpdateViewModel model);

        Task<IEnumerable<VeiculoViewModel>> BuscarVeiculosPorMarca(Guid marcaId);
    }
}
