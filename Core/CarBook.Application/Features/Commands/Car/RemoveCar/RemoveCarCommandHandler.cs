using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Car.RemoveCar
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommandRequest, RemoveCarCommandResponse>
    {
        private readonly ICarWriteRepository _carWriteRepository;

        public RemoveCarCommandHandler(ICarWriteRepository carWriteRepository)
        {
            _carWriteRepository = carWriteRepository;
        }

        public async Task<RemoveCarCommandResponse> Handle(RemoveCarCommandRequest request, CancellationToken cancellationToken)
        {
            await _carWriteRepository.RemoveAsync(request.Id);
            await _carWriteRepository.SaveAsync();
            return new();
        }
    }
}
