using CarBook.Application.Features.Commands.Pricing.RemovePricing;
using MediatR;

namespace CarBook.Application.Features.Commands.Pricing.RemovePricing
{
    public class RemovePricingCommandRequest : IRequest<RemovePricingCommandResponse>
    {
        public string Id { get; set; }
    }
}