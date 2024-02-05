using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Location.GetByIdLocation
{
    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQueryRequest, GetByIdLocationQueryResponse>
    {
        private readonly ILocationReadRepository _locationReadRepository;

        public GetByIdLocationQueryHandler(ILocationReadRepository locationReadRepository)
        {
            _locationReadRepository = locationReadRepository;
        }

        public async Task<GetByIdLocationQueryResponse> Handle(GetByIdLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var location = await _locationReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Name = location.Name,
            };
           
        }
    }
}

