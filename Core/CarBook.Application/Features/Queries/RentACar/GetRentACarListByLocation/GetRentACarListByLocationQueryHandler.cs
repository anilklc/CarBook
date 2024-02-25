using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Features.Queries.RentACar.GetRentACarListByLocation
{
    public class GetRentACarListByLocationQueryHandler : IRequestHandler<GetRentACarListByLocationQueryRequest, GetRentACarListByLocationQueryResponse>
    {
        private readonly IRentACarReadRepository _rentACarReadRepository;

        public GetRentACarListByLocationQueryHandler(IRentACarReadRepository rentACarReadRepository)
        {
            _rentACarReadRepository = rentACarReadRepository;
        }

        public async Task<GetRentACarListByLocationQueryResponse> Handle(GetRentACarListByLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _rentACarReadRepository.GetWhere(c => c.LocationID == request.Id && c.Available == request.available).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            var cars = values.Select(car => new RentACarDto
            {
                Id = car.Car.Id,
                Brand = car.Car.Brand.Name,
                Model = car.Car.Model,
                CoverImageUrl = car.Car.CoverImageUrl
            });

            return new GetRentACarListByLocationQueryResponse
            {
                Cars = cars.ToList(),
            };

        }
    }
}
