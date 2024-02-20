using AutoMapper;
using TimoShopApi.Models;
using TimoShopApi.Responses;

namespace TimoShopApi.Mappers;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.StorageAvailableAmount, opts => opts.MapFrom(src => src.StorageAmount - src.CartAmount));
    }
}
