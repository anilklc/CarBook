using CarBook.Application.Features.Commands.Pricing.RemovePricing;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Pricing.RemovePricing
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommandRequest, RemovePricingCommandResponse>
    {
        private readonly IPricingWriteRepository _pricingWriteRepository;

        public RemovePricingCommandHandler(IPricingWriteRepository pricingWriteRepository)
        {
            _pricingWriteRepository = pricingWriteRepository;
        }

        public async Task<RemovePricingCommandResponse> Handle(RemovePricingCommandRequest request, CancellationToken cancellationToken)
        {
            await _pricingWriteRepository.RemoveAsync(request.Id);
            await _pricingWriteRepository.SaveAsync();
            return new();
        }
    }
}
