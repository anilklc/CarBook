using MediatR;

namespace CarBook.Application.Features.Commands.CarFeature.CreateCarFeature
{
    public class CreateCarFeatureCommandRequest : IRequest<CreateCarFeatureCommandResponse>
    {
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public bool Available { get; set; }
    }
}