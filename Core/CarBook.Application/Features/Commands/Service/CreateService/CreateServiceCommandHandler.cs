using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Service.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommandRequest, CreateServiceCommandResponse>
    {
        private readonly IServiceWriteRepository _serviceWriteRepository;
        public CreateServiceCommandHandler(IServiceWriteRepository serviceWriteRepository)
        {
            _serviceWriteRepository = serviceWriteRepository;
        }

        public async Task<CreateServiceCommandResponse> Handle(CreateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceWriteRepository.AddAsync(new()
            {
                Title = request.Title,
                IconUrl = request.IconUrl,
                Description = request.Description,
            });
            await _serviceWriteRepository.SaveAsync();
            return new();
        }
    }
}
