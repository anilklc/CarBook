using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Car.GetCarWithBrandWithPricing
{
	public class GetCarWithBrandWithPricingQueryResponse
	{
		public List<CarAndBrandAndPricingDto> Cars { get; set; }
	}
}