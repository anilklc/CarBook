using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetCarWithBrandWithPricing
{
	public class GetCarWithBrandWithPricingQueryHandler : IRequestHandler<GetCarWithBrandWithPricingQueryRequest, GetCarWithBrandWithPricingQueryResponse>
	{
		private readonly ICarReadRepository _carReadRepository;

		public GetCarWithBrandWithPricingQueryHandler(ICarReadRepository carReadRepository, IBrandReadRepository brandReadRepository)
		{
			_carReadRepository = carReadRepository;
		}

		public async Task<GetCarWithBrandWithPricingQueryResponse> Handle(GetCarWithBrandWithPricingQueryRequest request, CancellationToken cancellationToken)
		{
			var values = await _carReadRepository.GetAll().Include(b => b.Brand).Include(cp=>cp.CarPricings).ThenInclude(p=>p.Pricing).ToListAsync();
			var cars = values.Select(car => new CarAndBrandAndPricingDto
			{
				Id = car.Id.ToString(),
				Model = car.Model,
				BrandName = car.Brand.Name,
				CoverImageUrl = car.CoverImageUrl,
				Monthly = car.CarPricings.FirstOrDefault(cp => cp.Pricing.Name == "Month")?.Amount ?? 0m,
				Daily = car.CarPricings.FirstOrDefault(cp => cp.Pricing.Name == "Day")?.Amount ?? 0m,
				Weekly = car.CarPricings.FirstOrDefault(cp => cp.Pricing.Name == "Week")?.Amount ?? 0m,

			});

			return new()
			{
				Cars = cars.ToList(),
			};

		}
	}
}
