using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CarFeature.CreateCarFeature
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommandRequest, CreateCarFeatureCommandResponse>
    {
        private readonly ICarFeatureWriteRepository _carFeatureWriteRepository;

        public CreateCarFeatureCommandHandler(ICarFeatureWriteRepository carFeatureWriteRepository)
        {
            _carFeatureWriteRepository = carFeatureWriteRepository;
        }

        public async Task<CreateCarFeatureCommandResponse> Handle(CreateCarFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            await _carFeatureWriteRepository.AddAsync(new()
            {
                CarID = request.CarId,
                FeatureID = request.FeatureId,
                Available = request.Available,
            });
            await _carFeatureWriteRepository.SaveAsync();
            return new();
        }
    }
}
