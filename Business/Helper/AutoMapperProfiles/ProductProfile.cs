using AutoMapper;
using Entities.Concrete;
using Entities.ECommerceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductCategoryDTO, opt => opt.MapFrom(src => src.ProductCategory))

               .ReverseMap();
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategoryDTO))

                .ReverseMap();

        }
    }
}
