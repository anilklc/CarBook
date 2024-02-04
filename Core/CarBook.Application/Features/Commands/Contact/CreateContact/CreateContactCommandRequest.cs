using MediatR;

namespace CarBook.Application.Features.Commands.Contact.CreateContact
{
    public class CreateContactCommandRequest : IRequest<CreateContactCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}