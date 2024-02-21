using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetCarCount
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQueryRequest, GetCarCountQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetCarCountQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<GetCarCountQueryResponse> Handle(GetCarCountQueryRequest request, CancellationToken cancellationToken)
        {
            var carCount = _carReadRepository.GetAll(false).Count();
            return new()
            {
                CarCount = carCount,
            };
        }
    }
}
