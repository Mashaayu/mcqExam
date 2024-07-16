using AutoMapper;
using E_Commerce.Models;
using E_Commerce.Models.DTOS;

namespace E_Commerce.Automapper_Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(m => m.ProductType, t => t.MapFrom(x => x.ProductType.Name))
                .ForMember(m => m.ProductBrand, t => t.MapFrom(x => x.ProductBrand.Name));
        }
    }
}
