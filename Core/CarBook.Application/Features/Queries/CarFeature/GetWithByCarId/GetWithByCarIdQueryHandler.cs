using CarBook.Application.DTOs;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.CarFeature.GetWithByCarId
{
    public class GetWithByCarIdQueryHandler : IRequestHandler<GetWithByCarIdQueryRequest, GetWithByCarIdQueryResponse>
    {
        private readonly ICarFeatureReadRepository _carFeatureReadRepository;

        public GetWithByCarIdQueryHandler(ICarFeatureReadRepository carFeatureReadRepository)
        {
            _carFeatureReadRepository = carFeatureReadRepository;
        }

        public async Task<GetWithByCarIdQueryResponse> Handle(GetWithByCarIdQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _carFeatureReadRepository.GetAll(false).Where(c=>c.CarID == request.Id).Include(cf=>cf.Feature).ToListAsync();
            var carfeatures= values.Select(car => new CarFeatureDto 
            { 
                FeatureId = car.FeatureID.ToString(),
                FeatureName = car.Feature.Name,
                Available = car.Available,
                CarFeatureId = car.Id.ToString(),
            });

            return new()
            {
                CarFeatures = carfeatures.ToList(),
            };
        }
    }
}
