using FluentValidation;
using RentACar.Domain.Entities;
using System;

namespace RentACar.Domain.Validators
{
    public class MarcaValidator : AbstractValidator<Marca>
    {
        public MarcaValidator()
        {
            RuleFor(o => o)
                .NotNull().WithMessage("No data found");

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

            RuleFor(o => o.Nome)
                .NotNull().WithMessage("Nome é obrigatório")
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(3, 50).WithMessage("O Nome deve ter entre 3 e 50 caracteres");
        }
    }
}
