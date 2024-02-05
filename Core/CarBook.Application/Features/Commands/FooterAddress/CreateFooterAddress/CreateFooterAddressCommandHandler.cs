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
        private readonly IFooterAddressReadRepository _footerAddressReadRepository;
        private readonly IFooterAddressWriteRepository _footerAddressWriteRepository;

        public CreateFooterAddressCommandHandler(IFooterAddressReadRepository footerAddressReadRepository, IFooterAddressWriteRepository footerAddressWriteRepository)
        {
            _footerAddressReadRepository = footerAddressReadRepository;
            _footerAddressWriteRepository = footerAddressWriteRepository;
        }

        public async Task<CreateFooterAddressCommandResponse> Handle(CreateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var footerAdress = await _footerAddressReadRepository.GetByIdAsync(request.Id);
            footerAdress.Address = request.Address;
            footerAdress.Phone = request.Phone;
            footerAdress.Email = request.Email;
            footerAdress.Description = request.Description;
            await _footerAddressWriteRepository.SaveAsync();
            return new();

        }
    }
}
