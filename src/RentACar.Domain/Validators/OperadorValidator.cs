using FluentValidation;
using RentACar.Domain.Entities;
using System;

namespace RentACar.Domain.Validators
{
    public class OperadorValidator : AbstractValidator<Operador>
    {
        public OperadorValidator()
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

            RuleFor(c => c.Matricula)
                .NotNull()
                .NotEmpty()
                .WithMessage("Matrícula é obrigatório");
        }
    }
}
