using CarBook.Application.Features.Commands.Location.RemoveLocation;
using MediatR;

namespace CarBook.Application.Features.Commands.Location.RemoveLocation
{
    public class RemoveLocationCommandRequest : IRequest<RemoveLocationCommandResponse>
    {
        public string Id { get; set; }
    }
}