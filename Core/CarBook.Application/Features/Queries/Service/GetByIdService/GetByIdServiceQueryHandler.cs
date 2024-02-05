using CarBook.Application.Features.Queries.Service.GetByIdService;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Service.GetByIdService
{
    public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQueryRequest, GetByIdServiceQueryResponse>
    {
        private readonly IServiceReadRepository _serviceReadRepository;

        public GetByIdServiceQueryHandler(IServiceReadRepository serviceReadRepository)
        {
            _serviceReadRepository = serviceReadRepository;
        }

        public async Task<GetByIdServiceQueryResponse> Handle(GetByIdServiceQueryRequest request, CancellationToken cancellationToken)
        { 
            var service = await _serviceReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Description = service.Description,
                IconUrl = service.IconUrl,
                Title = service.Title,
            };
        }
    }
}

