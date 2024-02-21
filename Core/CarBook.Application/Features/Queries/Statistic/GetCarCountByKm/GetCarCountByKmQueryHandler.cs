using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetCarCountByKm
{
    public class GetCarCountByKmQueryHandler : IRequestHandler<GetCarCountByKmQueryRequest, GetCarCountByKmQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetCarCountByKmQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<GetCarCountByKmQueryResponse> Handle(GetCarCountByKmQueryRequest request, CancellationToken cancellationToken)
        {
            var km = _carReadRepository.GetAll(false).Where(k=>k.Km<=100000).Count();
            return new()
            {
                Km = km,
            };
        }
    }
}
