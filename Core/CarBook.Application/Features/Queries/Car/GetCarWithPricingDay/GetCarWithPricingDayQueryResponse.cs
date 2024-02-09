using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Car.GetCarWithPricingDay
{
    public class GetCarWithPricingDayQueryResponse
    {
        public List<CarAndPricingDayDto> CarAndPricings { get; set; }
    }
}