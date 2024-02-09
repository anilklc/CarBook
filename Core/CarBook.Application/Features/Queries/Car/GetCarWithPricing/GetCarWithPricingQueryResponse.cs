using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Car.GetCarWithPricing
{
    public class GetCarWithPricingQueryResponse
    {
        public List<CarAndPricingDto> CarAndPricings { get; set; }
    }
}