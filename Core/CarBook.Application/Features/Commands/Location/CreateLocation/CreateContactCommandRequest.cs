using CarBook.Application.Features.Commands.Location.CreateLocation;
using MediatR;

namespace CarBook.Application.Features.Commands.Location.CreateLocation
{
    public class CreateLocationCommandRequest : IRequest<CreateLocationCommandResponse>
    {
        public string Name { get; set; }
    }
}