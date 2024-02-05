using CarBook.Application.Features.Commands.Feature.UpdateFeature;
using CarBook.Application.Features.Commands.Location.UpdateLocation;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Location.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest, UpdateLocationCommandResponse>
    {
        private readonly ILocationReadRepository _locationReadRepository;
        private readonly ILocationWriteRepository _locationWriteRepository;

        public UpdateLocationCommandHandler(ILocationReadRepository locationReadRepository, ILocationWriteRepository locationWriteRepository)
        {
            _locationReadRepository = locationReadRepository;
            _locationWriteRepository = locationWriteRepository;
        }

        public async Task<UpdateLocationCommandResponse> Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = await _locationReadRepository.GetByIdAsync(request.Id);
            location.Name = request.Name;
            await _locationWriteRepository.SaveAsync();
            return new();

        }
    }
}
