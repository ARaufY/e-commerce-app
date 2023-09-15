using AutoMapper;
using core.Entities;

namespace API;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(m => m.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(m => m.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }

}
