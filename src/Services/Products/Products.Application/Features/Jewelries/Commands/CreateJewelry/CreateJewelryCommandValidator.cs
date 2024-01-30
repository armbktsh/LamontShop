namespace Products.Application.Features.Jewelries.Commands.CreateJewelry;

public class CreateJewelryCommandValidator : AbstractValidator<CreateJewelryCommand>
{
    public CreateJewelryCommandValidator()
    {
        Include(new BaseJewelryCommandValidator());
    }
}
