using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
        {            
        }

        public override async Task<IEnumerable<Veiculo>> GetAll()
        {
            return await CreateQueryWithInclude().ToListAsync();
        }

        public override async Task<Veiculo> GetById(Guid id)
        {
            return await CreateQueryWithInclude().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<Veiculo>> BuscarVeiculosPorMarca(Guid marcaId)
        {
            return await CreateQueryWithInclude().Where(c => c.MarcaId.Equals(marcaId)).ToListAsync();
        }

        private IQueryable<Veiculo> CreateQueryWithInclude()
        {
            return CreateQuery()
                    .Include(x => x.Modelo).ThenInclude(x => x.Marca)
                    .AsNoTracking();
        }
    }
}
