namespace Products.Application.Features.Jewelries.Commands.Common;

public class BaseJewelryCommandValidator : AbstractValidator<BaseJewelryCommand>
{
    public BaseJewelryCommandValidator()
    {
        RuleFor(j => j.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(j => j.Country)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(j => j.Image)
            .NotEmpty()
            .NotNull();

        RuleFor(j => j.Price)
            .GreaterThan(1);

        RuleFor(j => j.Substance)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        //TODO: Check if categoryId exists with grpc
        RuleFor(j => j.CategoryId)
            .GreaterThan(0);
    }
}