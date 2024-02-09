using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Features.Queries.Car.GetCarWithPricing;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetCarWithPricingDay
{
    public class GetCarWithPricingDayQueryHandler : IRequestHandler<GetCarWithPricingDayQueryRequest, GetCarWithPricingDayQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IPricingReadRepository _pricingReadRepository;
        private readonly ICarPricingReadRepository _carPricingReadRepository;
        private readonly IMapper _mapper;

        public GetCarWithPricingDayQueryHandler(ICarReadRepository carReadRepository, IBrandReadRepository brandReadRepository, IPricingReadRepository pricingReadRepository, IMapper mapper, ICarPricingReadRepository carPricingReadRepository)
        {
            _carReadRepository = carReadRepository;
            _brandReadRepository = brandReadRepository;
            _pricingReadRepository = pricingReadRepository;
            _mapper = mapper;
            _carPricingReadRepository = carPricingReadRepository;
        }
        public async Task<GetCarWithPricingDayQueryResponse> Handle(GetCarWithPricingDayQueryRequest request, CancellationToken cancellationToken)
        {
            var cars = _carReadRepository.GetAll(false).ToList();
            var carIds = cars.Select(c => c.Id).ToList();

            // Arabaların marka bilgilerini al
            var brands = _brandReadRepository.GetAll(false).ToList();

            // CarPricings tablosundan tüm verileri al
            var carPricings = _carPricingReadRepository.GetAll(false).ToList();

            // Pricing tablosundan fiyat adlarını al
            var pricingNames = _pricingReadRepository.GetAll(false).ToDictionary(p => p.Id, p => p.Name);

            // Araba DTO'larını oluştur
            var carDtos = cars.Select(car =>
            {
                var carDto = _mapper.Map<CarAndPricingDayDto>(car);
                var brand = brands.FirstOrDefault(b => b.Id == car.BrandID);
                if (brand != null)
                    carDto.BrandName = brand.Name;

                var carPricing = carPricings.FirstOrDefault(cp => cp.CarID == car.Id && cp.PricingID == Guid.Parse("05556568-bf9c-4679-48f5-08dc2980f1d6"));
                if (carPricing != null)
                {
                    carDto.PricingName = pricingNames.ContainsKey(carPricing.PricingID) ? pricingNames[carPricing.PricingID] : "";
                    carDto.PricingAmount = carPricing.Amount;
                }

                return carDto;
            }).ToList();

            return new GetCarWithPricingDayQueryResponse
            {
                CarAndPricings = carDtos
            };
        }
    }
}
