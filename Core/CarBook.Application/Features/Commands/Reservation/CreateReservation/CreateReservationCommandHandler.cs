using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Reservation.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandRequest, CreateReservationCommandResponse>
    {
        private readonly IReservationWriteRepository _reservationWriteRepository;

        public CreateReservationCommandHandler(IReservationWriteRepository reservationWriteRepository)
        {
            _reservationWriteRepository = reservationWriteRepository;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommandRequest request, CancellationToken cancellationToken)
        {
            await _reservationWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age,
                CarID = request.CarID,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                DropOffLocationID = request.DropOffLocationID,
                PickUpLocationID = request.PickUpLocationID,
                Status= "Reservation Received",
            });
            await _reservationWriteRepository.SaveAsync();
            return new();
        }
    }
}
