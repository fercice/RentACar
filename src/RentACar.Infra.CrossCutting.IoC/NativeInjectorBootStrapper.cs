using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Interfaces;
using RentACar.Application.Services;
using RentACar.Domain.Core.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Domain.Repository;
using RentACar.Domain.Services;
using RentACar.Domain.Validators;
using RentACar.Infra.Data.Context;
using RentACar.Infra.Data.Repository;
using RentACar.Infra.Data.UoW;

namespace RentACar.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext Dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddScoped<ILocacaoAppService, LocacaoAppService>();
            services.AddScoped<IMarcaAppService, MarcaAppService>();
            services.AddScoped<IModeloAppService, ModeloAppService>();
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();

            // Service
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            // Service - Generic Service CRUD
            services.AddScoped<IService<Marca, MarcaValidator>, Service<Marca, MarcaValidator>>();
            services.AddScoped<IService<Modelo, ModeloValidator>, Service<Modelo, ModeloValidator>>();
            services.AddScoped<IService<Operador, OperadorValidator>, Service<Operador, OperadorValidator>>();
            services.AddScoped<IService<Veiculo, VeiculoValidator>, Service<Veiculo, VeiculoValidator>>();

            // Infra - Data
            services.AddScoped<RentACarContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data - Repository
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            // Infra - Data - Repository - Generic Repository CRUD
            services.AddScoped<IRepository<Marca>, Repository<Marca>>();
            services.AddScoped<IRepository<Modelo>, Repository<Modelo>>();
            services.AddScoped<IRepository<Operador>, Repository<Operador>>();
            services.AddScoped<IRepository<Veiculo>, Repository<Veiculo>>();
        }
    }
}