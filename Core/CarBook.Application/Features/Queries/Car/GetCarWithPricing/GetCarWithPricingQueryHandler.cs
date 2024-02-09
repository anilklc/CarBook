using AutoMapper;
using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetCarWithPricing
{
    public class GetCarWithPricingQueryHandler : IRequestHandler<GetCarWithPricingQueryRequest, GetCarWithPricingQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IPricingReadRepository _pricingReadRepository;
        private readonly ICarPricingReadRepository _carPricingReadRepository;
        private readonly IMapper _mapper;

        public GetCarWithPricingQueryHandler(ICarReadRepository carReadRepository, IBrandReadRepository brandReadRepository, IPricingReadRepository pricingReadRepository, IMapper mapper, ICarPricingReadRepository carPricingReadRepository)
        {
            _carReadRepository = carReadRepository;
            _brandReadRepository = brandReadRepository;
            _pricingReadRepository = pricingReadRepository;
            _mapper = mapper;
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<GetCarWithPricingQueryResponse> Handle(GetCarWithPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var cars = _carReadRepository.GetAll(false).ToList();
            var brands = _brandReadRepository.GetAll(false).ToList();
            var carIds = cars.Select(c => c.Id).ToList();
            var carPricings = _carPricingReadRepository.GetAll(false).ToList();
            var pricingNames = _pricingReadRepository.GetAll(false).ToDictionary(p => p.Id, p => p.Name);
            var carDtos = new List<CarAndPricingDto>();

            foreach (var car in cars)
            {
                var carDto = _mapper.Map<CarAndPricingDto>(car);
                var brand = brands.FirstOrDefault(b => b.Id == car.BrandID);
                if (brand != null)
                    carDto.BrandName = brand.Name;
                var carPricingList = carPricings.Where(cp => cp.CarID == car.Id).ToList();
                carDto.Pricings = new List<PricingDto>();

                foreach (var carPricing in carPricingList)
                {
                    var pricingDto = new PricingDto
                    {
                        PricingId = carPricing.PricingID,
                        PricingName = pricingNames.ContainsKey(carPricing.PricingID) ? pricingNames[carPricing.PricingID] : "",
                        PricingAmount = carPricing.Amount
                    };
                    carDto.Pricings.Add(pricingDto);
                }

                carDtos.Add(carDto);
            }

            return new()
            {
                CarAndPricings = carDtos
            };
        }
    }
}
