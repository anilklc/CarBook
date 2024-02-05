using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.FooterAddress.RemoveFooterAddress
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommandRequest, RemoveFooterAddressCommandResponse>
    {
        private readonly IFooterAddressWriteRepository _footerAddressWriteRepository;

        public RemoveFooterAddressCommandHandler(IFooterAddressWriteRepository footerAddressWriteRepository)
        {
            _footerAddressWriteRepository = footerAddressWriteRepository;
        }

        public async Task<RemoveFooterAddressCommandResponse> Handle(RemoveFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _footerAddressWriteRepository.RemoveAsync(request.Id);
            await _footerAddressWriteRepository.SaveAsync();
            return new();
        }
    }
}
