using FluentValidation;
using RentACar.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Core.Interfaces
{
    public interface IService<TEntity, Validator> where TEntity : Entity where Validator : AbstractValidator<TEntity>
    {
        TEntity Insert(TEntity entity, bool commit = true);

        TEntity Update(TEntity entity, bool commit = true);

        void Delete(Guid id, bool commit = true);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        void Commit();
    }
}
