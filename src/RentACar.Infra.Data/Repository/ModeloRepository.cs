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
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<Modelo>> GetAll()
        {
            return await CreateQueryWithInclude().ToListAsync();
        }

        public override async Task<Modelo> GetById(Guid id)
        {
            return await CreateQueryWithInclude().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<Modelo>> BuscarModelosPorMarca(Guid marcaId)
        {
            return await CreateQueryWithInclude().Where(c => c.MarcaId.Equals(marcaId)).ToListAsync();
        }

        private IQueryable<Modelo> CreateQueryWithInclude()
        {
            return CreateQuery().Include(x => x.Marca).AsNoTracking();
        }
    }
}
