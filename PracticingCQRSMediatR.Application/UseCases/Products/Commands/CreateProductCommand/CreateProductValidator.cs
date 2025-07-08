using FluentValidation;
namespace PracticingCQRSMediatR.Application.UseCases.Products.Commands.CreateProductCommand;

public class CreateProductValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is Required")
            .MinimumLength(20).WithMessage("{PropertyName} cannot be less than 20 characters");
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}
