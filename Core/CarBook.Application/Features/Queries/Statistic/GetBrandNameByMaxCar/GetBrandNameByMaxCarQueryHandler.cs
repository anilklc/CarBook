using CarBook.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Statistic.GetBrandNameByMaxCar
{
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQueryRequest, GetBrandNameByMaxCarQueryResponse>
    {
        private readonly ICarReadRepository _carReadRepository;
        private readonly IBrandReadRepository _brandReadRepository;

        public GetBrandNameByMaxCarQueryHandler(ICarReadRepository carReadRepository, IBrandReadRepository brandReadRepository)
        {
            _carReadRepository = carReadRepository;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetBrandNameByMaxCarQueryResponse> Handle(GetBrandNameByMaxCarQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _carReadRepository.GetAll(false).GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName =  _brandReadRepository.GetAll(false).Where(x => x.Id == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return new()
            {
                BrandName = brandName
            };
        }
    }
}
