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
    public class VeiculoAppService : AppService<Veiculo, VeiculoViewModel, VeiculoValidator>, IVeiculoAppService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoService _veiculoService;
        private readonly IModeloService _modeloService;

        public VeiculoAppService(IMapper mapper, 
                                 IService<Veiculo, VeiculoValidator> service, 
                                 IVeiculoService veiculoService, 
                                 IModeloService modeloService)
            : base(mapper, service)
        {
            _mapper = mapper;
            _veiculoService = veiculoService;
            _modeloService = modeloService;
        }

        public async Task<VeiculoViewModel> Insert(VeiculoInsertViewModel model)
        {
            var modeloViewModel = await GetByIdModelo(model.ModeloId);

            var insertCommand = _mapper.Map<Veiculo>(model);
            insertCommand.MarcaId = modeloViewModel.Marca.Id;

            var resultCommand = _mapper.Map<VeiculoViewModel>(_veiculoService.Insert(insertCommand));

            return await GetById(resultCommand.Id);
        }
        public async Task<VeiculoViewModel> Update(VeiculoUpdateViewModel model)
        {
            var modeloViewModel = await GetByIdModelo(model.ModeloId);

            var updateCommand = _mapper.Map<Veiculo>(model);
            updateCommand.MarcaId = modeloViewModel.Marca.Id;

            var resultCommand = _mapper.Map<VeiculoViewModel>(_veiculoService.Update(updateCommand));

            return await GetById(resultCommand.Id);
        }

        public override async Task<IEnumerable<VeiculoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoViewModel>>(await _veiculoService.GetAll());
        }

        public override async Task<VeiculoViewModel> GetById(Guid id)
        {
            return _mapper.Map<VeiculoViewModel>(await _veiculoService.GetById(id));
        }

        public async Task<IEnumerable<VeiculoViewModel>> BuscarVeiculosPorMarca(Guid marcaId)
        {
            return _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoViewModel>>(await _veiculoService.BuscarVeiculosPorMarca(marcaId));
        }

        private async Task<ModeloViewModel> GetByIdModelo(Guid id)
        {
            return _mapper.Map<ModeloViewModel>(await _modeloService.GetById(id));
        }
    }
}
