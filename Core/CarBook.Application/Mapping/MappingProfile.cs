using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarAndBrandDto>();
            CreateMap<Brand, CarAndBrandDto>().ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.Id));
        }
        
    }
}
