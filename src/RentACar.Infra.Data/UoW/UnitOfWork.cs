using RentACar.Domain.Core.Interfaces;
using RentACar.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public RentACarContext _context;

        public UnitOfWork(RentACarContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var success = await _context.Commit();

            return success;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
