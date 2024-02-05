using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.FooterAddress.GetAllFooterAddress
{
    public class GetAllFooterAddressQueryHandler : IRequestHandler<GetAllFooterAddressQueryRequest, GetAllFooterAddressQueryResponse>
    {
        private readonly IFooterAddressReadRepository _footerAddressReadRepository;

        public GetAllFooterAddressQueryHandler(IFooterAddressReadRepository footerAddressReadRepository)
        {
            _footerAddressReadRepository = footerAddressReadRepository;
        }

        public async Task<GetAllFooterAddressQueryResponse> Handle(GetAllFooterAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var footeradress = _footerAddressReadRepository.GetAll(false).ToList();
            return new()
            {
                FooterAddress = footeradress,
            };
        }
    }
}
