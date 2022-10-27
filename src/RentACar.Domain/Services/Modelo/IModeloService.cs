using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace RentACar.Domain.Services
{
    public interface IModeloService : IService<Modelo, ModeloValidator>
    {
        Task<IEnumerable<Modelo>> BuscarModelosPorMarca(Guid marcaId);
    }
}
