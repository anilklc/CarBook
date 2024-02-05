using CarBook.Application.Features.Queries.Pricing.GetByIdPricing;
using MediatR;

namespace CarBook.Application.Features.Queries.Pricing.GetByIdPricing
{
    public class GetByIdPricingQueryRequest : IRequest<GetByIdPricingQueryResponse>
    {
        public string Id { get; set; }
    }
}