using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.FooterAddress.GetByIdFooterAddress
{
    public class GetByIdFooterAddressQueryHandler : IRequestHandler<GetByIdFooterAddressQueryRequest, GetByIdFooterAddressQueryResponse>
    {
        private readonly IFooterAddressReadRepository _footerAddressReadRepository;

        public GetByIdFooterAddressQueryHandler(IFooterAddressReadRepository footerAddressReadRepository)
        {
           _footerAddressReadRepository = footerAddressReadRepository;
        }

        public async Task<GetByIdFooterAddressQueryResponse> Handle(GetByIdFooterAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var footerAdress = await _footerAddressReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Address = footerAdress.Address,
                Description = footerAdress.Description,
                Email = footerAdress.Email,
                Phone = footerAdress.Phone,
            };
         
        }
    }
}

