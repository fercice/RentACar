using FluentValidation;
using RentACar.Domain.Entities;
using System;

namespace RentACar.Domain.Validators
{
    public class ModeloValidator : AbstractValidator<Modelo>
    {
        public ModeloValidator()
        {
            RuleFor(o => o)
                .NotNull()
                .WithMessage("No data found");

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

            RuleFor(o => o.Nome)
                .NotNull()
                .NotEmpty()                
                .WithMessage("Nome é obrigatório");

            RuleFor(o => o.MarcaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Marca é obrigatório");
        }
    }
}
