using MediatR;

namespace CarBook.Application.Features.Commands.CarFeature.UpdateCarFeatureChangeAvailableToTrue
{
    public class CarFeatureChangeAvailableToTrueCommandRequest : IRequest<CarFeatureChangeAvailableToTrueCommandResponse>
    {
        public string Id { get; set; }
    }
}