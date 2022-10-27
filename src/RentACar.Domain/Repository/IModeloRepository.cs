using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Repository
{
    public interface IModeloRepository : IRepository<Modelo>
    {
        Task<IEnumerable<Modelo>> BuscarModelosPorMarca(Guid marcaId);
    }
}