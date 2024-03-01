using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CarFeature.UpdateCarFeatureChangeAvailableToFalse
{
    public class CarFeatureChangeAvailableToFalseCommandHandler : IRequestHandler<CarFeatureChangeAvailableToFalseCommandRequest, CarFeatureChangeAvailableToFalseCommandResponse>
    {
        private readonly ICarFeatureReadRepository _carFeatureReadRepository;
        private readonly ICarFeatureWriteRepository _carFeatureWriteRepository;

        public CarFeatureChangeAvailableToFalseCommandHandler(ICarFeatureReadRepository carFeatureReadRepository, ICarFeatureWriteRepository carFeatureWriteRepository)
        {
            _carFeatureReadRepository = carFeatureReadRepository;
            _carFeatureWriteRepository = carFeatureWriteRepository;
        }

        public async Task<CarFeatureChangeAvailableToFalseCommandResponse> Handle(CarFeatureChangeAvailableToFalseCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = await _carFeatureReadRepository.GetByIdAsync(request.Id);
            feature.Available = false;
            await _carFeatureWriteRepository.SaveAsync();
            return new();

        }
    }
}
