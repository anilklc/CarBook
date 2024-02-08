using MediatR;

namespace CarBook.Application.Features.Commands.Author.RemoveAuthor
{
    public class RemoveAuthorCommandRequest : IRequest<RemoveAuthorCommandResponse>
    {
        public string Id { get; set; }
    }
}