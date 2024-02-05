using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Pricing.UpdatePricing
{
    public class UpdatePricingCommandRequest : IRequest<UpdatePricingCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }

    }
}