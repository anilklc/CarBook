using MediatR;

namespace CarBook.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public Guid BlogID { get; set; }
    }
}