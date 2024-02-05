using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Feature.GetByIdFeature
{
    public class GetByIdFeatureQueryResponse
    {
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}