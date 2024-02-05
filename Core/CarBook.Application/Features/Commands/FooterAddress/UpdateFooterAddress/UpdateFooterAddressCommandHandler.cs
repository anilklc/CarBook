using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.FooterAddress.UpdateFooterAddress
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommandRequest, UpdateFooterAddressCommandResponse>
    {
        public Task<UpdateFooterAddressCommandResponse> Handle(UpdateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
