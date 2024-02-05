using CarBook.Application.Features.Commands.Feature.UpdateFeature;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Service.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest, UpdateServiceCommandResponse>
    {
        private readonly IServiceReadRepository _serviceReadRepository;
        private readonly IServiceWriteRepository _serviceWriteRepository;

        public UpdateServiceCommandHandler(IServiceReadRepository serviceReadRepository, IServiceWriteRepository serviceWriteRepository)
        {
            _serviceReadRepository = serviceReadRepository;
            _serviceWriteRepository = serviceWriteRepository;
        }

        public async Task<UpdateServiceCommandResponse> Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var service = await _serviceReadRepository.GetByIdAsync(request.Id);
            service.Description = request.Description;
            service.Title = request.Title;
            service.IconUrl = request.IconUrl;
            await _serviceWriteRepository.SaveAsync();
            return new();

        }
    }
}
