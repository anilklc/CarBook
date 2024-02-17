using MediatR;

namespace CarBook.Application.Features.Queries.Comment.GetCommentByIdBlog
{
    public class GetCommentByIdBlogQueryRequest : IRequest<GetCommentByIdBlogQueryResponse>
    {
        public Guid blogId { get; set; }
    }
}