using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CarFeature.UpdateCarFeatureChangeAvailableToTrue
{
    public class CarFeatureChangeAvailableToTrueCommandHandler : IRequestHandler<CarFeatureChangeAvailableToTrueCommandRequest, CarFeatureChangeAvailableToTrueCommandResponse>
    {
        private readonly ICarFeatureReadRepository _carFeatureReadRepository;
        private readonly ICarFeatureWriteRepository _carFeatureWriteRepository;

        public CarFeatureChangeAvailableToTrueCommandHandler(ICarFeatureReadRepository carFeatureReadRepository, ICarFeatureWriteRepository carFeatureWriteRepository)
        {
            _carFeatureReadRepository = carFeatureReadRepository;
            _carFeatureWriteRepository = carFeatureWriteRepository;
        }

        public async Task<CarFeatureChangeAvailableToTrueCommandResponse> Handle(CarFeatureChangeAvailableToTrueCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = await _carFeatureReadRepository.GetByIdAsync(request.Id);
            feature.Available = true;
            await _carFeatureWriteRepository.SaveAsync();
            return new();
        }
    }
}
