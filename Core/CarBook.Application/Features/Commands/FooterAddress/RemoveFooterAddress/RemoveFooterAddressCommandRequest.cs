using MediatR;

namespace CarBook.Application.Features.Commands.FooterAddress.RemoveFooterAddress
{
    public class RemoveFooterAddressCommandRequest : IRequest<RemoveFooterAddressCommandResponse>
    {
        public string Id { get; set; }
    }
}