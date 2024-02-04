using MediatR;

namespace CarBook.Application.Features.Commands.Contact.RemoveContact
{
    public class RemoveContactCommandRequest : IRequest<RemoveContactCommandResponse>
    {
        public string Id { get; set; }
    }
}