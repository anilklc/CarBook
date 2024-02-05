using CarBook.Application.Features.Commands.Feature.UpdateFeature;
using CarBook.Application.Features.Commands.Pricing.UpdatePricing;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Feature.UpdateFeature
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommandRequest, UpdatePricingCommandResponse>
    {
        private readonly IPricingReadRepository _pricingReadRepository;
        private readonly IPricingWriteRepository _pricingWriteRepository;

        public UpdatePricingCommandHandler(IPricingReadRepository pricingReadRepository, IPricingWriteRepository pricingWriteRepository)
        {
            _pricingReadRepository = pricingReadRepository;
            _pricingWriteRepository = pricingWriteRepository;
        }

        public async Task<UpdatePricingCommandResponse> Handle(UpdatePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var pricing = await _pricingReadRepository.GetByIdAsync(request.Id);
            pricing.Name = request.Name;
            pricing.CarPricings = request.CarPricings;
            await _pricingWriteRepository.SaveAsync();
            return new();

        }
    }
}
