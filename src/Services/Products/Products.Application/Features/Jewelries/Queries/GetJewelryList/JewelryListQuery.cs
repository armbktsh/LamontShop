namespace Products.Application.Features.Jewelries.Queries.GetJewelryList;

public class GetJewelryListQuery : IRequest<List<JewelryListDto>>
{
}

public class GetJewelryListQueryHandler : IRequestHandler<GetJewelryListQuery, List<JewelryListDto>>
{
    private readonly IJewelryRepository _repository;
    private readonly IMapper _mapper;

    public GetJewelryListQueryHandler(IJewelryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<JewelryListDto>> Handle(GetJewelryListQuery request, CancellationToken cancellationToken)
    {
        //await Task.Delay(3000);
        return _mapper.Map<List<JewelryListDto>>(await _repository.GetJewelriesAsync());
    }
}