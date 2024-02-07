using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Car.GetLastFiveCar
{
    public class GetLastFiveCarQueryResponse
    {
        public List<CarAndBrandDto> CarAndBrandDto { get; set; }
    }
}