using RentACar.Application.ViewModels;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface IModeloAppService : IAppService<Modelo, ModeloViewModel, ModeloValidator>
    {
        Task<ModeloViewModel> Insert(ModeloInsertViewModel model);

        Task<ModeloViewModel> Update(ModeloUpdateViewModel model);

        Task<IEnumerable<ModeloViewModel>> BuscarModelosPorMarca(Guid marcaId);
    }
}
