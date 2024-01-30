namespace Products.Application.Features.Jewelries.Queries.GetJewelryDetail;

public record GetJewelryDetailQuery(int Id) : IRequest<JewelryDetailDto>;

public class GetJewelryDetailQueryHandler : IRequestHandler<GetJewelryDetailQuery, JewelryDetailDto>
{
    private readonly IJewelryRepository _repository;
    private readonly IMapper _mapper;

    public GetJewelryDetailQueryHandler(IJewelryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JewelryDetailDto> Handle(GetJewelryDetailQuery request, CancellationToken cancellationToken)
    {
        var jewelry = await _repository.GetJewelryAsync(request.Id);
        if (jewelry == null) throw new NotFoundException(nameof(Jewelry), request.Id);

        return _mapper.Map<JewelryDetailDto>(jewelry);
    }
}