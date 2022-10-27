using RentACar.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity obj);        

        void Update(TEntity obj);

        void Delete(Guid id);        

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        IQueryable<TEntity> CreateQuery();

        int SaveChanges();       
    }
}

