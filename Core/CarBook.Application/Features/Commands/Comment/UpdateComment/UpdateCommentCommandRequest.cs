using MediatR;

namespace CarBook.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public Guid BlogID { get; set; }
    }
}