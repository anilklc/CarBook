using CarBook.Application.Features.Queries.FooterAddress.GetByIdFooterAddress;
using MediatR;

namespace CarBook.Application.Features.Queries.FooterAddress.GetByIdFooterAddress
{
    public class GetByIdFooterAddressQueryRequest : IRequest<GetByIdFooterAddressQueryResponse>
    {
        public string Id { get; set; }
    }
}