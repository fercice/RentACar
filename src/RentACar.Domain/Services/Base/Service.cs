using FluentValidation;
using RentACar.Domain.Core.Entities;
using RentACar.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Services
{
    public class Service<TEntity, Validator> : IService<TEntity, Validator> where TEntity : Entity where Validator : AbstractValidator<TEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual TEntity Insert(TEntity entity, bool commit = true)
        {
            entity.Id = Guid.NewGuid();

            Validate(entity, Activator.CreateInstance<Validator>());

            _repository.Insert(entity);

            if (commit) Commit();

            return entity;
        }

        public virtual TEntity Update(TEntity entity, bool commit = true)
        {
            Validate(entity, Activator.CreateInstance<Validator>());

            _repository.Update(entity);

            if (commit)
            {
                Commit();
                return GetById(entity.Id).Result;
            }             

            return entity;
        }

        public virtual void Delete(Guid id, bool commit = true)
        {
            _repository.Delete(id);

            if (commit) Commit();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private static void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            validator.ValidateAndThrow(obj);
        }
    }
}
