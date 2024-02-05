using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Pricing.CreatePricing
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommandRequest, CreatePricingCommandResponse>
    {
        private readonly IPricingWriteRepository _pricingWriteRepository;

        public CreatePricingCommandHandler(IPricingWriteRepository pricingWriteRepository)
        {
            _pricingWriteRepository = pricingWriteRepository;
        }

        public async Task<CreatePricingCommandResponse> Handle(CreatePricingCommandRequest request, CancellationToken cancellationToken)
        {
            await _pricingWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                CarPricings = request.CarPricings,
            });
            await _pricingWriteRepository.SaveAsync();
            return new();
        }
    }
}
