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

            CreateMap<Blog, BlogAndAuthorDto>();
            CreateMap<Author, BlogAndAuthorDto>().ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.Id));
            CreateMap<Car, CarAndPricingDto>()
                 .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.BrandID))
                 .ForMember(dest => dest.BrandName, opt => opt.Ignore())
                 .ForMember(dest => dest.Pricings, opt => opt.Ignore());
            CreateMap<Category, BlogAndAuthorDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.Id));

            CreateMap<Pricing, PricingDto>();
            CreateMap<Car, CarAndPricingDayDto>()
           .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.BrandID))
           .ForMember(dest => dest.BrandName, opt => opt.Ignore())
           .ForMember(dest => dest.PricingId, opt => opt.Ignore())
           .ForMember(dest => dest.PricingName, opt => opt.Ignore())
           .ForMember(dest => dest.PricingAmount, opt => opt.Ignore());
        }
        
    }
}
