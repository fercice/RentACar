using AutoMapper;
using FluentValidation;
using RentACar.Application.ViewModels;
using RentACar.Domain.Core.Entities;
using RentACar.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Application.Services
{
    public class AppService<TEntity, VModel, Validator> 
        : IAppService<TEntity, VModel, Validator> where TEntity : Entity where VModel : BaseViewModel where Validator : AbstractValidator<TEntity>
    {
        private readonly IMapper _mapper;        
        private readonly IService<TEntity, Validator> _service;

        public AppService(IMapper mapper, IService<TEntity, Validator> service)
        {
            _mapper = mapper;
            _service = service;            
        }

        public virtual VModel Insert(VModel model)
        {
            var insertCommand = _mapper.Map<TEntity>(model);
            var resultCommand = _mapper.Map<VModel>(_service.Insert(insertCommand));            

            return resultCommand;
        }

        public virtual VModel Update(VModel model)
        {
            var updateCommand = _mapper.Map<TEntity>(model);
            var resultCommand = _mapper.Map<VModel>(_service.Update(updateCommand));            

            return resultCommand;
        }


        public virtual void Delete(Guid id)
        {
            _service.Delete(id);            
        }

        public virtual async Task<IEnumerable<VModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<VModel>>(await _service.GetAll());
        }

        public virtual async Task<VModel> GetById(Guid id)
        {
            return _mapper.Map<VModel>(await _service.GetById(id));
        }        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
