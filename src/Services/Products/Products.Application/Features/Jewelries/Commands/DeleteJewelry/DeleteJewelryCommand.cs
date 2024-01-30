namespace Products.Application.Features.Jewelries.Commands.DeleteJewelry;

public record DeleteJewelryCommand(int Id) : IRequest;

public class DeleteJewelryCommandHandler : IRequestHandler<DeleteJewelryCommand>
{
    private readonly IJewelryRepository _repository;
    private readonly IMapper _mapper;

    public DeleteJewelryCommandHandler(IJewelryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteJewelryCommand request, CancellationToken cancellationToken)
    {
        var jewelry = await _repository.GetJewelryAsync(request.Id);
        if (jewelry == null) throw new NotFoundException(nameof(Jewelry), request.Id);

        await _repository.DeleteJewelryAsync(jewelry);

        return Unit.Value;
    }
}