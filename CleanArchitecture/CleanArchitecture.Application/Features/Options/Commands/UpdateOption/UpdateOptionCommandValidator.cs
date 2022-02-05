using FluentValidation;

namespace CleanArchitecture.Application.Features.Options.Commands.UpdateOption
{
    public class UpdateOptionCommandValidator : AbstractValidator<UpdateOptionCommand>
    {
        public UpdateOptionCommandValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{Code} no puede estar en blanco")
                .NotNull()
                .MaximumLength(20).WithMessage("{Code} no puede ser mayor a 20 caracteres");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} no puede estar en blanco")
                .NotNull();
        }
    }
}
