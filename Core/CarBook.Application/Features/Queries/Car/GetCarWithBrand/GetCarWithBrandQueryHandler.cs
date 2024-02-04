using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetCarWithBrand
{
    public class GetCarWithBrandQueryHandler : IRequestHandler<GetCarWithBrandQueryRequest, GetCarWithBrandQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;
        private readonly IMapper _mapper;
        private readonly IBrandReadRepository _brandReadRepository;
        public GetCarWithBrandQueryHandler(ICarReadRepository carReadRepository, IMapper mapper, IBrandReadRepository brandReadRepository)
        {
            _carReadRepository = carReadRepository;
            _mapper = mapper;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetCarWithBrandQueryResponse> Handle(GetCarWithBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var carsAndBrand = _carReadRepository.GetAll(false).ToList();
            var mapper = _mapper.Map<List<CarAndBrandDto>>(carsAndBrand);

            foreach (var carAndBrandDto in mapper) 
            {
                var brand = _brandReadRepository.GetAll(false);
                carAndBrandDto.BrandName = brand.FirstOrDefault(b=>b.Id==carAndBrandDto.BrandID).Name;
            }

            return new()
            {
                CarAndBrandDto=mapper
            };

        }
    }
}
