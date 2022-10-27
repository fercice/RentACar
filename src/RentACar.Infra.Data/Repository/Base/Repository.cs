using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Core.Entities;
using RentACar.Domain.Core.Interfaces;
using RentACar.Infra.Data.Context;
using RentACar.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly UnitOfWork _unitOfWork;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
            _dbSet = context.Set<TEntity>();
        }

        protected RentACarContext context { get { return _unitOfWork._context; } }
        protected RentACarContext newcontext = new RentACarContext();

        public void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await newcontext.Set<TEntity>().OrderBy(e => e.DataInclusao).AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await newcontext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> CreateQuery()
        {
            return newcontext.Set<TEntity>().AsNoTracking();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
