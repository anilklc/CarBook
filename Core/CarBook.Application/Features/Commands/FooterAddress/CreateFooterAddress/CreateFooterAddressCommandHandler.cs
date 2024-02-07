using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.FooterAddress.CreateFooterAddress
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommandRequest, CreateFooterAddressCommandResponse>
    {
        private readonly IFooterAddressWriteRepository _footerAddressWriteRepository;

        public CreateFooterAddressCommandHandler(IFooterAddressWriteRepository footerAddressWriteRepository)
        {
            _footerAddressWriteRepository = footerAddressWriteRepository;
        }

        public async Task<CreateFooterAddressCommandResponse> Handle(CreateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _footerAddressWriteRepository.AddAsync(new()
            {
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone,
            });
            await _footerAddressWriteRepository.SaveAsync();
            return new();

        }
    }
}
