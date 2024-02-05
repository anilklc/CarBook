using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Service.RemoveService
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommandRequest, RemoveServiceCommandResponse>
    {
        private readonly IServiceWriteRepository _serviceWriteRepository;

        public RemoveServiceCommandHandler(IServiceWriteRepository serviceWriteRepository)
        {
            _serviceWriteRepository = serviceWriteRepository;
        }

        public async Task<RemoveServiceCommandResponse> Handle(RemoveServiceCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceWriteRepository.RemoveAsync(request.Id);
            await _serviceWriteRepository.SaveAsync();
            return new();
        }
    }
}
