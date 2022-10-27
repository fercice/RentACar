using AutoMapper;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Services;
using RentACar.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Application.Services
{
    public class ModeloAppService : AppService<Modelo, ModeloViewModel, ModeloValidator>, IModeloAppService
    {
        private readonly IMapper _mapper;        
        private readonly IModeloService _modeloService;

        public ModeloAppService(IMapper mapper, IService<Modelo, ModeloValidator> service, IModeloService modeloService)
            : base(mapper, service)
        {
            _mapper = mapper;            
            _modeloService = modeloService;
        }

        public async Task<ModeloViewModel> Insert(ModeloInsertViewModel model)
        {
            var insertCommand = _mapper.Map<Modelo>(model);
            var resultCommand = _mapper.Map<ModeloViewModel>(_modeloService.Insert(insertCommand));

            return await GetById(resultCommand.Id);
        }

        public async Task<ModeloViewModel> Update(ModeloUpdateViewModel model)
        {
            var updateCommand = _mapper.Map<Modelo>(model);
            var resultCommand = _mapper.Map<ModeloViewModel>(_modeloService.Update(updateCommand));

            return await GetById(resultCommand.Id);
        }
        public override async Task<IEnumerable<ModeloViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<Modelo>, IEnumerable<ModeloViewModel>>(await _modeloService.GetAll());
        }

        public override async Task<ModeloViewModel> GetById(Guid id)
        {
            return _mapper.Map<ModeloViewModel>(await _modeloService.GetById(id));
        }


        public async Task<IEnumerable<ModeloViewModel>> BuscarModelosPorMarca(Guid marcaId)
        {
            return _mapper.Map<IEnumerable<Modelo>, IEnumerable<ModeloViewModel>>(await _modeloService.BuscarModelosPorMarca(marcaId));
        }
    }
}
