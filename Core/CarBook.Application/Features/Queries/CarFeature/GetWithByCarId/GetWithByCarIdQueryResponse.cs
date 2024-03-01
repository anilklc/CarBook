using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.CarFeature.GetWithByCarId
{
    public class GetWithByCarIdQueryResponse
    {
        public List<CarFeatureDto> CarFeatures { get; set; }
    }
}