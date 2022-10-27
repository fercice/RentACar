using AutoMapper;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;

namespace RentACar.Application.Services
{
    public class MarcaAppService : AppService<Marca, MarcaViewModel, MarcaValidator>, IMarcaAppService
    {        
        public MarcaAppService(IMapper mapper, IService<Marca, MarcaValidator> service)
            : base(mapper, service) { }
    }
}
