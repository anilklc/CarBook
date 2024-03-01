using MediatR;

namespace CarBook.Application.Features.Commands.CarFeature.UpdateCarFeatureChangeAvailableToFalse
{
    public class CarFeatureChangeAvailableToFalseCommandRequest : IRequest<CarFeatureChangeAvailableToFalseCommandResponse>
    {
        public string Id { get; set; }
    }
}