using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Feature.GetByIdFeature
{
    public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQueryRequest, GetByIdFeatureQueryResponse>
    {
        private readonly IFeatureReadRepository _featureReadRepository;

        public GetByIdFeatureQueryHandler(IFeatureReadRepository featureReadRepository)
        {
            _featureReadRepository = featureReadRepository;
        }

        public async Task<GetByIdFeatureQueryResponse> Handle(GetByIdFeatureQueryRequest request, CancellationToken cancellationToken)
        {
            var feature = await _featureReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                CarFeatures = feature.CarFeatures,
                Name = feature.Name,
            };
        }
    }
}

