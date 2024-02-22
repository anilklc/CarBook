using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var carId = _rentACarReadRepository.GetAll(false).Where(c => c.LocationID == request.Id && c.Available == request.available).Select(c=>c.CarID).ToList();
            return new ()
            {
              CarId = carId,
            };
        }
    }
}
