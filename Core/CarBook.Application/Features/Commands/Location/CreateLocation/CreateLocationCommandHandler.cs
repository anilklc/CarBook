using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Location.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, CreateLocationCommandResponse>
    {
        private readonly ILocationWriteRepository _locationWriteRepository;

        public CreateLocationCommandHandler(ILocationWriteRepository locationWriteRepository)
        {
            _locationWriteRepository = locationWriteRepository;
        }

        public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            await _locationWriteRepository.AddAsync(new()
            {
                Name = request.Name,
            });
            await _locationWriteRepository.SaveAsync();
            return new();
        }
    }
}
