using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetLastFiveCar
{
    public class GetLastFiveCarQueryHandler : IRequestHandler<GetLastFiveCarQueryRequest, GetLastFiveCarQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;
        private readonly IMapper _mapper;
        private readonly IBrandReadRepository _brandReadRepository;
        public GetLastFiveCarQueryHandler(ICarReadRepository carReadRepository, IMapper mapper, IBrandReadRepository brandReadRepository)
        {
            _carReadRepository = carReadRepository;
            _mapper = mapper;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetLastFiveCarQueryResponse> Handle(GetLastFiveCarQueryRequest request, CancellationToken cancellationToken)
        {
            var carsAndBrand = _carReadRepository.GetAll(false).OrderByDescending(c=>c.Id).Take(5).ToList();
            var mapper = _mapper.Map<List<CarAndBrandDto>>(carsAndBrand);

            foreach (var carAndBrandDto in mapper)
            {
                var brand = _brandReadRepository.GetAll(false);
                carAndBrandDto.BrandName = brand.FirstOrDefault(b => b.Id == carAndBrandDto.BrandID).Name;
            }

            return new()
            {
                CarAndBrandDto = mapper
            };
        }
    }
}
