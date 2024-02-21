using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetCarCountByFuel
{
    public class GetCarCountByFuelQueryHandler : IRequestHandler<GetCarCountByFuelQueryRequest, GetCarCountByFuelQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetCarCountByFuelQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<GetCarCountByFuelQueryResponse> Handle(GetCarCountByFuelQueryRequest request, CancellationToken cancellationToken)
        {
            var electric = _carReadRepository.GetAll(false).Where(c=>c.Fuel == "Electric").Count();
            var gasoline = _carReadRepository.GetAll(false).Where(c => c.Fuel == "Gasoline" || c.Fuel =="Diesel").Count();
            return new()
            {
                Electric = electric,
                Gasoline = gasoline,
            };

        }
    }
}
