using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Pricing.CreatePricing
{
    public class CreatePricingCommandRequest : IRequest<CreatePricingCommandResponse>
    {
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}