using CarBook.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            // var car = await _carReadRepository.GetByIdAsync(request.Id);
            var car =  _carReadRepository.GetWhere(c => c.Id == request.Id).Include(b => b.Brand).FirstOrDefault();
            
            return new()
            {
               Id = car.Id.ToString(),
                BigImageUrl = car.BigImageUrl,
                BrandID = car.BrandID,
                BrandName = car.Brand.Name,
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
