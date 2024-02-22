using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.RentACar.CreateRentACar
{
    public class CreateRentACarCommandHandler : IRequestHandler<CreateRentACarCommandRequest, CreateRentACarCommandResponse>
    {
        private readonly IRentACarWriteRepository _rentACarWriteRepository;

        public CreateRentACarCommandHandler(IRentACarWriteRepository rentACarWriteRepository)
        {
            _rentACarWriteRepository = rentACarWriteRepository;
        }

        public async Task<CreateRentACarCommandResponse> Handle(CreateRentACarCommandRequest request, CancellationToken cancellationToken)
        {
            await _rentACarWriteRepository.AddAsync(new()
            {
                LocationID = request.LocationID,
                CarID = request.CarID,
                Available = request.Available,
            });
            await _rentACarWriteRepository.SaveAsync();
            return new();
        }
    }
}
