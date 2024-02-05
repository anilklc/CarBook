using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Feature.CreateFeature
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommandRequest, CreateFeatureCommandResponse>
    {
        private readonly IFeatureWriteRepository _featureWriteRepository;

        public CreateFeatureCommandHandler(IFeatureWriteRepository featureWriteRepository)
        {
            _featureWriteRepository = featureWriteRepository;
        }

        public async Task<CreateFeatureCommandResponse> Handle(CreateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            await _featureWriteRepository.AddAsync(new()
            {
                CarFeatures = request.CarFeatures,
                Name = request.Name,
            });
            await _featureWriteRepository.SaveAsync();
            return new();
        }
    }
}
