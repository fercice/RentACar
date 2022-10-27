using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using RentACar.Domain.Repository;

namespace RentACar.Domain.Services
{
    public class ModeloService : Service<Modelo, ModeloValidator>, IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IUnitOfWork unitOfWork, IRepository<Modelo> repository, IModeloRepository modeloRepository)
            : base(unitOfWork, repository)
        {
            _modeloRepository = modeloRepository;
        }

        public override async Task<IEnumerable<Modelo>> GetAll()
        {
            return await _modeloRepository.GetAll();
        }

        public override async Task<Modelo> GetById(Guid id)
        {
            return await _modeloRepository.GetById(id);
        }

        public async Task<IEnumerable<Modelo>> BuscarModelosPorMarca(Guid marcaId)
        {
            return await _modeloRepository.BuscarModelosPorMarca(marcaId);
        }
    }
}
