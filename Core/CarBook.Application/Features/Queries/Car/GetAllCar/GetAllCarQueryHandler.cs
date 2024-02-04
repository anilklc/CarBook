using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Car.GetAllCar
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQueryRequest, GetAllCarQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetAllCarQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<GetAllCarQueryResponse> Handle(GetAllCarQueryRequest request, CancellationToken cancellationToken)
        {
            var cars = _carReadRepository.GetAll(false).ToList();
            return new() 
            {
                Cars=cars,
            };
        }
    }
}
