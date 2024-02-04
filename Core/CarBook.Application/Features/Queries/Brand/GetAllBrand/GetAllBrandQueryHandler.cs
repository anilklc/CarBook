using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Brand.GetAllBrand
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQueryRequest, GetAllBrandQueryResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;

        public GetAllBrandQueryHandler(IBrandReadRepository brandReadRepository)
        {
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetAllBrandQueryResponse> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = _brandReadRepository.GetAll(false).ToList();
            return new()
            {
                Brands = brands,
            };
        }
    }
}
