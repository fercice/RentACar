using RentACar.Application.ViewModels;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Validators;

namespace RentACar.Application.Interfaces
{
    public interface IMarcaAppService : IAppService<Marca, MarcaViewModel, MarcaValidator> { }
}
