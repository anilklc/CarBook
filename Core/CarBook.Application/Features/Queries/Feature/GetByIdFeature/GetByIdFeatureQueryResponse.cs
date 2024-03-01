using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Feature.GetByIdFeature
{
    public class GetByIdFeatureQueryResponse
    {
        public string Name { get; set; }
        public List<Domain.Entities.CarFeature> CarFeatures { get; set; }
    }
}