using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using RentACar.Domain.Repository;

namespace RentACar.Domain.Services
{
    public class VeiculoService : Service<Veiculo, VeiculoValidator>, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IUnitOfWork unitOfWork, IRepository<Veiculo> repository, IVeiculoRepository veiculoRepository)
            : base(unitOfWork, repository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public override async Task<IEnumerable<Veiculo>> GetAll()
        {
            return await _veiculoRepository.GetAll();
        }

        public override async Task<Veiculo> GetById(Guid id)
        {
            return await _veiculoRepository.GetById(id);
        }

        public async Task<IEnumerable<Veiculo>> BuscarVeiculosPorMarca(Guid marcaId)
        {
            return await _veiculoRepository.BuscarVeiculosPorMarca(marcaId);
        }
    }
}
