using MediatR;

namespace CarBook.Application.Features.Commands.Comment.RemoveComment
{
    public class RemoveCommentCommandRequest : IRequest<RemoveCommentCommandResponse>
    {
        public string Id { get; set; }
    }
}