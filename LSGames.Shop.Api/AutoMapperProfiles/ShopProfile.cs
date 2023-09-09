using AutoMapper;
using LSGames.Shop.Api.Models.ServiceModels;
using LSGames.Shop.Api.Models.ViewModels;
using LSGames.Shop.Repository.Models;

namespace LSGames.Shop.Api.AutoMapperProfiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<GoodViewModel, GoodServiceModel>().ReverseMap();
            CreateMap<GoodServiceModel, Good>().ReverseMap();
            CreateMap<GetCartGoodsRequestViewModel, GetCartGoodsRequestServiceModel>();
            CreateMap<CartGoodViewModel, CartGoodServiceModel>().ReverseMap();
            CreateMap<CartGoodServiceModel, Cart>().ReverseMap();
            CreateMap<SaveCartRequestViewModel, SaveCartRequestServiceModel>();
            CreateMap<CartViewModel, CartServiceModel>().ReverseMap();
            CreateMap<CartServiceModel, Cart>().ReverseMap();
        }
    }
}
