namespace Products.Application.Common.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Jewelry, JewelryListDto>().ReverseMap();
        CreateMap<Jewelry, JewelryDetailDto>().ReverseMap();
        CreateMap<Jewelry, CreateJewelryCommand>().ReverseMap();
        CreateMap<Jewelry, UpdateJewelryCommand>().ReverseMap();
        CreateMap<Jewelry, DeleteJewelryCommand>().ReverseMap();
    }
}