using MediatR;

namespace CarBook.Application.Features.Commands.Contact.UpdateContact
{
    public class UpdateContactCommandRequest : IRequest<UpdateContactCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}