using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace RentACar.Domain.Services
{
    public interface IVeiculoService : IService<Veiculo, VeiculoValidator>
    {
        Task<IEnumerable<Veiculo>> BuscarVeiculosPorMarca(Guid marcaId);
    }
}
