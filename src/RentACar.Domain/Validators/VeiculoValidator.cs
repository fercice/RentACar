using FluentValidation;
using RentACar.Domain.Entities;
using System;

namespace RentACar.Domain.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(o => o)
                .NotNull()
                .WithMessage("No data found");

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

            RuleFor(o => o.Placa)
                .NotNull()
                .NotEmpty()
                .WithMessage("Placa é obrigatório");            

            RuleFor(o => o.MarcaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Marca é obrigatório");

            RuleFor(o => o.ModeloId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Modelo é obrigatório");

            RuleFor(c => c.Ano)
                .NotNull()
                .NotEmpty()
                .WithMessage("Ano é obrigatório");

            RuleFor(o => o.Combustivel)
                .NotNull()
                .NotEmpty()
                .WithMessage("Combustível é obrigatório");

            RuleFor(o => o.Categoria)
                .NotNull()
                .NotEmpty()
                .WithMessage("Categoria é obrigatório");

            RuleFor(c => c.ValorHora)
                .NotNull()
                .NotEmpty()
                .WithMessage("Valor Hora é obrigatório");

            RuleFor(c => c.LimitePortaMalas)
                .NotNull()
                .NotEmpty()
                .WithMessage("Limite do Porta Malas é obrigatório");

        }
    }
}
