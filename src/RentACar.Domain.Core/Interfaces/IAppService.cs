using FluentValidation;
using RentACar.Domain.Core.Models;
using RentACar.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Domain.Core.Interfaces
{
    public interface IAppService<TEntity, TModel, Validator>
        where TEntity : Entity
        where TModel : Model
        where Validator : AbstractValidator<TEntity>
    {
        TModel Insert(TModel model);

        TModel Update(TModel model);

        void Delete(Guid id);

        Task<IEnumerable<TModel>> GetAll();

        Task<TModel> GetById(Guid id);        
    }
}
