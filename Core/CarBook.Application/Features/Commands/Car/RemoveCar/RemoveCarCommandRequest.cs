using MediatR;

namespace CarBook.Application.Features.Commands.Car.RemoveCar
{
    public class RemoveCarCommandRequest : IRequest<RemoveCarCommandResponse>
    {
        public string Id { get; set; }
    }
}