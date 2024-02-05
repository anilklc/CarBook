using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Service.GetAllService
{
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQueryRequest, GetAllServiceQueryResponse>
    {
        private readonly IServiceReadRepository _serviceReadRepository;

        public GetAllServiceQueryHandler(IServiceReadRepository serviceReadRepository)
        {
            _serviceReadRepository = serviceReadRepository;
        }

        public async Task<GetAllServiceQueryResponse> Handle(GetAllServiceQueryRequest request, CancellationToken cancellationToken)
        {
            var services = _serviceReadRepository.GetAll(false).ToList();
            return new()
            {
                Services = services,
            };
        }
    }
}
