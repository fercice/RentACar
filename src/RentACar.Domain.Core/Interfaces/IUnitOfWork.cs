using System;
using System.Threading.Tasks;

namespace RentACar.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
