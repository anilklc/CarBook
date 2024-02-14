using MediatR;

namespace CarBook.Application.Features.Queries.Blog.GetBlogWithByIdAuthor
{
    public class GetBlogWithByIdAuthorQueryRequest : IRequest<GetBlogWithByIdAuthorQueryResponse>
    {
        public string AuthorId { get; set; }
    }
}