using MediatR;

namespace CarBook.Application.Features.Commands.CarDescription.CreateCarDescription
{
    public class CreateCarDescriptionRequest : IRequest<CreateCarDescriptionResponse>
    {
        public Guid CarId { get; set; }
        public string Description { get; set; }
    }
}