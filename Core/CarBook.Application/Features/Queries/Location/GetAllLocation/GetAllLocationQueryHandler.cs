using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Location.GetAllLocation
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQueryRequest, GetAllLocationQueryResponse>
    {
        private readonly ILocationReadRepository _locationReadRepository;

        public GetAllLocationQueryHandler(ILocationReadRepository locationReadRepository)
        {
            _locationReadRepository = locationReadRepository;
        }

        public async Task<GetAllLocationQueryResponse> Handle(GetAllLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var locations = _locationReadRepository.GetAll(false).ToList();
            return new()
            {
                Locations = locations,
            };
        }
    }
}
