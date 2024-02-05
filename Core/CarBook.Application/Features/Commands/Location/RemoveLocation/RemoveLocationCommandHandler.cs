using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Location.RemoveLocation
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommandRequest, RemoveLocationCommandResponse>
    {
        private readonly ILocationWriteRepository _locationWriteRepository;

        public RemoveLocationCommandHandler(ILocationWriteRepository locationWriteRepository)
        {
            _locationWriteRepository = locationWriteRepository;
        }

        public async Task<RemoveLocationCommandResponse> Handle(RemoveLocationCommandRequest request, CancellationToken cancellationToken)
        {
            await _locationWriteRepository.RemoveAsync(request.Id);
            await _locationWriteRepository.SaveAsync();
            return new();
        }
    }
}
