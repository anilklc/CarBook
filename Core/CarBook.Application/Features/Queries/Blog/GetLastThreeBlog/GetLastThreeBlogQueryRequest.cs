using MediatR;

namespace CarBook.Application.Features.Queries.Blog.GetLastThreeBlog
{
    public class GetLastThreeBlogQueryRequest : IRequest<GetLastThreeBlogQueryResponse>
    {
    }
}