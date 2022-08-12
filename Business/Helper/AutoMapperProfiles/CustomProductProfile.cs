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
    public class CustomProductProfile : Profile
    {
        public CustomProductProfile()
        {


            CreateMap<ProductCategory, CustomProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))

               .ReverseMap();
            CreateMap<CustomProductDTO, ProductCategory>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
