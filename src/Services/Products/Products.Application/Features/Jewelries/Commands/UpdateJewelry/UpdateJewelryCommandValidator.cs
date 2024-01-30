namespace Products.Application.Features.Jewelries.Commands.UpdateJewelry;

public class UpdateJewelryCommandValidator : AbstractValidator<UpdateJewelryCommand>
{
    public UpdateJewelryCommandValidator()
    {
        Include(new BaseJewelryCommandValidator());

        RuleFor(j => j.Id)
            .GreaterThan(0);
    }
}