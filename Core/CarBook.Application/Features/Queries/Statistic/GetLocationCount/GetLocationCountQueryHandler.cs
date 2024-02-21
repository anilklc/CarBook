using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetLocationCount
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQueryRequest, GetLocationCountQueryResponse>
    {
        private readonly ILocationReadRepository _locationReadRepository;

        public GetLocationCountQueryHandler(ILocationReadRepository locationReadRepository)
        {
            _locationReadRepository = locationReadRepository;
        }

        public async Task<GetLocationCountQueryResponse> Handle(GetLocationCountQueryRequest request, CancellationToken cancellationToken)
        {
            var locationCount = _locationReadRepository.GetAll(false).Count();
            return new() 
            {
               LocationCount = locationCount,
            };
        }
    }
}
