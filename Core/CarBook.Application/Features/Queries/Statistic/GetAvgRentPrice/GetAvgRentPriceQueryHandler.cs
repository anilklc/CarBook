using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetAvgRentPrice
{
    public class GetAvgRentPriceQueryHandler : IRequestHandler<GetAvgRentPriceQueryRequest, GetAvgRentPriceQueryResponse>
    {
        private readonly IPricingReadRepository _pricingReadRepository;
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetAvgRentPriceQueryHandler(IPricingReadRepository pricingReadRepository, ICarPricingReadRepository carPricingReadRepository)
        {
            _pricingReadRepository = pricingReadRepository;
            _carPricingReadRepository = carPricingReadRepository;
        }
        public async Task<GetAvgRentPriceQueryResponse> Handle(GetAvgRentPriceQueryRequest request, CancellationToken cancellationToken)
        {
            Guid dailyId= _pricingReadRepository.GetAll(false).Where(x =>x.Name == "Day").Select(p=>p.Id).FirstOrDefault();
            Guid weekId = _pricingReadRepository.GetAll(false).Where(x => x.Name == "Week").Select(p => p.Id).FirstOrDefault();
            Guid monthId = _pricingReadRepository.GetAll(false).Where(x => x.Name == "Month").Select(p => p.Id).FirstOrDefault();
            var daily = _carPricingReadRepository.GetAll(false).Where(p => p.PricingID == dailyId).Average(a=>a.Amount);
            var week = _carPricingReadRepository.GetAll(false).Where(p => p.PricingID == weekId).Average(a => a.Amount);
            var month = _carPricingReadRepository.GetAll(false).Where(p => p.PricingID == monthId).Average(a => a.Amount);
            return new()
            {
                Daily = daily,
                Monthly = month,
                Weekly = week,
            };

        }
    }
}
