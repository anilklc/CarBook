using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetByIdCar
{
    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQueryRequest, GetByIdCarQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetByIdCarQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<GetByIdCarQueryResponse> Handle(GetByIdCarQueryRequest request, CancellationToken cancellationToken)
        {
            var car = await _carReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = car.Id.ToString(),
                BigImageUrl = car.BigImageUrl,
                BrandID = car.BrandID,
                CoverImageUrl = car.CoverImageUrl,
                Fuel = car.Fuel,
                Km = car.Km,
                Luggage = car.Luggage,
                Model = car.Model,
                Seat = car.Seat,
                Transmission = car.Transmission,
                  
            };
        }
    }
}
