using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.FooterAddress.UpdateFooterAddress
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommandRequest, UpdateFooterAddressCommandResponse>
    {
        private readonly IFooterAddressReadRepository _footerAddressReadRepository;
        private readonly IFooterAddressWriteRepository _footerAddressWriteRepository;

        public UpdateFooterAddressCommandHandler(IFooterAddressReadRepository footerAddressReadRepository, IFooterAddressWriteRepository footerAddressWriteRepository)
        {
            _footerAddressReadRepository = footerAddressReadRepository;
            _footerAddressWriteRepository = footerAddressWriteRepository;
        }

        public async Task<UpdateFooterAddressCommandResponse> Handle(UpdateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var footerAddress = await _footerAddressReadRepository.GetByIdAsync(request.Id);
            footerAddress.Description = request.Description;
            footerAddress.Address = request.Address;
            footerAddress.Phone = request.Phone;
            footerAddress.Email = request.Email;
            await _footerAddressWriteRepository.SaveAsync();
            return new();

        }
    }
}
