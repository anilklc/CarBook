using CarBook.Application.Features.Queries.Pricing.GetByIdPricing;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdPricingQueryHandler : IRequestHandler<GetByIdPricingQueryRequest, GetByIdPricingQueryResponse>
    {
        private readonly IPricingReadRepository _pricingReadRepository;

        public GetByIdPricingQueryHandler(IPricingReadRepository pricingReadRepository)
        {
            _pricingReadRepository = pricingReadRepository;
        }

        public async Task<GetByIdPricingQueryResponse> Handle(GetByIdPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var pricing = await _pricingReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                CarPricings = pricing.CarPricings,
                Name = pricing.Name
            };
        }
    }
}

