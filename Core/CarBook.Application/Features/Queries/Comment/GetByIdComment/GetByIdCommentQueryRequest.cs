using MediatR;

namespace CarBook.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryRequest : IRequest<GetByIdCommentQueryResponse>
    { 
        public string Id { get; set; }
    }
}