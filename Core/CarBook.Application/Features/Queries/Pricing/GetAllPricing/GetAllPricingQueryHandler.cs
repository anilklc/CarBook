using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Pricing.GetAllPricing
{
    public class GetAllPricingQueryHandler : IRequestHandler<GetAllPricingQueryRequest, GetAllPricingQueryResponse>
    {
        private readonly IPricingReadRepository _pricingReadRepository;

        public GetAllPricingQueryHandler(IPricingReadRepository pricingReadRepository)
        {
            _pricingReadRepository = pricingReadRepository;
        }

        public async Task<GetAllPricingQueryResponse> Handle(GetAllPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var pricings = _pricingReadRepository.GetAll(false).ToList();
            return new()
            {
                Pricings = pricings,
            };
        }
    }
}
