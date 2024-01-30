using Products.Application.Features.Jewelries.Commands.Common;

namespace Products.Application.Features.Jewelries.Commands.CreateJewelry;

public class CreateJewelryCommand : BaseJewelryCommand, IRequest<int>
{
}

public class CreateJewelryCommandHandler : IRequestHandler<CreateJewelryCommand, int>
{
    private readonly IJewelryRepository _repository;
    private readonly IMapper _mapper;

    public CreateJewelryCommandHandler(IJewelryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateJewelryCommand request, CancellationToken cancellationToken)
    {
        var jewelry = _mapper.Map<Jewelry>(request);
        await _repository.CreateJewelryAsync(jewelry);
        return jewelry.Id;
    }
}