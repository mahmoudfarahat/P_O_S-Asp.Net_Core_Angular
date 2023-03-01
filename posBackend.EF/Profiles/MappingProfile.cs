using AutoMapper;
using posBackend.EF.DTOS;
using posBackend.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap()
                .ForMember(c => c.Products, o => o.Ignore());
                
            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductUnit, ProductUnitsDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<OpenBalance, OpenBalanceDTO>()
                .ReverseMap()
                .ForMember(s => s.store, u => u.Ignore());
            CreateMap<OpenBalanceDt, OpenBalanceDtDto>()
               .ReverseMap()
               .ForMember(o => o.OpenBalance, u => u.Ignore())
               .ForMember(p => p.Product, u => u.Ignore())
               .ForMember(u => u.Unit, u => u.Ignore());

        }
    
    }
}
