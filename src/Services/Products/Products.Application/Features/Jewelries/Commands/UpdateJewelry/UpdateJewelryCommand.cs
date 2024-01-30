using Products.Application.Features.Jewelries.Commands.Common;

namespace Products.Application.Features.Jewelries.Commands.UpdateJewelry;

public class UpdateJewelryCommand : BaseJewelryCommand, IRequest
{
    public int Id { get; set; }
}

public class UpdateJewelryCommandHandler : IRequestHandler<UpdateJewelryCommand>
{
    private readonly IJewelryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateJewelryCommandHandler(IJewelryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateJewelryCommand request, CancellationToken cancellationToken)
    {
        var jewelry = await _repository.GetJewelryAsync(request.Id);
        if (jewelry == null) throw new NotFoundException(nameof(Jewelry), request.Id);

        _mapper.Map(request, jewelry);
        await _repository.UpdateJewelryAsync(jewelry);

        return Unit.Value;
    }
}