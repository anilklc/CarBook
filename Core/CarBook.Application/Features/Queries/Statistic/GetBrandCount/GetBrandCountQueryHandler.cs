using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetBrandCount
{
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQueryRequest, GetBrandCountQueryResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;

        public GetBrandCountQueryHandler(IBrandReadRepository brandReadRepository)
        {
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetBrandCountQueryResponse> Handle(GetBrandCountQueryRequest request, CancellationToken cancellationToken)
        {
            var brandCount = _brandReadRepository.GetAll(false).Count();
            return new()
            {
                BrandCount = brandCount,
            };
        }
    }
}
