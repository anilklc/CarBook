using MediatR;

namespace CarBook.Application.Features.Queries.Blog.GetByIdBlog
{
    public class GetByIdBlogQueryRequest : IRequest<GetByIdBlogQueryResponse>
    {
        public string Id { get; set; }
    }
}