using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;

        public GetByIdBrandQueryHandler(IBrandReadRepository brandReadRepository)
        {
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Name = brand.Name,
                Cars = brand.Cars,
            };
        }
    }
}
