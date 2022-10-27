using AutoMapper;
using RentACar.Application.ViewModels;
using RentACar.Domain.Entities;

namespace RentACar.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModelToViewModel
            CreateMap<MarcaInsertViewModel, MarcaViewModel>();
            CreateMap<MarcaUpdateViewModel, MarcaViewModel>();

            CreateMap<ModeloInsertViewModel, ModeloViewModel>();
            CreateMap<ModeloUpdateViewModel, ModeloViewModel>();

            CreateMap<VeiculoInsertViewModel, VeiculoViewModel>();
            CreateMap<VeiculoUpdateViewModel, VeiculoViewModel>();

            // DomainToViewModel <=> ViewModelToDomain
            CreateMap<Marca, MarcaViewModel>().ReverseMap();

            CreateMap<Modelo, ModeloViewModel>().ReverseMap();
            CreateMap<Modelo, ModeloInsertViewModel>().ReverseMap();
            CreateMap<Modelo, ModeloUpdateViewModel>().ReverseMap();

            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoInsertViewModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoUpdateViewModel>().ReverseMap();
        }
    }
}
