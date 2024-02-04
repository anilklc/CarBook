using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Brand.RemoveBrand
{
    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommandRequest, RemoveBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;

        public RemoveBrandCommandHandler(IBrandWriteRepository brandWriteRepository)
        {
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<RemoveBrandCommandResponse> Handle(RemoveBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandWriteRepository.RemoveAsync(request.Id);
            await _brandWriteRepository.SaveAsync();
            return new();
        }
    }
}
