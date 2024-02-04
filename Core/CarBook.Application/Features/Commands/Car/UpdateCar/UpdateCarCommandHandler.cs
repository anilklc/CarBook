using CarBook.Application.Features.Commands.Banner.RemoveBanner;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Car.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommandRequest, UpdateCarCommandResponse>
    {
        private readonly ICarReadRepository _carReadRepository;
        private readonly ICarWriteRepository _carWriteRepository;

        public UpdateCarCommandHandler(ICarWriteRepository carWriteRepository, ICarReadRepository carReadRepository)
        {
            _carWriteRepository = carWriteRepository;
            _carReadRepository = carReadRepository;
        }

        public async Task<UpdateCarCommandResponse> Handle(UpdateCarCommandRequest request, CancellationToken cancellationToken)
        {
            var car = await _carReadRepository.GetByIdAsync(request.Id);
            car.CarDescriptions = request.CarDescriptions;
            car.CarPricings = request.CarPricings;
            car.Transmission = request.Transmission;
            car.Luggage = request.Luggage;
            car.BigImageUrl = request.BigImageUrl;
            car.Brand = request.Brand;
            car.CoverImageUrl = request.CoverImageUrl;
            car.Fuel = request.Fuel;
            car.Km = request.Km;
            car.Model = request.Model;
            car.BrandID = request.BrandID;
            car.CarFeatures = request.CarFeatures;
            car.Seat = request.Seat;
            await _carWriteRepository.SaveAsync();
            return new();
        }
    }
}
