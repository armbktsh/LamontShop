namespace Baskets.API.Profiles;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<Basket, BasketDTO>().ReverseMap();
        CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
    }
}