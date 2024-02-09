using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Car.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CreateCarCommandResponse>
    {
        private readonly ICarWriteRepository _carWriteRepository;

        public CreateCarCommandHandler(ICarWriteRepository carWriteRepository)
        {
            _carWriteRepository = carWriteRepository;
        }

        public async Task<CreateCarCommandResponse> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
        {
            await _carWriteRepository.AddAsync(new ()
            {
                 
                Transmission = request.Transmission,
                Luggage = request.Luggage,
                BigImageUrl = request.BigImageUrl,
                CoverImageUrl = request.CoverImageUrl,
                Fuel = request.Fuel,
                Km = request.Km,
                Model = request.Model,
                BrandID = request.BrandID,
                Seat = request.Seat,
             });
            await _carWriteRepository.SaveAsync();
            return new();
        }
    }
}
