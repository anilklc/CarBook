using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Pricing.GetByIdPricing
{
    public class GetByIdPricingQueryResponse
    {
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}