using MediatR;

namespace CarBook.Application.Features.Commands.Service.RemoveService
{
    public class RemoveServiceCommandRequest : IRequest<RemoveServiceCommandResponse>
    {
        public string Id { get; set; }
    }
}